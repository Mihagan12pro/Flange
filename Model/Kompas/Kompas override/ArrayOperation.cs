using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flange.Model.Kompas.Kompas_override;
using Kompas6API5;
using Kompas6Constants3D;
namespace Flange.Model.Kompas.Kompas_override
{
    abstract class ArrayOperation : KompasEntity
    {
        protected List<ICopy> copies = new List<ICopy>();
        protected ksEntityCollection entityCollection;
        protected int count = 1;

        public void Add(ICopy value)
        {
            copies.Add(value);
        }

        public virtual void Copy()
        {
            //foreach (ICopy copy in copies)
            //{
            //    entityCollection.Add(copy.GetKsEntity());
            //}
            for (int i = 0; i < copies.Count; i++)
            {
              
                    entityCollection.Add(copies[i].GetKsEntity());
                
              
            }
        }

        public ksEntity GetKsEntity()
        {
            throw new NotImplementedException();
        }

        public ArrayOperation(ksPart iPart, int count) : base(iPart)
        {
            this.count = count;
        }
    }

    class CircularCopy<A> : ArrayOperation where A : AbstractAxis
    {
        protected entity circularCopy;
        protected ksCircularCopyDefinition circularCopyDef;
        protected double angle;
        public CircularCopy(ksPart iPart, int count,A axis, double angle) : base(iPart, count)
        {
            circularCopy = iPart.NewEntity((short)Obj3dType.o3d_circularCopy);
            this.angle = angle;

            circularCopyDef = circularCopy.GetDefinition();
            //circularCopyDef.count1 = count;
            circularCopyDef.SetAxis(axis.Axis);
            circularCopyDef.SetCopyParamAlongDir(count, angle, true,false);

            entityCollection = circularCopyDef.GetOperationArray();
            entityCollection.Clear();
        }

        public new ksEntity GetKsEntity()
        {
            return circularCopy;
        }

        public override void Copy()
        {
            base.Copy();
           
            circularCopy.Create();
        }
    }
}
