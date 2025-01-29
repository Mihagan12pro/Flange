using Flange.Kompas.Modeling;
using Flange.Model.Kompas.Entities;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Flange.Model.Kompas.Modeling
{
    internal class FreeFlange3DModel : Flange3DModel
    {
        protected double D1, D2,Db;
        protected int n;

        protected Sketch sketch2;
        protected CutExtrusion cutExtrusion1;
        public FreeFlange3DModel(Diameters diameters, Heights heights,Counts counts) : base(diameters,heights)
        {
            n = counts.n;
            D1 = diameters.D1;
            D2 = diameters.D2;
            Db = diameters.Db;

            detailName = "Свободный фланец.m3d";
        }

        protected override bool ParametresValidation()
        {
            if (!base.ParametresValidation())
            {
                return base.ParametresValidation(); 
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
                return true;
            }

            return true;
        }

        protected virtual void Sketch2()
        {
           sketch2 = new Sketch(iPart,planeXOZ.GetPlane());
           sketch2.Circle(new Point(0,0),Db*0.5);
           sketch2.EndEditingSketch();
        }

        protected virtual void CutExtrusion1()
        {
            cutExtrusion1 = new CutExtrusion(iPart,sketch2,Direction_Type.dtBoth,End_Type.etThroughAll);
            cutExtrusion1.Cut();
        }

        public override void Build()
        {
            base.Build();

            Sketch2();
            CutExtrusion1();
        }
    }
}
