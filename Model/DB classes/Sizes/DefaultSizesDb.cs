using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Flange.Other;
using Flange.Model;
using Flange.Model.DB_classes.Sizes;
namespace Flange.Databases
{
    internal abstract class DefaultSizesDb: AbstractDefaultSizesDb
    {


        protected List<string> values = new List<string>();
        protected readonly string  sizesTable;

        //protected double d, d1, d2, db, h;
        //protected int n;

        public readonly string D,D1,D2,H,N;

       
        public DefaultSizesDb()
        {
           
            sizesTable = "sizes";

            

            foreach (var i in GetDefaultData(sizesTable))
                values.Add(i.ToString());

            

            D = values[0].ToString();
            D1 = values[1].ToString();
            D2 = values[2].ToString();
            H = values[3].ToString();
            N = values[4].ToString();


            
        }



       



    }
}
