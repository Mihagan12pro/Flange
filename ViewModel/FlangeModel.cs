﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using Flange.Databases;
using System.Data.SqlTypes;
using System.Windows.Input;
using Flange.ViewModel;
using Flange.Kompas.Modeling;
using Flange.Databases.Classes.Standart;
//using Flange.Databases.GOST_tables;
//using Flange.Databases.GOST_tables.GOST_data_classes;
using System.Windows.Controls;
using Flange.Other;
using Flange.Databases.Classes.Standart.Data_storages;
using KompasAPI7;
using Flange.ViewModel.Tables;




namespace Flange.Model
{
    public struct TheController
     {
        public readonly int Id;
        public readonly string Value;

        public TheController(int id,string value)
        {
            Value = value;
            Id = id;
        }
    }
    internal class FlangeModel : DependencyObject,INotifyPropertyChanged
    {

        private Table tableData;
        public Table TableData
        {
            private set
            {
                tableData = value;
                OnPropertyChanged();
            }
            get
            {
                return tableData;
            }
        }

        //private string selectFlangeType;
        //private readonly string SimpleFlangeType;

        public  ObservableCollection<string> ModelTypesCollection { get; private set; }

        private BitmapImage bitmapImage;
        private SizesSimpleFlange flangeSizes;


        public ObservableCollection<string> FlangeTittles { get; private set; } 

        public Controller DController { get; private set; }
        public Controller D1Controller { get; private set; }
        public Controller D2Controller { get; private set; }
        public Controller HController { get; private set; }
        public Controller DbController { get; private set; }
        public Controller NConroller { get; private set; }
        public Controller AController { get;private set; }
        public Controller SController {  get; private set; }


        public CanvasOffsetX SketchOffsetX { get;private set; }
        public CanvasOffsetX TableOffsetX { get;private set; }


        public  ModelType Modeltype { get; private set; }


      
   
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

    
        //public int ModelTypeIndex
        //{
        //    get
        //    {
        //        return Modeltype.Type;
        //    }
        //    set
        //    {
        //        Modeltype.Type = value;
               
        //    }
        //}

        //public string ModelTypeTittle
        //{
        //    get
        //    {
        //        return Modeltype.BuildButtonContent;
        //    }
        //}
        public ObservableCollection<string>ModelTypeList
        {
            get
            {
                return Modeltype.AllModels;
            }
        }




        private double windowWith;
        public double WindowWidth
        {
            get
            {
                
                return windowWith;
            }
            private set
            {
                windowWith = value;

                TableWidth = value / 1.5;
                OnPropertyChanged(nameof(TableWidth));
               
            }
        }



        private ObservableCollection<string> flangeModelTypes = new ObservableCollection<string>();
        public ObservableCollection<string>FlangeModelTypes
        {
            get
            {
                return flangeModelTypes;
            }
            private set
            {
                flangeModelTypes = value;

                OnPropertyChanged(nameof(FlangeModelTypes));
            }
        }



        private double tableWidth;
        public double TableWidth
        {
            get
            {
                return tableWidth;
            }
            set
            {
                tableWidth = value;
                OnPropertyChanged(nameof(TableWidth));
            }
        }


        private int tableRowIndex;
        public int TableRowIndex
        {
            get     
            {
                return tableRowIndex;
             } 
            set
            {
                tableRowIndex = value;
            }
        }


        //private ObservableCollection<DataStorage> tableData;
        //public ObservableCollection<DataStorage> TableData
        //{
        //    get
        //    {
        //        return tableData;
        //    }
        //    set
        //    {
        //        tableData = value;


        //        OnPropertyChanged();
        //    }
        //}

        private double columnWidth;
        public double ColumnWidth
        {
            get
            {
                return columnWidth;
            }
            private set
            {
                columnWidth = value;
            }
        }



        private  double sketchCancasLeft;
        public double SketchCanvasLeft
        {
            private set
            {
                sketchCancasLeft = value;
                OnPropertyChanged(nameof(SketchCanvasLeft));

            }
            get
            {
                return sketchCancasLeft;
            }
        }
      

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private Visibility tableVisibility;

        public Visibility TableVisibility
        {
            get
            {
                return tableVisibility; 
            }
            set 
            { 
                tableVisibility = value; 
            }
        }





