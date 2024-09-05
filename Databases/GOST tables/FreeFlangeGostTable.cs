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
        public FreeFlangeGostTable(MainWindow window):base(window)
        {
            tableName = "free_flange";
            AddElementsToDataList();
        }
        protected override void AddElementsToDataList()
        {



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

            GridTable.Columns.Add(new DataGridTextColumn
            {
                Header = "D",
                Binding = new System.Windows.Data.Binding("D")
            });

            GridTable.Columns.Add(new DataGridTextColumn
            {
                Header = "D1",
                Binding = new System.Windows.Data.Binding("D1")
            });

            GridTable.Columns.Add(new DataGridTextColumn
            {
                Header = "D2",
                Binding = new System.Windows.Data.Binding("D2")
            });

            GridTable.Columns.Add(new DataGridTextColumn
            {
                Header = "N",
                Binding = new System.Windows.Data.Binding("CountOfHoles")
            });

            GridTable.ItemsSource = gostDataCollection;
        }
    }
}
