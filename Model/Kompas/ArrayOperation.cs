using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
namespace Flange.Model.Kompas.Entities
{
    class ArrayOperation<T> : KompasEntity, ICopy where T : ICopy
    {
        protected List<ICopy> copies;

        public T Add
        {
            set
            {
                copies.Add(value);
            }
        }
        public ArrayOperation(ksPart iPart) : base(iPart)
        {

        }
    }

    class CircularCopy<T> : ArrayOperation<T> where T : ICopy
    {
        public CircularCopy(ksPart iPart) : base(iPart)
        {

        }
    }
}
