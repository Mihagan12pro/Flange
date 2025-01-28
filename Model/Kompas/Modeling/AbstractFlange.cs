using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Kompas6Constants;
using System.Windows.Media.Media3D;
using System;
using System.Collections.Generic;
using Kompas6API5;
using Kompas6Constants3D;
using System.Runtime.InteropServices;
using Flange.Model.Kompas.Entities;
using Flange.Model.Kompas;
namespace Flange.Kompas.Modeling
{
    internal abstract class AbstractFlange: FlangeDocument
    {
        protected  ksDocument3D iDocument3D;

    
        protected ksDocument2D iDocument2D;


        
        protected ksPart iPart;

        protected Plane planeXOY, planeXOZ, planeYOZ;
        protected Sketch sketch1;
        //protected Plane

        //protected  ksEntity planeXOZ,planeXOY,planeZOY,planeOffsetXOY;

        // protected entity iSketch1, iSketch2;
        // protected SketchDefinition iSketch1Definition, iSketch2Definition;

        // protected entity iBossRotation1;
        // protected entity iCutExtrusion1;
        // protected BossRotatedDefinition iBossRotation1Definition;
        //// protected CutRotatedDefinition iCutRotation1Definition;

        // protected ksEntity iCircularArray;
        // protected ksCircularCopyDefinition  iCircularArrayDefinition;

        //protected double d, d1, d2,  h;
        //protected int countOfHoles;
        //protected List<string> paramsList = new List<string>();


        //protected struct Lines
        //{
        //    public readonly double Angle1;
        //    public readonly double Angle2;
        //    public readonly double Line1;

        //    public Lines(double line1,double angle)
        //    {
        //        Angle1 = angle;
        //        Line1 = line1;

        //        Angle2 = 90 - Angle1;
        //    }



        //    public double Line2
        //    {
        //        get
        //        {
        //            return (Math.Sin(Angle2) * Line1) / Math.Sin(Angle2);
        //        }
        //    }
        //}

        protected double D, H;

        public AbstractFlange(double _D,double _H)
        {
            D = _D;
            H = _H;
        }

        public override void Build()
        {
            base.Build();

            iDocument3D = (ksDocument3D)Kompas.Document3D();
            iDocument3D.Create(false, true);

            iPart = (part)iDocument3D.GetPart(-1);

            planeXOY = new Plane(iPart,StandartPlanes.XOY);
            planeXOZ = new Plane(iPart, StandartPlanes.XOZ);
            planeYOZ = new Plane(iPart, StandartPlanes.YOZ);

            Sketch1();
           
            //if (kompas == null)
            //{
            //    //Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
            //    //kompas = (KompasObject)Activator.CreateInstance(t);
            //    OpenKompas();
            //}

            //try
            //{
            //    //if (kompas != null)
            //    //{
            //    //    kompas.Visible = true;
            //    //    kompas.ActivateControllerAPI();
            //    //}
            //    //if (kompas != null)
            //    //{
            //    //    iDocument3D = (ksDocument3D)kompas.Document3D();
            //    //    iDocument3D.Create(false, true);
            //    //}
            //    CreateDocument();
            //}
            //catch
            //{
            //    OpenKompas();
            //    CreateDocument();
            //}

            //OpenKompas3D();

            //try
            //{
            //    CreateNewDocument();
            //}
            //catch
            //{
            //    kompas = null;
            //    OpenKompas3D();
            //    CreateNewDocument();
            //}
            //    iPart = (part)iDocument3D.GetPart(-1);

            //planeXOZ = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            //planeZOY = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            //planeXOY = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            //planeOffsetXOY = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_planeOffset);

            //Sketch1();
            //BossRotation1();
            //Sketch2();
            //CutExtrusion1();
            //CircularArray1();
        }
        //private void OpenKompas3D()
        //{
        //    if (kompas == null)
        //    {
        //        kompas = new Kompas6API5.Application();
        //        kompas.Visible = true;
        //    }
        //}
       




