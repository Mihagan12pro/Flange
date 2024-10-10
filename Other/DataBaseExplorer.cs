using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PathExplorerLibrary;
namespace Flange.Other
{
    class TableLocation : PathMaster
    {
        public readonly string DataBaseName, TableName;
        public TableLocation(string _FileName, string _FolderName, string tableName) : base(_FileName, _FolderName)
        {

        }
    }
    internal class DataBaseExplorer : Explorer
    {
        public DataBaseExplorer(PathMaster defaultSizes):base(defaultSizes)
        {
            
        }
    }
}
