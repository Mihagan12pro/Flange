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


    //class Point2D
    //{
    //    public readonly double X, Y;

    //    public Point2D(double _X,double _Y)
    //    {
    //        X = _X;
    //        Y = _Y;
    //    }
    //}

    //class Point3D : Point2D
    //{
    //    public readonly double Z;
    //    public Point3D(double _X, double _Y, double _Z) : base(_X, _Y)
    //    {
    //        Z = _Z;
    //    }
    //}

    abstract class KompasEntity
    {
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
        protected readonly ksEntity iSketch;
        protected  ksSketchDefinition iSketchDef;
        protected readonly ksEntity plane;
        public Sketch(ksPart iPart,ksEntity plane):base (iPart)
        {
           

            iSketch = (ksEntity)iPart.NewEntity(5);

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
}
