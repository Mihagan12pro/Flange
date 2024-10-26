using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes.Sizes
{
    internal interface IDefaultSizesDb
    {
         protected internal List<object> GetDefaultData(string table);
    }
}
