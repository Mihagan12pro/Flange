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
        public readonly string A, S;

        private string tableName2;

        public SizesFreeFlange()
        {
            tableName2 = "free_sizes";


           

            List<object> data2 = GetDefaultData(tableName2);


            A = data2[0].ToString();
            S = data2[1].ToString();
           
        }

       
    }
}
