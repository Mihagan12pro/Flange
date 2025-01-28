﻿
using KompasAPI7;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Kompas6Constants;

using System;
using System.Collections.Generic;
using Kompas6API5;
using Kompas6Constants3D;
using System.Runtime.InteropServices;
namespace Flange.Kompas.Modeling
{
    internal abstract class AbstractFlange
    {
        protected  ksDocument3D iDocument3D;

    
        protected ksDocument2D iDocument2D;

        protected  KompasObject Kompas;
        protected ksPart iPart;

        protected  ksEntity planeXOZ,planeXOY,planeZOY,planeOffsetXOY;

        protected entity iSketch1, iSketch2;
        protected SketchDefinition iSketch1Definition, iSketch2Definition;

        protected entity iBossRotation1;
        protected entity iCutExtrusion1;
        protected BossRotatedDefinition iBossRotation1Definition;
       // protected CutRotatedDefinition iCutRotation1Definition;

        protected ksEntity iCircularArray;
        protected ksCircularCopyDefinition  iCircularArrayDefinition;

        protected double d, d1, d2,  h;
        protected int countOfHoles;
        protected List<string> paramsList = new List<string>();


        protected struct Lines
        {
            public readonly double Angle1;
            public readonly double Angle2;
            public readonly double Line1;

            public Lines(double line1,double angle)
            {
                Angle1 = angle;
                Line1 = line1;

                Angle2 = 90 - Angle1;
            }

            
        
            public double Line2
            {
                get
                {
                    return (Math.Sin(Angle2) * Line1) / Math.Sin(Angle2);
                }
            }
        }


        public AbstractFlange()
        {
           
            
           
        }

        public virtual void Build()
        {
            try
            { 
                Kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                Kompas.Visible = true;
            }
            catch(Exception e)
            {
                if (Kompas == null)
                {
                    if (Kompas == null)
                    {
                        var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                        Kompas = (KompasObject)Activator.CreateInstance(type);
                    }

                    if (Kompas != null)
                    {
                        Kompas.Visible = true;
                        Kompas.ActivateControllerAPI();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка подключения к программе КОМПАС-3D!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            
           
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
        private void CreateNewDocument()
        {
            iDocument3D = (ksDocument3D)Kompas.Document3D();
            iDocument3D.Create(false, true);
        }




        protected  void Sketch1()
        {
            iSketch1  = (entity)iPart.NewEntity(5);
            iSketch1Definition = (SketchDefinition)iSketch1.GetDefinition();

            iSketch1Definition.SetPlane(planeXOZ);

            iSketch1.Create();

            iDocument2D = iSketch1Definition.BeginEdit();

            iDocument2D.ksLineSeg(0,0,0,h,1);
            iDocument2D.ksLineSeg(0,h,d / 2,h,1);
            iDocument2D.ksLineSeg(d/2,h,d / 2,0,1);
            iDocument2D.ksLineSeg(0,0,d / 2,0,1);

            iDocument2D.ksLineSeg(0, 0, 0, 100, 3);

            iSketch1Definition.EndEdit();
        }
        protected void Sketch2()
        {
            ksPlaneOffsetDefinition planeOffsetDefinition = (ksPlaneOffsetDefinition)planeOffsetXOY.GetDefinition();

            planeOffsetDefinition.SetPlane(planeXOY);
            planeOffsetDefinition.direction = false;
            planeOffsetDefinition.offset = h;

            planeOffsetXOY.Create();


            iSketch2 = (entity)iPart.NewEntity(5);
            iSketch2Definition = (SketchDefinition)iSketch2.GetDefinition();

            iSketch2Definition.SetPlane(planeOffsetXOY);

            iSketch2.Create();

            iDocument2D = iSketch2Definition.BeginEdit();

            iDocument2D.ksCircle(d1/2,0,d2/2,1);


            iSketch2Definition.EndEdit();

        }
        protected  void BossRotation1()
        {


       
            iBossRotation1 = (entity)iPart.NewEntity((short)Obj3dType.o3d_bossRotated);

            iBossRotation1Definition = (BossRotatedDefinition)iBossRotation1.GetDefinition();



            iBossRotation1Definition.SetThinParam(false, (short)Direction_Type.dtBoth, 1, 1);   // тонкая стенка в два направления
            iBossRotation1Definition.SetSideParam(true, 360);
            iBossRotation1Definition.SetSketch(iSketch1); 

            iBossRotation1.Create();
        }
        protected void CutExtrusion1()
        {

            iCutExtrusion1 = (entity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);

            CutExtrusionDefinition iCutExtrusion1Definition = (CutExtrusionDefinition)iCutExtrusion1.GetDefinition();

            iCutExtrusion1Definition.SetSketch(iSketch2);
            iCutExtrusion1Definition.SetSideParam(false,(short)Direction_Type.dtNormal,h,1);

            iCutExtrusion1.Create();





        }
        protected void CircularArray1()
        {
         
            iCircularArray = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_circularCopy);
            iCircularArrayDefinition = (ksCircularCopyDefinition)iCircularArray.GetDefinition();

        
            ksEntity iAxis = iPart.NewEntity((short)Obj3dType.o3d_axis2Planes);
            Axis2PlanesDefinition iAxisDefinition = (Axis2PlanesDefinition)iAxis.GetDefinition();
            iAxisDefinition.SetPlane(1, planeZOY);
            iAxisDefinition.SetPlane(2, planeXOZ);
            iAxis.Create();

            iCircularArrayDefinition.SetAxis(iAxis);
            iCircularArrayDefinition.SetCopyParamAlongDir(countOfHoles,360,true,false);
         


            ksEntityCollection entityCollection = (ksEntityCollection)iCircularArrayDefinition.GetOperationArray();
            entityCollection.Clear();
            entityCollection.Add(iCutExtrusion1); 

            
            iCircularArray.Create();
        }

    }
}

