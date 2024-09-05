using Flange.Databases.GOST_tables.GOST_data_classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Flange.Databases.GOST_tables
{
    internal abstract class AbstractGostTable : IDisposable
    {
        protected const string database = $"Data Source=..\\..\\Databases\\DBs\\gost sizes.db";

        protected string tableName;

        protected SQLiteConnection connection;
        protected SQLiteCommand command;

        //protected readonly int rowCount;


        protected ObservableCollection<GostData> gostDataCollection = new ObservableCollection<GostData>();

        private AbstractGostTable gostTableClass;

        public DataGrid GridTable { get; private set; } = new DataGrid();


      
        public void Dispose()
        {
            //GridTable = null;
        }

        protected abstract void AddElementsToDataList();

        public AbstractGostTable()
        {
            GridTable.ItemsSource = gostDataCollection;
            gostTableClass = this;
        }

   
    }
}
