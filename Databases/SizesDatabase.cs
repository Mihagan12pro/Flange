using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Databases
{
    internal abstract class SizesDatabase
    {

        protected int rowCount;
        protected string databaseName, tableName;

        private double d, d1, d2, db, h;
        private int n;


        public SizesDatabase()
        {
           
        }

        public string GetParam(int id)
        {
            switch (id)
            {
                case 0:
                    return d.ToString();
                    
                case 1:
                    return d1.ToString();
                 
                case 2:
                    return d2.ToString();

                case 3:
                    return db.ToString();
                case 4:
                    return h.ToString();
                case 5:
                    return n.ToString();

                default:
                    return "";
            }
        }
    }
}
