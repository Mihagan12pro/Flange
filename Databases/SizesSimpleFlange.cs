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
                        d.TextBoxValue = Convert.ToDouble(data[i]).ToString();
                        parametresList.Add(d);
                        break;
                      
                    case 1:
                        d1.TextBoxValue = Convert.ToDouble(data[i]).ToString();
                        parametresList.Add(d1);
                        break;

                    case 2:
                        d2.TextBoxValue = Convert.ToDouble(data[i]).ToString();
                        parametresList.Add(d2);
                        break;

                    case 3:
                        db.TextBoxValue = Convert.ToDouble(data[i]).ToString();
                        parametresList.Add(db);
                        break;
                    case 4:
                       h.TextBoxValue  = Convert.ToDouble(data[i]).ToString();
                        parametresList.Add(h);
                        break;

                    case 5:
                        n.TextBoxValue = Convert.ToInt32(data[i]).ToString();
                        parametresList.Add(n);
                        break;

                }
                
            }
        }

    }
}
