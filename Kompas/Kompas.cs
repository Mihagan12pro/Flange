using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kompas6API5;
namespace Flange.Kompas
{
    internal abstract class Kompas
    {
        protected KompasObject kompasObject;
        public KompasObject KompasObject
        {
            get
            {
                return kompasObject;
            }
            set
            {
                kompasObject = value;
            }
        }



    }
}
