using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flange.Model;
namespace Flange.Databases
{
    internal class SizesFreeFlange: SizesSimpleFlange
    {
        protected string a, s;

        private string tableName2;

        public SizesFreeFlange(string d, string d1, string d2,string db, string h, string n, string a,string s):base(d,d1,d2,db,h,n)
        {
            tableName2 = "free_sizes";


            this.a = a;
            this.s = s;

            List<object> data2 = GetDefaultData(tableName2);


            this.a = data2[0].ToString();
            this.s = data2[1].ToString();
           
        }

       
    }
}
