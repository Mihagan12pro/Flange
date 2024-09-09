using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Flange.Databases.Classes.Standart
{
    internal class StandartFreeFlange : Standart
    {
        private readonly string tableName;
        public StandartFreeFlange()
        {
            tableName = "free_flange";

            Data = new string[4,13];

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
                            Data[0, rowIndex] = dataReader.GetValue(0).ToString();
                            Data[1, rowIndex] = dataReader.GetValue(1).ToString();
                            Data[2, rowIndex] = dataReader.GetValue(2).ToString();
                            Data[3, rowIndex] = dataReader.GetValue(3).ToString();

                            rowIndex++;
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
