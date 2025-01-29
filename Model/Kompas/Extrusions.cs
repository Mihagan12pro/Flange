using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
namespace Flange.Model.Kompas.Entities
{
    class BossRotation : KompasEntity, ICopy
    {
        private double angle;
        private bool direction;
        private Sketch sketch;
        private entity rotate;
        public BossRotation(ksPart iPart, Sketch sketch, double angle, bool direction) : base(iPart)
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
            rotatedDefinition.SetSideParam(direction, angle);

            rotate.Create();
        }
    }

    class CutExtrusion : KompasEntity, ICopy
    {
        private Sketch sketch;
        private entity cutExtrusion;
        private ksCutExtrusionDefinition cutExtrusionDef;
        private Direction_Type direction;
        private End_Type howExtrude;
        private double depthOfExtrusion;

        public CutExtrusion(ksPart iPart, Sketch sketch, Direction_Type direction, End_Type howExtrude) : base(iPart)
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
            cutExtrusionDef.SetSideParam(true, (short)howExtrude, depthOfExtrusion, 0, false);

            cutExtrusion.Create();
        }
    }
}
