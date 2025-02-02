﻿using Flange.Kompas.Modeling;
using Flange.Model.Interface;
using Flange.Model.Kompas.Kompas_override;
using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Flange.Model.Kompas.Modeling
{
    internal class FreeFlange3DModel : Flange3DModel, IFreeFlangeModel
    {
        protected readonly double D1, D2,Db;
        protected readonly int n;

        protected Sketch sketch2,sketch3;
        protected CutExtrusion cutExtrusion1, cutExtrusion2;
        protected CircularCopy<AxisByTwoPlanes> circularCopy1;

        public double _D1 { get; set; }
        public double _D2 { get; set; }
        public double _Db { get; set; }
        public int _n { get; set; }

        public FreeFlange3DModel(Diameters diameters, Heights heights,Counts counts, ExtraSizesCollection extraSizes) : base(diameters,heights,extraSizes)
        {
            _n = counts.n;
            _D1 = diameters.D1;
            _D2 = diameters.D2;
            _Db = diameters.Db;

            n = _n;
            D1 = _D1;
            D2 = _D2;
            Db = _Db;
            detailName = "Свободный фланец" + FileExtension;
        }

        protected override bool ParametresValidation()
        {
            if (!base.ParametresValidation())
            {
                return false; 
            }

            if (Db >= D || Db == 0)
            {
                MessageBox.Show("Некорректный размер Db!");
                return false;
            }

            if (D1 ==0 || D1 >= D)
            {
                MessageBox.Show("Некорректный размер D1!");
                return false;
            }

            if (D2 >= D1 || D2 == 0)
            {
                MessageBox.Show("Некорректный размер D2!");
                return false;
            }

            if (Convert.ToDouble(n) > Math.Floor(Math.PI * D1/D2))
            {
                MessageBox.Show("Отверстия с диаметров D2 не поместятся в таком количестве!");
                return false;
            }

            return true;
        }

        protected virtual void Sketch2()
        {
           sketch2 = new Sketch(iPart,planeXOZ.GetPlane());
           sketch2.Circle(new Point(0,0),Db);
           sketch2.CreateSketch();
        }

        protected virtual void CutExtrusion1()
        {
            cutExtrusion1 = new CutExtrusion(iPart,sketch2,Direction_Type.dtBoth,End_Type.etThroughAll);
            cutExtrusion1.Cut();
        }

        protected virtual void Sketch3()
        {
            sketch3 = new Sketch(iPart,planeXOZ.GetPlane());

            //sketch3.CenterCircle(new Point(0,0),D1);
            sketch3.Circle(new Point(0,D1/2),D2);

            sketch3.CreateSketch();
        }

        protected virtual void CutExtrusion2()
        {
            cutExtrusion2 = new CutExtrusion(iPart,sketch3,Direction_Type.dtBoth,End_Type.etThroughAll);

            cutExtrusion2.Cut();
        }

        protected virtual void CircularArray1()
        {
            AxisByTwoPlanes axis = new AxisByTwoPlanes(iPart,StandartPlanes.XOY,StandartPlanes.YOZ);
            axis.CreateAxis();

            circularCopy1 = new CircularCopy<AxisByTwoPlanes>(iPart,n,axis,360);
            circularCopy1.Add(cutExtrusion2);
            circularCopy1.Copy();
        }

        public override void Build()
        {
            canBuild = ParametresValidation();
            if (canBuild)
            {
                base.Build();
                Sketch2();
                CutExtrusion1();
                Sketch3();
                CutExtrusion2();
                CircularArray1();
            }
        }
    }
}
