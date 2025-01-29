using Flange.Kompas.Modeling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Flange.Model.Kompas.Modeling
{
    internal class FreeFlange3DModel : Flange3DModel
    {
        protected double D1, D2,Db;
        protected int n;
        public FreeFlange3DModel(Diameters diameters, Heights heights,Counts counts) : base(diameters,heights)
        {
            n = counts.n;
            D1 = diameters.D1;
            D2 = diameters.D2;
            Db = diameters.Db;

            detailName = "Свободный фланец.m3d";
        }

        

        public override void Build()
        {
            base.Build();
        }
    }
}
