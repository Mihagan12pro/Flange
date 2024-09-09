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
        protected Parametre a, s;

        private string tableName2;

        public SizesFreeFlange()
        {
            tableName2 = "free_sizes";

            a = new Parametre(6);
            s = new Parametre(7);

            List<object> data = GetDefaultData(tableName2);

            for(int i=0;i<data.Count; i++)
            {
                switch(i)
                {
                    case 0:
                        a.TextBoxValue = data[i].ToString();
                        parametresList.Add(a);
                        break;

                    case 1:
                        s.TextBoxValue = data[i].ToString();
                        parametresList.Add(s);
                        break;
                }
            }
           
        }

       
    }
}
