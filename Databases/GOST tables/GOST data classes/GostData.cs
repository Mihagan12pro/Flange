using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Databases.GOST_tables.GOST_data_classes
{
    internal abstract class GostData
    {
        public double D { get; private set; }
        public double D1 { get; private set; }
        public double D2 { get; private set; }
        public double H { get; private set; }
        public int CountOfHoles {  get; private set; }  



        protected GostData(double D,double D1,double D2,double H,int CountOfHoles )
        {
            this.D = D;
            this.D1 = D1;
            this.D2 = D2;
            this.H = H;
            this.CountOfHoles = CountOfHoles ;
        }
    }
}
