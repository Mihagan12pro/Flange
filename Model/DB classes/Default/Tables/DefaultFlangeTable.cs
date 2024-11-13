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
    internal abstract class DefaultFlangeTable: SizeTable
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

            D = Convert.ToDouble(ExtractData()[0]);
            H = Convert.ToDouble(ExtractData()[1]);
        }


        protected override List<object> ExtractData()
        {
            List<object> extractedData = new List<object>();

            using (SQLiteConnection connection = new SQLiteConnection(dbName))
            {
                connection.Open();

                string commandText = $"SELECT * FROM {tableName}";

                using (SQLiteCommand command = new SQLiteCommand(commandText))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        int n = -1;
                        while (reader.Read())
                        {
                            n++;
                            extractedData.Add(reader.GetValue(n));
                        }
                    }    
                }    

                connection.Close();
            }


            return extractedData;
        }
    }
}
