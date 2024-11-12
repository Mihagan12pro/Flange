using Flange.Other;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Sizes
{
     abstract class AbstractDefaultSizesDb
    {
        protected readonly string databaseName;
        protected List<object> GetDefaultData(string table)
        {
            List<object> list = new List<object>();
            using (SQLiteConnection connection = new SQLiteConnection(databaseName))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand())
                {

                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM {table}";

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                list.Add(reader.GetValue(i));
                            }
                        }
                    }
                }


                connection.Close();
            }
            return list;
        }

        public AbstractDefaultSizesDb()
        {
            //databaseName = MainExplorer.DataBaseExpl.DefaultSizesFullName;
        }
    }
}
