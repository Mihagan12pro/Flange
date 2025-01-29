using Flange.Model.Kompas;
using Kompas6API5;
using Kompas6Constants3D;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Flange.Model.Kompas.Entities
{
    class Sketch : KompasEntity
    {
        protected ksDocument2D doc2D;
        protected ksSketchDefinition iSketchDef;
        protected readonly ksEntity plane;
        protected readonly ksEntity iSketch;
        public ksEntity ISketch
        {
            get
            {
                return iSketch;
            }
        }

        public Sketch(ksPart iPart, ksEntity plane) : base(iPart)
        {
            id = 5;

            iSketch = (ksEntity)iPart.NewEntity(id);

            this.plane = plane;

            iSketchDef = (ksSketchDefinition)iSketch.GetDefinition();

            iSketchDef.SetPlane(plane);

            iSketch.Create();

            doc2D = iSketchDef.BeginEdit();
        }

        public void CreateSketch()
        {
            iSketchDef.EndEdit();
        }

        public void Line(Point point1, Point point2)
        {
            doc2D.ksLineSeg(point1.X, point1.Y, point2.X, point2.Y, 1);
        }
        public void CenterLine(Point point1, Point point2)//Осевая линия
        {
            doc2D.ksLineSeg(2 * point1.X, point1.Y, point2.X, point2.Y, 3);
        }

        public void CenterCircle(Point center, double diameter)
        {
            doc2D.ksCircle(center.X, center.Y, diameter / 2, 3);
        }
        public void Circle(Point center, double diameter)
        {
            doc2D.ksCircle(center.X, center.Y, diameter / 2, 1);
        }
    }
}
