using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Databases.GOST_tables.GOST_data_classes
{
    internal class FreeFlangeData : GostData
    {
        public double Db { get; private set; }
        public FreeFlangeData(double D, double D1, double D2, double H, int CountOfHoles,double Db):base(D,D1,D2,H,CountOfHoles)
        {
            this.Db = Db;
        }


    }
}
