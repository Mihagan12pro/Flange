using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model.Kompas.Kompas_override
{
    internal abstract class AbstractAxis : KompasEntity
    {
        public readonly entity AxisOX, AxisOY, AxisOZ;

        protected entity axis;
        public entity Axis
        {
            get
            {
                return axis;
            }
            protected set
            {
                axis = value;
            }
        }

        public virtual void CreateAxis()
        {
            axis.Create();
        }

        public AbstractAxis(ksPart iPart) : base(iPart)
        {
            AxisOX = iPart.NewEntity((short)Obj3dType.o3d_axisOX);
            AxisOY = iPart.NewEntity((short)Obj3dType.o3d_axisOY);
            AxisOZ = iPart.NewEntity((short)Obj3dType.o3d_axisOZ);
        }
    }



    internal class AxisByTwoPlanes : AbstractAxis
    {
        private Plane plane1, plane2;
        private ksAxis2PlanesDefinition axis2PlanesDef;
        public AxisByTwoPlanes(ksPart iPart, StandartPlanes stadart1,StandartPlanes standart2) : base(iPart)
        {
            plane1 = new Plane(iPart,stadart1);
            plane2 = new Plane(iPart, standart2);
            
        

            Axis = iPart.NewEntity((short)Obj3dType.o3d_axis2Planes);
            axis2PlanesDef = axis.GetDefinition();
        }

        public override void CreateAxis()
        {
            axis2PlanesDef.SetPlane(1,plane1.GetPlane());
            axis2PlanesDef.SetPlane(2, plane2.GetPlane());
            base.CreateAxis();
        }
    }

    //internal class A
}
