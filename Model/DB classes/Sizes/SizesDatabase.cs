using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Flange.Other;
using Flange.Model;
namespace Flange.Databases
{
    internal abstract class SizesDatabase
    {

       
        
        protected string databaseName, tableName;

        //protected double d, d1, d2, db, h;
        //protected int n;

        public readonly string D,D1,D2,Db,H,N;

       
        public SizesDatabase()
        {
            databaseName = MainExplorer.DataBaseExpl.DefaultSizesFullName;
            tableName = "sizes";

            List<object> data = GetDefaultData(tableName);

            D = data[0].ToString();
            D1 = data[1].ToString();
            D2 = data[2].ToString();
            Db = data[3].ToString();
            H = data[4].ToString();
            N = data[5].ToString();

        }



        protected  List<object>GetDefaultData(string table)
        {
            List<object>list = new List<object>();
            using (SQLiteConnection connection = new SQLiteConnection(databaseName))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand())
                {
              
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM {"sizes"}";

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
