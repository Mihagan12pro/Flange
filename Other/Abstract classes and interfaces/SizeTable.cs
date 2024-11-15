using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Other.Abstract_classes_and_interfaces
{
    public abstract class SizeTable: Notify
    {
        protected string tableName, dbName;

        protected abstract List<object> ExtractData();
    }
}
