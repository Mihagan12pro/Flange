using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Default.Values
{
    internal class BlindFlangeDefaultValues : DefaultValues
    {
        public readonly double D1, D2,D3,H4,n;
        public BlindFlangeDefaultValues()
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT {valueName} FROM {tableName} WHERE ( {primaryKeyName} = 2 OR {primaryKeyName} = 3 OR {primaryKeyName} = 4 OR {primaryKeyName} = 12  OR {primaryKeyName} = 13)", connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        if (double.TryParse(Convert.ToString(reader.GetValue(0)), out double d))
                        {
                            switch(count)
                            {
                                case 0:
                                    {
                                        count++;
                                        D1 = d;
                                        break; 
                                    }
                                case 1:
                                    {
                                        D2 = d;
                                        count++;
                                        break;
                                    }
                                case 2:
                                    {
                                        D3 = d;
                                        count++;
                                        break;
                                    }
                                case 3:
                                    {
                                        H4 = d;
                                        count++;
                                        break;
                                    }
                                default:
                                    {
                                        if (int.TryParse(Convert.ToString(d),out int i))
                                        {
                                            n = i;
                                            return;
                                        }
                                        throw valueError;
                                    }
                            }
                        }
                        else
                        {
                            throw valueError;
                        }
                       
                    }
                }
            }
        }
    }
}
