using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Flange.Model;

using Flange.Other;
namespace Flange.Databases
{
    internal class SizesSimpleFlange:SizesDatabase
    {

        public SizesSimpleFlange(Parametre d, Parametre d1, Parametre d2, Parametre db, Parametre h, Parametre n) : base(d, d1, d2, db, h, n)
        {
            databaseName = MainExplorer.DataBaseExpl.DefaultSizesFullName;
            tableName = "sizes";

            List<object> data = GetDefaultData(tableName);

         

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
