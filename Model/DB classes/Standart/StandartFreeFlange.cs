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
    internal class StandartFreeFlange : Standart
    {
        private readonly string tableName;
        public StandartFreeFlange()
        {
            database = MainExplorer.DataBaseExpl.StandartSizesFullName;

            tableName = "free_flange";

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
                    command.CommandText = $"SELECT * FROM free_flange";

                    using (SQLiteDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {



                            Data.Add(new DataStorage(4)
                            {
                                D = dataReader.GetValue(0).ToString(),
                                D1 = dataReader.GetValue(1).ToString(),
                                D2 = dataReader.GetValue(2).ToString(),
                                N = dataReader.GetValue(3).ToString()
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
