using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.DB_classes
{
    internal abstract class Value:DbTable
    {
        protected readonly Exception valueError;

        public Value()
        {
            valueError = new Exception("Invalid data from table!");
        }
    }
}
