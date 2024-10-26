using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Flange.Model;

using Flange.Other;
using Flange.Model.DB_classes.Sizes;
namespace Flange.Databases
{
    internal class DefaultFreeFlangeDb : DefaultSizesDb
    {
        protected readonly string simple_sizesTable;
        public readonly string Db;
        public DefaultFreeFlangeDb()
        {

            simple_sizesTable = "simple_sizes";

            var values = GetDefaultData(simple_sizesTable);

            Db = values[0].ToString();


        }

    }
}
