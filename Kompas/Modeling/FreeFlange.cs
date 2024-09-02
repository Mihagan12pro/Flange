using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Flange.Kompas.Modeling
{
    internal class FreeFlange : SimpleFlange
    {
        public FreeFlange(string D, string D1, string D2, string Db, string H, string CountOfHoles) : base(D, D1, D2, Db, H, CountOfHoles)
        {

        }

        public override void TryToBuild()
        {
           
        }
    }
}
