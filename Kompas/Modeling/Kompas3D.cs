using Kompas6API5;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Kompas.Modeling
{
    internal class Kompas3D : Kompas
    {


        private ksDocument3D document3d;
        public ksDocument3D Document3D
        {
            get
            {
                return document3d;
            }
            set
            {
                document3d = value;
            }
        }


        public Kompas3D(KompasObject kompasObject):base(kompasObject)
        {
            
        }


    }
}
