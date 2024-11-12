using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathExplorerLibrary;
using System.Data.SQLite;
using Flange.Other.Explorers.Master;
namespace Flange.Other
{

    internal class DataBaseExplorer : Explorer
    {
        private readonly DataBaseMaster defaultSizes,standartSizes;
       
    
        public DataBaseMaster DefaultSizes
        {
            get
            {
                return defaultSizes;
            }
        }
        public DataBaseMaster StandartSizes
        {
            get
            {
                return standartSizes;
            }
        }
        public DataBaseExplorer(DataBaseMaster defaultSizes,DataBaseMaster standartSizes):base(defaultSizes)
        {
            this.defaultSizes = defaultSizes;
            this.standartSizes = standartSizes;
        }
    }
}
