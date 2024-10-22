using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Databases.Classes.Standart.Data_storages
{


    internal abstract class DataStorage
    {
        //public readonly int ColumnsCount;
        public string D { get; set; } = "";
        public string D1 { get; set; } = "";
        public string D2 { get; set; } = "";
        public string N { get; set; } = "";
        


        public DataStorage()
        {
           // ColumnsCount = columnsCount;
        }

    }
    internal class DataStorageSimpleFree : DataStorage
    {
        public string Db { get; set; } = "";
    }
}
