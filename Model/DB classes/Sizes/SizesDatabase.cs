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


        protected List<string> values = new List<string>();
        protected readonly string databaseName, sizesTable;

        //protected double d, d1, d2, db, h;
        //protected int n;

        public readonly string D,D1,D2,H,N;

       
        public SizesDatabase()
        {
            databaseName = MainExplorer.DataBaseExpl.DefaultSizesFullName;
            sizesTable = "sizes";

            

            foreach (var i in GetDefaultData(sizesTable))
                values.Add(i.ToString());

            

            D = values[0].ToString();
            D1 = values[1].ToString();
            D2 = values[2].ToString();
            H = values[3].ToString();
            N = values[4].ToString();


            
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




    }
}
