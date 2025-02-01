using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using Kompas6API5;
using Kompas6Constants3D;
namespace Flange.Model.Kompas.Kompas_override
{
    public enum StandartPlanes
    {
        XOZ = (short)Obj3dType.o3d_planeXOZ,
        XOY = (short)Obj3dType.o3d_planeXOY,
        YOZ = (short)Obj3dType.o3d_planeYOZ,
    }

    


    public abstract class KompasEntity
    {
        protected short id;
        protected readonly ksPart iPart;
        public KompasEntity(ksPart iPart)
        {
            this.iPart = iPart;
        }
    }
}
