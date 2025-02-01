using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Kompas6Constants;
using System.Windows.Media.Media3D;
using System;
using System.Collections.Generic;
using Kompas6API5;
using Kompas6Constants3D;
using System.Runtime.InteropServices;
using Flange.Model.Kompas.Kompas_override;
using Flange.Model.Kompas;
using Flange.Other;
using Flange.Model;
using System.IO;
namespace Flange.Kompas.Modeling
{
    public abstract class Flange3DModel: FlangeDocument
    {
        protected  ksDocument3D iDocument3D;

    
        protected ksDocument2D iDocument2D;

        protected ChamferSizesCollection chamfers;
        
        protected ksPart iPart;

        protected Plane planeXOY, planeXOZ, planeYOZ;
        protected Sketch sketch1;
        protected BossRotation bossRotation1;
        protected Chamfer diskChamferTop,diskChamferBottom;


       

        protected double D, H;

        public Flange3DModel(Diameters diameters, Heights heights, ExtraSizesCollection extraSizes):base (diameters, heights)
        {
            D = diameters.D;
            H = heights.H;

            this.chamfers = extraSizes.Chamfers;
        }

        protected override bool ParametresValidation()
        {
            if (D == 0)
            {
                MessageBox.Show("Диметр не должен быть равен нулю!");
                return false;
            }
            if (H == 0)
            {
                MessageBox.Show("Высота грани не должна быть равна нулю!");
                return false;
            }
            return true;
        }

        public override void Build()
        {
            if (ParametresValidation())
            {
                base.Build();

                iDocument3D = (ksDocument3D)Kompas.Document3D();
                iDocument3D.Create(false, true);

                iPart = (part)iDocument3D.GetPart(-1);

                planeXOY = new Plane(iPart,StandartPlanes.XOY);
                planeXOZ = new Plane(iPart, StandartPlanes.XOZ);
                planeYOZ = new Plane(iPart, StandartPlanes.YOZ);

                Sketch1();
                BossRotation1();

                if (chamfers.DiskChamferTop.IsSelected)
                {
                    DiskChamferTop();
                }

                if (chamfers.DiskChamferBottom.IsSelected)
                {
                    DiskChamferBottom();
                }
            }
           
        }


        protected virtual void Sketch1()
        {
            sketch1 = new Sketch(iPart,planeXOY.GetPlane());

            Point rightBottomPoint = new Point(0,-H/2);
            Point rightTopPoint = new Point(0,H/2);

            Point leftBottomPoint = new Point(D/2,-H/2);
            Point leftTopPoint = new Point(D/2,H/2);

            sketch1.Line(rightTopPoint,rightBottomPoint);
            sketch1.Line(rightTopPoint,leftTopPoint);
            sketch1.Line(leftTopPoint,leftBottomPoint);
            sketch1.Line(leftBottomPoint,rightBottomPoint);

            sketch1.CenterLine(rightBottomPoint,rightTopPoint);

            sketch1.CreateSketch();
        }

        protected virtual void BossRotation1()
        {
            bossRotation1 = new BossRotation(iPart,sketch1,360,Constants.Forward);

            bossRotation1.Rotate();
        }

        protected virtual void DiskChamferTop()
        {
            diskChamferTop = new Chamfer(iPart,new Point3D(D/2,H/2,0),chamfers.DiskChamferTop);
            diskChamferTop.AddChamfer();
        }

        protected virtual void DiskChamferBottom()
        {
            diskChamferBottom = new Chamfer(iPart, new Point3D(D/2,-H/2,0), chamfers.DiskChamferBottom);
            diskChamferBottom.AddChamfer();
        }

        public override void SaveModel()
        {
            iDocument3D.SaveAs(Path.Combine(Documents, detailName));
        }
    }
}

