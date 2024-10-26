using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flange.Model;
namespace Flange.Databases
{
    internal class SizesFreeFlange: SizesSimpleFreeFlange
    {
        public readonly string A, S;

        protected readonly string free_sizeTable;

        public SizesFreeFlange()
        {
            free_sizeTable = "free_sizes";


           

            List<object> data2 = GetDefaultData("free_sizes");


            A = data2[0].ToString();
            S = data2[1].ToString();
            Console.WriteLine(A);
           
        }

       
    }
}
