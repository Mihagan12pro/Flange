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
using Flange.Model.Interface;
using System.Windows.Navigation;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
namespace Flange.Kompas.Modeling
{
    public abstract class FlangeKompasModel : IFlangeModel
    {
        protected KompasObject Kompas;
        protected  ksDocument3D iDocument3D;
        protected ksDocument2D iDocument2D;

        
        protected ksPart iPart;

        protected Plane planeXOY, planeXOZ, planeYOZ;
        protected Sketch sketch1;
        protected BossRotation bossRotation1;
        protected Chamfer diskChamferTop,diskChamferBottom;
        protected Fillet diskFilletTop,diskFilletBottom;

        protected string detailName;

        protected readonly double D;
        public double _D { get; set; }


        protected readonly double H;
        public double _H { get; set; }

        protected bool canBuild;


        protected ChamferSizesCollection chamfers;
        public ChamferSizesCollection _Chamfers { get; set; }

        protected string fileExtension;
        public string FileExtension { get=>fileExtension; set=>fileExtension = value; }

        public string OneDrive { get; set; }

        public string UserRoot { get; set; }

        public string Document { get; set; }

        protected FilletSizesCollection fillets;
        public FilletSizesCollection _Fillets { get; set; }

        protected readonly string document;
       

        public FlangeKompasModel(Diameters diameters, Heights heights, ExtraSizesCollection extraSizes)
        {
           _D = diameters.D;
           _H = heights.H;

            D = _D;
            H = _H;

           _Chamfers = extraSizes.Chamfers;
           chamfers = _Chamfers;

            _Fillets = extraSizes.Fillets;
            fillets = _Fillets;

            UserRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");

            OneDrive = Path.Combine(UserRoot, "OneDrive");

            Document = Path.Combine(OneDrive, "Документы");

            document = Document;


            FileExtension = ".m3d";
        }

        protected virtual bool ParametresValidation()
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
            if ((chamfers.DiskChamferBottom.IsSelected && fillets.DiskFilletBottom.IsSelected) || (chamfers.DiskChamferTop.IsSelected && fillets.DiskFilletTop.IsSelected))
            {
                MessageBox.Show("Нельзя применить два вида скруглений к одной и той же грани!");
                return false;
            }
            return true;
        }

        public virtual void Build()
        {
            canBuild = ParametresValidation();
            if (canBuild)
            {
                try
                {
                    Kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                    Kompas.Visible = true;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    if (Kompas == null)
                    {
                        if (Kompas == null)
                        {
                            var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                            Kompas = (KompasObject)Activator.CreateInstance(type);
                        }

                        if (Kompas != null)
                        {
                            Kompas.Visible = true;
                            Kompas.ActivateControllerAPI();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка подключения к программе КОМПАС-3D!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }

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

                if (fillets.DiskFilletTop.IsSelected)
                {
                    DiskFilletTop();
                }

                if (fillets.DiskFilletBottom.IsSelected)
                {
                    DiskFilletBottom();
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
            diskChamferBottom = new Chamfer(iPart, new Point3D(D/2,-H / 2,0), chamfers.DiskChamferBottom);
            diskChamferBottom.AddChamfer();
        }

        protected virtual void DiskFilletTop()
        {
            diskFilletTop = new Fillet(iPart, new Point3D(D / 2, H / 2, 0), fillets.DiskFilletTop);
            diskFilletTop.AddFillet();
        }

        protected virtual void DiskFilletBottom()
        {
            diskFilletBottom = new Fillet(iPart, new Point3D(D / 2, -H / 2, 0), fillets.DiskFilletBottom);
            diskFilletBottom.AddFillet();
        }

        public void SaveModel()
        {
            if (canBuild)
                iDocument3D.SaveAs(Path.Combine(document, detailName));
        }
    }
}

