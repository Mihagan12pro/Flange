using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Databases.GOST_tables.GOST_data_classes
{
    internal abstract class GostData
    {
        public string D { get; private set; }
        public string D1 { get; private set; }
        public string D2 { get; private set; }
    
        public string CountOfHoles {  get; private set; }  



        protected GostData(double D,double D1,double D2,int CountOfHoles )
        {
            this.D = D.ToString();
            this.D1 = D1.ToString();
            this.D2 = D2.ToString() ;
                   this.CountOfHoles = CountOfHoles.ToString() ;
        }
    }
}
