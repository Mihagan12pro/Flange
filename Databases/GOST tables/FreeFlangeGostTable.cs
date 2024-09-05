using Flange.Databases.GOST_tables.GOST_data_classes;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flange.Databases.GOST_tables
{
    internal class FreeFlangeGostTable : AbstractGostTable
    {
        public FreeFlangeGostTable()
        {
            tableName = "free_flange";
            AddElementsToDataList();
        }
        protected override void AddElementsToDataList()
        {
            //DataGridTextColumn columnD = new DataGridTextColumn();
            //columnD.Header = "D";

            //DataGridTextColumn columnD1 = new DataGridTextColumn();
            //columnD1.Header = "D1";

            //DataGridTextColumn columnD2 = new DataGridTextColumn();
            //columnD2.Header = "D2";

            //DataGridTextColumn columnN = new DataGridTextColumn();
            //columnN.Header = "N";


            connection = new SQLiteConnection(database);

            connection.Open();

            command = new SQLiteCommand(connection);

            command.CommandText = $"SELECT * FROM {tableName}";

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    GostDataFreeFlange gostData = new GostDataFreeFlange(reader.GetDouble(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetInt32(3));

                    gostDataCollection.Add(gostData);
                }
            }
            connection.Close();
        }
    }
}