        private int selectedFlangeType;
        public int SelectedFlangeType
        {
            get
            {
                return selectedFlangeType;
            }

            set 
            {
               
                switch(value)
                {
                    case Constants.SimpleFlange:

                        TableData = new FreeSimpleTable(DController,D1Controller,D2Controller,NConroller,DbController);

                       

                       SizesSimpleFlange simple = new SizesSimpleFlange();
                        Controller.SetControllers(new ObservableCollection<TheController>
                        {
                            new TheController(0, simple.D), new TheController(1,simple.D1),
                            new TheController(2,simple.D2), new TheController(3,simple.H),
                            new TheController(4,simple.Db), new TheController(5,simple.N),
                            new TheController(6,""), new  TheController(7,"")
                        }.ToArray());
                       

                        BitmapImage = new BitmapImage(new Uri( MainExplorer.SketchesExpl.SimpleFlange));
                        break;

                    case Constants.FreeFlange:

                        SizesFreeFlange free = new SizesFreeFlange();

                        Controller.SetControllers(new ObservableCollection<TheController>
                        {
                            new TheController(0, free.D), new TheController(1,free.D1),
                            new TheController(2,free.D2), new TheController(3,free.D2),
                            new TheController(4,free.H), new TheController(5,free.N),
                            new TheController(6,free.A), new  TheController(7,free.S)
                        }.ToArray());

                       
                        BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.FreeFlange));
                        break;

                    case Constants.FlatFlange:
                        BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.FlatFlange));
                        break;
                }
                selectedFlangeType = value;
                OnPropertyChanged();
            }
        }


        private void CreateFlange()
        {
           switch( SelectedFlangeType)
           {
                case 0:

                    SimpleFlange simpleFlange = new SimpleFlange(DController.RowValue, D1Controller.RowValue ,D2Controller.RowValue, HController.RowValue, NConroller.RowValue, DbController.RowValue);
                    simpleFlange.TryToBuild();

                    break;
                case 1:
                    FreeFlange freeFlange = new FreeFlange(DController.RowValue, D1Controller.RowValue, D2Controller.RowValue, HController.RowValue, NConroller.RowValue, DbController.RowValue,AController.RowValue, SController.RowValue);
                    freeFlange.TryToBuild();

                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
           }
        }
        


        public Command BuildFlangeCommand
        {
            get
            {
                return new Command((obj) =>
                {
                    CreateFlange();
                });
            }
        }


        public SizesSimpleFlange FlangeSizes
        {
            private set
            {
                if (value != flangeSizes)
                {
                    flangeSizes = value;
                }
            }
            get
            {
                return flangeSizes;
            }
        }


        public BitmapImage BitmapImage
        {
            get
            {
                return bitmapImage;
            }
            set
            {
                    
                //switch(value)
                //{
                //    case Constants.SimpleFlange:
                //        break;
                //}
                   
                    bitmapImage = value;

                    OnPropertyChanged();
                

            }
        }


        public void UpdateTableWidth(double width)
        {
            TableWidth = width * 0.5;
        }


        private Visibility gridTableVisibility;
        public Visibility GridTableVisibility
        {
            get
            {
                return gridTableVisibility;
            }
            set
            {
                gridTableVisibility= value;
            }
        }


        private void ChangeTextBoxElems(int index)
        {
            //SizesSimpleFlange sizesFlange = null;

            //StandartFreeFlange standartFreeFlange;
            //switch (index)
            //{
            //    case 0:
            //    case 1:
                 
                   

            //        if (index == 0 )
            //        {
            //            sizesFlange = new SizesSimpleFlange();

            //        }
            //        else if (index ==1)
            //        {
            //            sizesFlange = new SizesFreeFlange();
            //        }

                  

           

            //        standartFreeFlange = new StandartFreeFlange();

            //        TableData = standartFreeFlange.Data;


            //        break;

            //    default:
            //        sizesFlange = null;
            //        TableData = null;
            //        break;
            //}


            //LastSelectedItem = index;
            //if (sizesFlange !=null)
            //{

            //    DPar.TextBoxValue = sizesFlange.GetParam(DPar.Id);
            //    D1Par.TextBoxValue = sizesFlange.GetParam(D1Par.Id);
            //    D2Par.TextBoxValue = sizesFlange.GetParam(D2Par.Id);
            //    DbPar.TextBoxValue = sizesFlange.GetParam(DbPar.Id);
            //    HPar.TextBoxValue = sizesFlange.GetParam(HPar.Id);
            //    CountOfHolesPar.TextBoxValue = sizesFlange.GetParam(CountOfHolesPar.Id);

            //}

            //if (sizesFlange is SizesFreeFlange)
            //{
            //    APar.TextBoxValue = sizesFlange.GetParam(APar.Id);
            //    SPar.TextBoxValue = sizesFlange.GetParam(SPar.Id);
            //}
            
        }


        public FlangeModel()
        {
            //DVisibitily = Visibility.Hidden;
            


            DController = new Controller(false,0);
            D1Controller = new Controller(false,1);
            D2Controller = new Controller(false,2);
            HController = new Controller(false,3);
            DbController = new Controller(false,4);
            NConroller = new Controller(false,5);

            AController = new Controller(false, 6);
         
            SController = new Controller(false, 7);


            FlangeTittles = new ObservableCollection<string>(( from fl in FlangeType.AllFlangeTypes select fl.Tittle).ToArray());
            OnPropertyChanged(nameof(FlangeTittles));


            // SelectFlangeType = FlangeTypesCBItems[0] ;

            SizesSimpleFlange sizesSimpleFlange = new SizesSimpleFlange();

            WindowWidth = 1000;
            UpdateTableWidth(WindowWidth);

            SketchOffsetX = new CanvasOffsetX(10, 0);

            Modeltype = new ModelType(0);

          

            TableOffsetX = new CanvasOffsetX(SketchOffsetX.Left + 100,0);

            SelectedFlangeType = 0;

            //ModelTypesCollection = ModelType.AllModels;

            //foreach(var i in ModelType.AllModels)
            //{
            //    ModelTypesCollection.Add(i);
            //}

            //Modeltype = new ModelType(Constants.Model3D);
            //TableWidth = WindowWidth/2+  TableOffsetX.Left+SketchOffsetX.Left;
        }
    }
}
