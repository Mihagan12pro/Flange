using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Flange.Model;

using Flange.Other;
namespace Flange.Databases
{
    internal class SizesSimpleFlange : SizesDatabase
    {
        protected readonly string simple_sizesTable;
        public readonly string Db;
        public SizesSimpleFlange()
        {

            simple_sizesTable = "simple_sizes";

            Db = GetDefaultData(simple_sizesTable)[0].ToString();
        }

    }
}
