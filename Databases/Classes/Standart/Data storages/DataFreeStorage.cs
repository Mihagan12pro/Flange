using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Databases.Classes.Standart.Data_storages
{
    internal class DataFreeStorage : DataStorage
    {
        public DataFreeStorage(string D,string D1,string D2,string N)
        {
            this.D = D;
            this.D1 = D1;
            this.D2 = D2;
            this.N = N;
        }
    }
}
