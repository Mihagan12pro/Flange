using Flange.Kompas.Modeling;
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
using System.Windows.Media.Media3D;
namespace Flange.Model.Kompas.Modeling
{
    internal class FreeFlangeKompasModel : FlangeKompasModel, IFreeFlangeModel
    {
        protected readonly double D1, D2,Db;
        protected readonly int n;

        protected Sketch sketch2,sketch3;
        protected CutExtrusion cutExtrusion1, cutExtrusion2;
        protected CircularCopy<AxisByTwoPlanes> circularCopy1;

        protected Chamfer centralHoleChamferTop, centralHoleChamferBottom;
        protected Fillet centralHoleFilletTop, centralHoleFilletBottom;

        protected Chamfer holeForScrewChamferTop, holeForScrewChamferBottom;
        protected Fillet holeForScrewFilletTop, holeForScrewFilletBottom;

        public double _D1 { get; set; }
        public double _D2 { get; set; }
        public double _Db { get; set; }
        public int _n { get; set; }

        public FreeFlangeKompasModel(Diameters diameters, Heights heights,Counts counts, ExtraSizesCollection extraSizes) : base(diameters,heights,extraSizes)
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

            if ((fillets.CentralHoleFilletTop.IsSelected && chamfers.CentralHoleChamferTop.IsSelected)||(fillets.CentralHoleFilletBottom.IsSelected && chamfers.CentralHoleChamferBottom.IsSelected))
            {
                MessageBox.Show("Нельзя применить два вида скруглений к одной и той же грани!");
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
            if (chamfers.HoleForScrewChamferTop.IsSelected)
            {
                circularCopy1.Add(holeForScrewChamferTop);
            }
            if (chamfers.HoleForScrewChamferBottom.IsSelected)
            {
                circularCopy1.Add(holeForScrewChamferBottom);
            }

            if (fillets.HoleForScrewFilletTop.IsSelected)
            {
                circularCopy1.Add(holeForScrewFilletTop);
            }
            if (fillets.HoleForScrewFilletBottom.IsSelected)
            {
                circularCopy1.Add(holeForScrewFilletBottom);
            }
            circularCopy1.Copy();
        }

        protected virtual void CentralHoleChamferTop()
        {
            centralHoleChamferTop = new Chamfer(iPart,new Point3D(Db/2,H/2,0),chamfers.CentralHoleChamferTop);
            centralHoleChamferTop.AddChamfer();
        }
        protected virtual void CentralHoleChamferBottom()
        {
            centralHoleChamferBottom = new Chamfer(iPart, new Point3D(Db / 2, -H / 2, 0), chamfers.CentralHoleChamferBottom);
            centralHoleChamferBottom.AddChamfer();
        }

        protected virtual void CentralHoleFilletTop()
        {
            centralHoleFilletTop = new Fillet(iPart, new Point3D(Db / 2, H / 2, 0), fillets.CentralHoleFilletTop);
            centralHoleFilletTop.AddFillet();
        }

        protected virtual void CentralHoleFilletBottom()
        {
            centralHoleFilletBottom = new Fillet(iPart, new Point3D(Db / 2, -H / 2, 0), fillets.CentralHoleFilletBottom);
            centralHoleFilletBottom.AddFillet();
        }

        protected virtual void HoleForScrewFilletTop()
        {
            holeForScrewFilletTop = new Fillet(iPart, new Point3D(0, H / 2, -(0.5 * D1 + 0.5 * D2)),fillets.HoleForScrewFilletTop);
            holeForScrewFilletTop.AddFillet();
        }

        protected virtual void HoleForScrewFilletBottom()
        {
            holeForScrewFilletBottom = new Fillet(iPart, new Point3D(0, -H / 2, -(0.5 * D1 + 0.5 * D2)), fillets.HoleForScrewFilletBottom);
            holeForScrewFilletBottom.AddFillet();
        }

        protected virtual void HoleForScrewChamferTop()
        {
            holeForScrewChamferTop = new Chamfer(iPart,new Point3D(0,H/2,-(0.5*D1+0.5*D2)/*0.5 * D1 + 0.5 * D2*/),chamfers.HoleForScrewChamferTop);
            holeForScrewChamferTop.AddChamfer();
        }
       
        protected virtual void HoleForScrewChamferBottom()
        {
            holeForScrewChamferBottom = new Chamfer(iPart, new Point3D(0, -H/2, -(0.5 * D1 + 0.5 * D2)/*0.5 * D1 + 0.5 * D2*/), chamfers.HoleForScrewChamferBottom);
            holeForScrewChamferBottom.AddChamfer();
        }

        public override void Build()
        {
            canBuild = ParametresValidation();
            if (canBuild)
            {
                base.Build();
                Sketch2();
                CutExtrusion1();
                if (fillets.CentralHoleFilletBottom.IsSelected)
                {
                    CentralHoleFilletBottom();
                }
                if (fillets.CentralHoleFilletTop.IsSelected)
                {
                    CentralHoleFilletTop();
                }
                if (chamfers.CentralHoleChamferBottom.IsSelected)
                {
                    CentralHoleChamferBottom();
                }
                if (chamfers.CentralHoleChamferTop.IsSelected)
                {
                    CentralHoleChamferTop();
                }

                Sketch3();

                CutExtrusion2();
                if (chamfers.HoleForScrewChamferTop.IsSelected)
                {
                    HoleForScrewChamferTop();
                }
                if (chamfers.HoleForScrewChamferBottom.IsSelected)
                {
                    HoleForScrewChamferBottom();
                }
                if (fillets.HoleForScrewFilletBottom.IsSelected)
                {
                    HoleForScrewFilletBottom();
                }
                if(fillets.HoleForScrewFilletTop.IsSelected)
                {
                    HoleForScrewFilletTop();
                }

                CircularArray1();
            }
        }
    }
}
