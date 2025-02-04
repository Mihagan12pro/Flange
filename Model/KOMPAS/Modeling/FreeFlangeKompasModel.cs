using Flange.Kompas.Modeling;
using Flange.Model.Interface;
using Flange.Model.Kompas.Kompas_override;
using Flange.Model.KOMPAS.Modeling;
using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
namespace Flange.Model.Kompas.Modeling
{
    internal class FreeFlangeKompasModel : FlangeModelWithHolesForScrews, IFreeFlangeModel
    {
      

        protected Sketch sketch3;
        protected CutExtrusion cutExtrusion2;

        protected Chamfer centralHoleChamferTop, centralHoleChamferBottom;
        protected Fillet centralHoleFilletTop, centralHoleFilletBottom;

    

        public double _Db { get; set; }
        protected readonly double Db;

        public FreeFlangeKompasModel(Diameters diameters, Heights heights,Counts counts, ExtraSizesCollection extraSizes) : base(diameters,heights,counts,extraSizes)
        {
            _Db = diameters.Db;
            Db = _Db;
            detailName = "Свободный фланец" + FileExtension;
        }

        protected override bool ParametresValidation()
        {
            canBuild = base.ParametresValidation();
            if (canBuild == false)
            {
                return false; 
            }

            if (Db >= D || Db == 0)
            {
                MessageBox.Show("Некорректный размер Db!");
                return false;
            }

            if ((fillets.CentralHoleFilletTop.IsSelected && chamfers.CentralHoleChamferTop.IsSelected)||(fillets.CentralHoleFilletBottom.IsSelected && chamfers.CentralHoleChamferBottom.IsSelected))
            {
                MessageBox.Show("Нельзя применить два вида скруглений к одной и той же грани!");
                return false;
            }
            return true;
        }



        

       
        protected virtual void Sketch3()
        {
            sketch3 = new Sketch(iPart, planeXOZ.GetPlane());

            sketch3.Circle(new Point(0,0),Db);

            sketch3.CreateSketch();
        }
        protected virtual void CutExtrusion2()
        {
            cutExtrusion2 = new CutExtrusion(iPart,sketch3,Direction_Type.dtBoth,End_Type.etThroughAll);
            cutExtrusion2.Cut();
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

       

        public override void Build()
        {
            canBuild = ParametresValidation();
            if (canBuild)
            {
                base.Build();
                Sketch3();
                CutExtrusion2();

                if (fillets.CentralHoleFilletBottom.IsSelected)
                    CentralHoleFilletBottom();
                if (fillets.CentralHoleFilletTop.IsSelected)
                    CentralHoleFilletTop();

                if (chamfers.CentralHoleChamferBottom.IsSelected)
                    CentralHoleChamferBottom();
                if (chamfers.CentralHoleChamferTop.IsSelected)
                    CentralHoleChamferTop();
            }
        }
    }
}
