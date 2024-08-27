using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Flange.Databases
{
    internal class SizesSimpleFlange:SizesDatabase
    {

        public SizesSimpleFlange() 
        {
            databaseName = $"Data Source={@"..\..\Databases\DBs\Flange.db"}";
            tableName = "sizes";

            List<object> data = GetDefaultData();


            for (int i = 0; i < data.Count; i++)
            {
                switch(i)
                {
                    case 0:
                        d = Convert.ToDouble(data[i]);
                        break;
                      
                    case 1:
                        d1 = Convert.ToDouble(data[i]);
                        break;

                    case 2:
                        d2 = Convert.ToDouble(data[i]);
                        break;

                    case 3:
                        db = Convert.ToDouble(data[i]);
                        break;
                    case 4:
                       h  = Convert.ToDouble(data[i]);
                        break;

                    default:
                        n = Convert.ToInt32(data[i]);
                        break;

                }
            }
        }

    }
}
