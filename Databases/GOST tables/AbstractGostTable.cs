using Flange.Databases.GOST_tables.GOST_data_classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flange.Databases.GOST_tables
{
    internal abstract class AbstractGostTable
    {
        protected const string database = " $\"Data Source={@\"..\\..\\Databases\\DBs\\gost sizes.db\"}\";";

        protected readonly string tableName;

        protected readonly int rowCount;

       
        protected ObservableCollection<GostData> gostDataCollection = new ObservableCollection<GostData>();

       

        public DataGrid GridTable { get; private set; } = new DataGrid();

        
        private void DestructGridTable()
        {
            GridTable = null; 
        }

        protected abstract void AddElementsToDataList();


        public AbstractGostTable()
        {
            GridTable.ItemsSource = gostDataCollection;
        }
    }
}
