using Flange.Other;
using Flange.Other.Abstract_classes_and_interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Default
{
    public abstract class DefaultFlangeTable: SizeTable
    {
        //protected readonly string tableFullName = MainExplorer.DataBaseExpl.DefaultSizesFullName;

        protected double d;
        public double D
        {
            get
            {
                return d;
            }
            protected set
            {
                d = value;
                OnPropertyChanged();
            }
        }

        protected double h;
        public double H
        {
            get
            {
                return h;
            }
            protected set
            {
                h = value; 
                OnPropertyChanged();
            }
        }


        public DefaultFlangeTable()
        {
            tableName = new DefaultDataBase().DatabaseTables[DefaultDataBase.AbstractFlangeIndex];

            dbName = new DefaultDataBase().DatabaseFullName;

            object []objs = new object[2];
            objs = ExtractData().ToArray();

            D = Convert.ToDouble(objs[0]);
            H = Convert.ToDouble(objs[0]);
        }


        protected override List<object> ExtractData()
        {
            List<object> extractedData = new List<object>();

            using (SQLiteConnection connection = new SQLiteConnection(dbName))
            {
                int n = -1;
                connection.Open();

                string commandText = $"SELECT * FROM {tableName}";

                using (SQLiteCommand command = new SQLiteCommand(commandText,connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            for(int i =0; i < reader.FieldCount;i++)
                            {
                                extractedData.Add(reader.GetValue(i));
                            }
                        }
                        

                    }    
                }    

                connection.Close();
            }


            return extractedData;
        }
    }
}
