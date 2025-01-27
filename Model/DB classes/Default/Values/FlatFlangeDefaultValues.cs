using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Default.Values
{
    internal class FlatFlangeDefaultValues: FreeFlangeDefaultValues
    {
        public readonly double D3, H4;


        public FlatFlangeDefaultValues()
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT {valueName} FROM {tableName} WHERE ( {primaryKeyName} = 12 OR {primaryKeyName} = 4)", connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        if (double.TryParse(Convert.ToString(reader.GetValue(0)), out double d))
                        {

                            switch (count)
                            {
                                case 0:
                                    {
                                        D3 = Convert.ToDouble(reader.GetValue(0));
                                        count++;
                                        break;
                                    }
                                case 1:
                                    {
                                        H4 = Convert.ToDouble(reader.GetValue(0));
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
