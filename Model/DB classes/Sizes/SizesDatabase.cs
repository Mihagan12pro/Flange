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

        protected string d,d1,d2,db,h,n;

        protected List<string> parametresList = new List<string>();
        public SizesDatabase(string d,string d1,string d2,string db,string h,string n)
        {
           
            this.d = d;
            this.d1 = d1;
            this.d2 = d2;
            this.db = db;
            this.h = h;
            this.n = n;
        }

        //public  string GetParam(int id)
        //{

        //    foreach (var par in parametresList)
        //    {
        //        if (par.Id == id)
        //        {
        //            return par.TextBoxValue;
        //        }
        //    }
        //    return "";
            
        //}

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
