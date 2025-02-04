using Flange.Kompas.Modeling;
using Flange.Model.Interface;
using Flange.Model.Kompas.Kompas_override;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Flange.Model.KOMPAS.Modeling
{
    internal abstract class FlangeModelWithHolesForScrews : FlangeKompasModel,IFlangeModelWithHolesForScrews
    {
        public double _D1 { get; set; }
        public double _D2 { get; set; }
        public int _n { get; set; }

        protected readonly double D1, D2;
        protected readonly int n;

        protected Sketch sketch2;
        protected CutExtrusion cutExtrusion1;
        protected CircularCopy<AxisByTwoPlanes> circularCopy1;

        protected Chamfer holeForScrewChamferTop, holeForScrewChamferBottom;
        protected Fillet holeForScrewFilletTop, holeForScrewFilletBottom;

        protected override bool ParametresValidation()
        {
            canBuild = base.ParametresValidation();
            if (canBuild == false)
            {
                return false;
            }

            if (D1 == 0 || D1 >= D)
            {
                MessageBox.Show("Некорректный размер D1!");
                return false;
            }

            if (D2 >= D1 || D2 == 0)
            {
                MessageBox.Show("Некорректный размер D2!");
                return false;
            }

            if (Convert.ToDouble(n) > Math.Floor(Math.PI * D1 / D2))
            {
                MessageBox.Show("Отверстия с диаметров D2 не поместятся в таком количестве!");
                return false;
            }
            if ((fillets.HoleForScrewFilletTop.IsSelected && chamfers.HoleForScrewChamferTop.IsSelected)|| (fillets.HoleForScrewFilletBottom.IsSelected && chamfers.HoleForScrewChamferBottom.IsSelected))
            {
                MessageBox.Show("Нельзя применить два вида скруглений к одной и той же грани!");
                return false;
            }
            return true;
        }

        protected virtual void Sketch2()
        {
            sketch2 = new Sketch(iPart, planeXOZ.GetPlane());

            sketch2.Circle(new Point(0, D1 / 2), D2);

            sketch2.CreateSketch();
        }

        protected virtual void CutExtrusion1()
        {
            cutExtrusion1 = new CutExtrusion(iPart, sketch2, Direction_Type.dtBoth, End_Type.etThroughAll);

            cutExtrusion1.Cut();
        }

        protected virtual void CircularArray1()
        {
            AxisByTwoPlanes axis = new AxisByTwoPlanes(iPart, StandartPlanes.XOY, StandartPlanes.YOZ);
            axis.CreateAxis();

            circularCopy1 = new CircularCopy<AxisByTwoPlanes>(iPart, n, axis, 360);
            circularCopy1.Add(cutExtrusion1);
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

        protected virtual void HoleForScrewFilletTop()
        {
            holeForScrewFilletTop = new Fillet(iPart, new Point3D(0, H / 2, -(0.5 * D1 + 0.5 * D2)), fillets.HoleForScrewFilletTop);
            holeForScrewFilletTop.AddFillet();
        }

        protected virtual void HoleForScrewFilletBottom()
        {
            holeForScrewFilletBottom = new Fillet(iPart, new Point3D(0, -H / 2, -(0.5 * D1 + 0.5 * D2)), fillets.HoleForScrewFilletBottom);
            holeForScrewFilletBottom.AddFillet();
        }

        protected virtual void HoleForScrewChamferTop()
        {
            holeForScrewChamferTop = new Chamfer(iPart, new Point3D(0, H / 2, -(0.5 * D1 + 0.5 * D2)/*0.5 * D1 + 0.5 * D2*/), chamfers.HoleForScrewChamferTop);
            holeForScrewChamferTop.AddChamfer();
        }

        protected virtual void HoleForScrewChamferBottom()
        {
            holeForScrewChamferBottom = new Chamfer(iPart, new Point3D(0, -H / 2, -(0.5 * D1 + 0.5 * D2)/*0.5 * D1 + 0.5 * D2*/), chamfers.HoleForScrewChamferBottom);
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

                if (chamfers.HoleForScrewChamferBottom.IsSelected)
                    HoleForScrewChamferBottom();

                if (chamfers.HoleForScrewChamferTop.IsSelected)
                    HoleForScrewChamferTop();

                if (fillets.HoleForScrewFilletBottom.IsSelected)
                    HoleForScrewFilletBottom();

                if (fillets.HoleForScrewFilletTop.IsSelected)
                    HoleForScrewFilletTop();
        
                CircularArray1();
           }
        }


        protected FlangeModelWithHolesForScrews(Diameters diameters, Heights heights,Counts counts, ExtraSizesCollection extraSizes) : base(diameters, heights, extraSizes)
        {
            _D1 = diameters.D1;
            _D2 = diameters.D2;
            _n = counts.n;

            n = _n;
            D1 = _D1;
            D2 = _D2;
        }
    }
}
