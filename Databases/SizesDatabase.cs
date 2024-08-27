using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Databases
{
    internal abstract class SizesDatabase
    {

        
        protected string databaseName, tableName;
        
        protected double d, d1, d2, db, h;
        protected int n;

        
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

        protected List<object>GetDefaultData()
        {
            List<object>list = new List<object>();
            using (SQLiteConnection connection = new SQLiteConnection(databaseName))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM {tableName}";

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
    }
}
