using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
namespace Flange.Model.Kompas.Entities
{
    enum StandartPlanes
    {
        XOZ = (short)Obj3dType.o3d_planeXOZ,
        XOY = (short)Obj3dType.o3d_planeXOY,
        YOZ = (short)Obj3dType.o3d_planeYOZ,
    }

    

    abstract class KompasEntity
    {
        protected short id;
        protected readonly ksPart iPart;
        public KompasEntity(ksPart iPart)
        {
            this.iPart = iPart;
        }
    }

    class Plane : KompasEntity
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


    class Sketch: KompasEntity
    {
        protected ksDocument2D doc2D;
        protected  ksSketchDefinition iSketchDef;
        protected readonly ksEntity plane;
        protected readonly ksEntity iSketch;
        public ksEntity ISketch
        {
            get
            {
                return iSketch;
            }
        }

        public Sketch(ksPart iPart,ksEntity plane):base (iPart)
        {
            id = 5;

            iSketch = (ksEntity)iPart.NewEntity(id);

            this.plane = plane;

            iSketchDef = (ksSketchDefinition)iSketch.GetDefinition();

            iSketchDef.SetPlane(plane);

            iSketch.Create();

            doc2D = iSketchDef.BeginEdit();
        }

        public void EndEditingSketch()
        {
            iSketchDef.EndEdit();
        }

        public void Line(Point point1,Point point2)
        {
            doc2D.ksLineSeg(point1.X,point1.Y,point2.X,point2.Y,1);
        }
        public void CenterLine(Point point1,Point point2)//Осевая линия
        {
            doc2D.ksLineSeg(2*point1.X, point1.Y, point2.X, point2.Y, 3);
        }
        public void Circle(Point center,double diameter)
        {
            doc2D.ksCircle(center.X,center.Y, diameter,1);
        }
    }

    class BossRotation : KompasEntity
    {
        private double angle;
        private bool direction;
        private Sketch sketch;
        private entity rotate;
        public BossRotation(ksPart iPart,Sketch sketch,double angle,bool direction) : base(iPart)
        {
            this.sketch = sketch;
            this.direction = direction;
            this.angle = angle;
            id = 25;
        }

        public void Rotate()
        {
            rotate = (entity)iPart.NewEntity((short)Obj3dType.o3d_bossRotated);
            ksBossRotatedDefinition rotatedDefinition = (ksBossRotatedDefinition)rotate.GetDefinition();

            rotatedDefinition.SetSketch(sketch.ISketch);
            rotatedDefinition.SetSideParam(direction,angle);

            rotate.Create();
        }
    }

    class CutExtrusion : KompasEntity
    {
        private Sketch sketch;
        private entity cutExtrusion;
        private ksCutExtrusionDefinition cutExtrusionDef;
        private Direction_Type direction;
        private End_Type howExtrude;
        private double depthOfExtrusion;

        public CutExtrusion(ksPart iPart,Sketch sketch,Direction_Type direction,End_Type howExtrude) : base(iPart)
        {
            this.sketch = sketch;
            this.direction = direction;
            this.howExtrude = howExtrude;
        }

        public void Cut()
        {
            cutExtrusion = (entity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            cutExtrusionDef = (ksCutExtrusionDefinition)cutExtrusion.GetDefinition();

            cutExtrusionDef.directionType = (short)direction;
            cutExtrusionDef.SetSketch(sketch.ISketch);
            cutExtrusionDef.SetSideParam(true,(short)howExtrude,depthOfExtrusion,0,false);

            cutExtrusion.Create();
        }
    }
}