        protected virtual void Sketch1()
        {
            sketch1 = new Sketch(iPart,planeXOY.GetPlane());

            Point rightBottomPoint = new Point(0,-H/2);
            Point rightTopPoint = new Point(0,H/2);

            Point leftBottomPoint = new Point(D/2,-H/2);
            Point leftTopPoint = new Point(D/2,H/2);

            sketch1.Line(rightTopPoint,rightBottomPoint);
            sketch1.Line(rightTopPoint,leftTopPoint);
            sketch1.Line(leftTopPoint,leftBottomPoint);
            sketch1.Line(leftBottomPoint,rightBottomPoint);

            sketch1.CenterLine(rightBottomPoint,rightTopPoint);

            sketch1.EndEditingSketch();
        }
        //protected void Sketch2()
        //{
        //    ksPlaneOffsetDefinition planeOffsetDefinition = (ksPlaneOffsetDefinition)planeOffsetXOY.GetDefinition();

        //    planeOffsetDefinition.SetPlane(planeXOY);
        //    planeOffsetDefinition.direction = false;
        //    planeOffsetDefinition.offset = h;

        //    planeOffsetXOY.Create();


        //    iSketch2 = (entity)iPart.NewEntity(5);
        //    iSketch2Definition = (SketchDefinition)iSketch2.GetDefinition();

        //    iSketch2Definition.SetPlane(planeOffsetXOY);

        //    iSketch2.Create();

        //    iDocument2D = iSketch2Definition.BeginEdit();

        //    iDocument2D.ksCircle(d1/2,0,d2/2,1);


        //    iSketch2Definition.EndEdit();

        //}
        //protected  void BossRotation1()
        //{


       
        //    iBossRotation1 = (entity)iPart.NewEntity((short)Obj3dType.o3d_bossRotated);

        //    iBossRotation1Definition = (BossRotatedDefinition)iBossRotation1.GetDefinition();



        //    iBossRotation1Definition.SetThinParam(false, (short)Direction_Type.dtBoth, 1, 1);   // тонкая стенка в два направления
        //    iBossRotation1Definition.SetSideParam(true, 360);
        //    iBossRotation1Definition.SetSketch(iSketch1); 

        //    iBossRotation1.Create();
        //}
        //protected void CutExtrusion1()
        //{

        //    iCutExtrusion1 = (entity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);

        //    CutExtrusionDefinition iCutExtrusion1Definition = (CutExtrusionDefinition)iCutExtrusion1.GetDefinition();

        //    iCutExtrusion1Definition.SetSketch(iSketch2);
        //    iCutExtrusion1Definition.SetSideParam(false,(short)Direction_Type.dtNormal,h,1);

        //    iCutExtrusion1.Create();





        //}
        //protected void CircularArray1()
        //{
         
        //    iCircularArray = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_circularCopy);
        //    iCircularArrayDefinition = (ksCircularCopyDefinition)iCircularArray.GetDefinition();

        
        //    ksEntity iAxis = iPart.NewEntity((short)Obj3dType.o3d_axis2Planes);
        //    Axis2PlanesDefinition iAxisDefinition = (Axis2PlanesDefinition)iAxis.GetDefinition();
        //    iAxisDefinition.SetPlane(1, planeZOY);
        //    iAxisDefinition.SetPlane(2, planeXOZ);
        //    iAxis.Create();

        //    iCircularArrayDefinition.SetAxis(iAxis);
        //    iCircularArrayDefinition.SetCopyParamAlongDir(countOfHoles,360,true,false);
         


        //    ksEntityCollection entityCollection = (ksEntityCollection)iCircularArrayDefinition.GetOperationArray();
        //    entityCollection.Clear();
        //    entityCollection.Add(iCutExtrusion1); 

            
        //    iCircularArray.Create();
        //}

    }
}

