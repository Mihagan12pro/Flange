using Kompas6API5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.Kompas.Kompas_override
{
   
        public class Plane : KompasEntity
        {
            protected StandartPlanes standartPlane;
            public Plane(ksPart iPart, StandartPlanes standartPlane) : base(iPart)
            {
                this.standartPlane = standartPlane;
            }

            public ksEntity GetPlane()
            {
                return (ksEntity)iPart.GetDefaultEntity((short)standartPlane);
            }
        
        }
}
