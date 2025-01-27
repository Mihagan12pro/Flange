using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Default.Values
{
    internal class CollarFlangeDefaultValues : FlatFlangeDefaultValues
    {
        public readonly double D4, D5, H2, H3;


        public CollarFlangeDefaultValues()
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT {valueName} FROM {tableName} WHERE ( {primaryKeyName} = 5 OR {primaryKeyName} = 5 OR {primaryKeyName} = 10 OR {primaryKeyName} = 11)", connection))
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
                                        D4 = Convert.ToDouble(reader.GetValue(0));
                                        count++;
                                        break;
                                    }
                                case 1:
                                    {
                                        D5 = Convert.ToDouble(reader.GetValue(0));
                                        count++;
                                        break;
                                    }
                                case 2:
                                    {
                                        H2 = Convert.ToDouble(reader.GetValue(0));
                                        count++;
                                        break;
                                    }
                                default:
                                    {
                                        H3 = Convert.ToDouble(reader.GetValue(0));
                                        count++;
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
