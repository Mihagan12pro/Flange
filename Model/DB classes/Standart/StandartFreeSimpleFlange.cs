using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Flange.Databases.Classes.Standart.Data_storages;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

using Flange.Other;
namespace Flange.Databases.Classes.Standart
{
    internal class StandartFreeSimpleFlange : Standart
    {
        private readonly string tableName;
        public StandartFreeSimpleFlange()
        {
            database = MainExplorer.DataBaseExpl.StandartSizesFullName;

            tableName = "simple_and_free_flange";

            Data = new ObservableCollection<DataStorage>();

  

            SelectfromDatabase();
        }

        protected override void SelectfromDatabase()
        {
            int rowIndex = 0;
            using (SQLiteConnection connection = new SQLiteConnection(database))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT * FROM {tableName}";

                    using (SQLiteDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {



                            Data.Add(new DataStorage(5)
                            {
                                D = dataReader.GetValue(0).ToString(),
                                D1 = dataReader.GetValue(1).ToString(),
                                D2 = dataReader.GetValue(2).ToString(),
                                N = dataReader.GetValue(3).ToString(),
                                Db = dataReader.GetValue(4).ToString()
                            });

                            rowIndex++;
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
