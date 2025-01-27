using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Default.Values
{
    internal abstract class DefaultValues: Value
    {
        public readonly double D, H;
        private static bool installedConnection = false;

        protected readonly string tableName, valueName,primaryKeyName;

        protected static SQLiteConnection connection;
        public static SQLiteConnection Connection
        {
            get
            {
                return connection;
            }
            set
            {
                if (!installedConnection)
                {
                    installedConnection = true;
                    connection = value;
                    connection.Open();
                }
            }
        }


        public DefaultValues()
        {
            tableName = "Default_values";
            valueName = "value";
            primaryKeyName = "id";

            using (SQLiteCommand command = new SQLiteCommand($"SELECT {valueName} FROM {tableName} WHERE ( {primaryKeyName} = 1 OR {primaryKeyName} = 8)",connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    int count = 0;
                    while(reader.Read())
                    {
                        if (!double.TryParse(Convert.ToString(reader.GetValue(0)), out double d))
                        {
                            throw valueError;
                        }
                        if (count == 0)
                        {
                            D = Convert.ToDouble(reader.GetValue(0));
                            count++;
                        }
                        else
                        {
                            H = Convert.ToDouble((reader.GetValue(0)));
                        }
                    }
                }
            }
        }
    }
}
