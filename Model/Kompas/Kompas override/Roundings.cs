using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Windows.Media.Media3D;
using System.Windows;

namespace Flange.Model.Kompas.Kompas_override
{
    public abstract class Rounding : KompasEntity, ICopy
    {
        protected ksEntityCollection partCollection;
        protected Point3D point;

        public Rounding(ksPart iPart,Point3D point) : base(iPart)
        {
            this.point = point;

            partCollection = iPart.EntityCollection((short)Obj3dType.o3d_edge);
        }

        public ksEntity GetKsEntity()
        {
            throw new NotImplementedException();
        }

    }

    public class Fillet : Rounding
    {
        private entity fillet;
        private ksFilletDefinition filletDef;
        private ksEntityCollection filletCollection;
        public Fillet(ksPart iPart, Point3D point,FilletSizes filletSizes) : base(iPart, point)
        {
            fillet = iPart.NewEntity((short)Obj3dType.o3d_fillet);
            filletDef = fillet.GetDefinition();
            filletDef.radius = filletSizes.Radius;
           
            filletCollection = filletDef.array();
            filletCollection.Clear();
        }
        public void AddFillet()
        {
            partCollection.SelectByPoint(point.X, point.Y, point.Z);

            var selectedPoint = partCollection.GetByIndex(0);

            if (selectedPoint == null)
            {
                MessageBox.Show("Не удалось найти точку!", "Ошибка построения фаски!");
                return;
            }

            filletCollection.Add(selectedPoint);

            fillet.Create();
        }

        public new ksEntity GetKsEntity()
        {
            return fillet;
        }
    }


    public class Chamfer : Rounding
    {
        private double length1, length2;

        private entity chamfer;
        private ksChamferDefinition chamferDef;
        private EntityCollection chamferCollection;
        public Chamfer(ksPart iPart,Point3D point, ChamferSizes chamferSizes) : base(iPart,point)
        {
            double angle = chamferSizes.Angle;
            length1 = chamferSizes.Lenght;

            if (angle == 45)
            {
                length2 = length1;
            }
            else
            {
                angle = (angle * Math.PI) / 180;

                length2 = length1 / (Math.Cos(angle) / Math.Sin(angle));
            }

            chamfer = iPart.NewEntity((short)Obj3dType.o3d_chamfer);
            chamferDef = chamfer.GetDefinition();
            chamferDef.SetChamferParam(true,length1,length2);

            chamferCollection =  chamferDef.array();
            chamferCollection.Clear();
        }

        public void AddChamfer()
        {
            partCollection.SelectByPoint(point.X,point.Y,point.Z);

            var selectedPoint = partCollection.GetByIndex(0);

            if (selectedPoint == null)
            {
                MessageBox.Show("Не удалось найти точку!", "Ошибка построения фаски!");
                return;
            }

            chamferCollection.Add(selectedPoint);
        
            chamfer.Create();
        }

        public new ksEntity GetKsEntity()
        {
            return chamfer;
        }
    }
}
