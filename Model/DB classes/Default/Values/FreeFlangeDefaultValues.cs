using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Default.Values
{
    internal class FreeFlangeDefaultValues: DefaultValues
    {
        public readonly double D1, D2, Db;
        public readonly int n;

        public FreeFlangeDefaultValues()
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT {valueName} FROM {tableName} WHERE ( {primaryKeyName} = 2 OR {primaryKeyName} = 3 OR {primaryKeyName} = 7 OR {primaryKeyName} = 13)", connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        if (int.TryParse(Convert.ToString(reader.GetValue(0)), out int i) || double.TryParse(Convert.ToString(reader.GetValue(0)), out double d))
                        {
                          
                                switch (count)
                                {
                                    case 0:
                                        {
                                            D1 = Convert.ToDouble(reader.GetValue(0));
                                            count++;
                                            break;
                                        }
                                    case 1:
                                        {
                                            D2 = Convert.ToDouble(reader.GetValue(0));
                                            count++;
                                            break;
                                        }
                                    case 2:
                                        {
                                            Db = Convert.ToDouble(reader.GetValue(0));
                                            count++;
                                            break;
                                        }
                                    default:
                                    {
                                        if (!int.TryParse(Convert.ToString(reader.GetValue(0)), out int i2))
                                        {
                                            throw valueError;
                                        }
                                        n = Convert.ToInt32(Convert.ToString(reader.GetValue(0)));
                                        break;
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
