using System;
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




namespace Flange.Model
{
     
    internal class FlangeModel : DependencyObject,INotifyPropertyChanged
    {
       
     
      
        private string selectFlangeType;
        private readonly string SimpleFlangeType;


        private BitmapImage image;
        private SizesSimpleFlange flangeSizes;


        public ObservableCollection<string> FlangeTypesCBItems { get; private set; }

        public Controller DController { get; private set; }
        public Controller D1Controller { get; private set; }
        public Controller D2Controller { get; private set; }
        public Controller HController { get; private set; }
        public Controller DbController { get; private set; }
        public Controller CountOfHolesConroller { get; private set; }
        public Controller AController { get;private set; }
        public Controller SController {  get; private set; }


        public ParametreDouble DPar { get; private set; } 
        public ParametreDouble D1Par { get; private set; } 
        public ParametreDouble D2Par { get; private set; } 
        public ParametreDouble DbPar { get; private set; } 
        public ParametreDouble HPar { get; private set; }
        public ParametreInt CountOfHolesPar { get; private set; } 
        public ParametreDouble APar { get; private set; }
        public ParametreDouble SPar { get; private set; }


        public CanvasOffsetX SketchOffsetX { get;private set; }
        public CanvasOffsetX TableOffsetX { get;private set; }

     



   
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;


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
                //TableRowIndex = 0;
                tableRowIndex = value;

                if (value != -1)
                {
                    switch(FlangeTypesCBItems.IndexOf(selectFlangeType))
                    {
                        case 0:
                        case 1:

                            DPar.TextBoxValue = TableData[tableRowIndex].D;
                            D1Par.TextBoxValue = TableData[tableRowIndex].D1;
                            D2Par.TextBoxValue = TableData[tableRowIndex].D2;
                            CountOfHolesPar.TextBoxValue = TableData[tableRowIndex].N;

                            break;
                    }
                }

                    OnPropertyChanged();
                
            }
        }

        private ObservableCollection<DataStorage> tableData;
        public ObservableCollection<DataStorage> TableData
        {
            get
            {
                return tableData;
            }
            set
            {
                tableData = value;


                OnPropertyChanged();
            }
        }

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
      








        private int lastSelectedItem = 0;

        private int LastSelectedItem
        {
            get
            {
                return lastSelectedItem;
            }
            set
            {
                switch(lastSelectedItem)
                {
                    case 1:
                       // gostTableFree.Dispose();
                        break;
                }
                lastSelectedItem = value;
            }
        }












        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }














        public string SelectFlangeType
        {
            get
            {
                return selectFlangeType;
            }
            set
            {



                if (value!=selectFlangeType)
                {

                    AController.ReadOnly = true;
                    SController.ReadOnly = true;

                    SPar.TextBoxValue = "";
                    APar.TextBoxValue = "";

                    selectFlangeType = value;

                    FileInfo file;

                    switch (FlangeTypesCBItems.IndexOf(selectFlangeType))
                    {
                        case 0:
                            AController.ReadOnly = false;
                            SController.ReadOnly = false;
                            SPar.TextBoxValue = "";
                            APar.TextBoxValue = "";

                            ChangeTextBoxElems(0);

                            file = new FileInfo(MainExplorer.SketchesExpl.SimpleFlange);
                           
                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;

                        case 1:

                            AController.ReadOnly = false;
                            SController.ReadOnly = false;

                            ChangeTextBoxElems(1);

                            file = new FileInfo(MainExplorer.SketchesExpl.FreeFlange);

                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;

                        case 2:

                            ChangeTextBoxElems(2);
                            file = new FileInfo(MainExplorer.SketchesExpl.FlatFlange);

                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;

                        default:

                            MessageBox.Show("Error!");
                            break;


                    }

                }
            }
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















        private void CreateFlange()
        {

           switch( FlangeTypesCBItems.IndexOf(selectFlangeType))
           {
                case 0:

                    SimpleFlange simpleFlange = new SimpleFlange(DPar.TextBoxValue, D1Par.TextBoxValue ,D2Par.TextBoxValue, HPar.TextBoxValue,CountOfHolesPar.TextBoxValue, DbPar.TextBoxValue);
                    simpleFlange.TryToBuild();

                    break;
                case 1:
                    FreeFlange freeFlange = new FreeFlange(DPar.TextBoxValue, D1Par.TextBoxValue, D2Par.TextBoxValue,  HPar.TextBoxValue, CountOfHolesPar.TextBoxValue, DbPar.TextBoxValue, APar.TextBoxValue,SPar.TextBoxValue);
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
                return image;
            }
            set
            {
                if (image != value)
                {
                   
                    image = value;

                    OnPropertyChanged();
                }

            }
        }


        public void UpdateTableWidth(double width)
        {
            TableWidth = width *0.5;

          



            if (TableData.Count != 0)
            {
                ColumnWidth = (TableWidth / TableData[0].ColumnsCount);

                var a = ColumnWidth;
              

                OnPropertyChanged(nameof(ColumnWidth));
            }
            
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
            SizesSimpleFlange sizesFlange = null;

            StandartFreeFlange standartFreeFlange;
            switch (index)
            {
                case 0:
                case 1:
                 
                   

                    if (index == 0 )
                    {
                        sizesFlange = new SizesSimpleFlange(DPar, D1Par, D2Par, DbPar, HPar, CountOfHolesPar);

                    }
                    else if (index ==1)
                    {
                        sizesFlange = new SizesFreeFlange(DPar, D1Par, D2Par, DbPar, HPar, CountOfHolesPar,APar,SPar);
                    }

                  

           

                    standartFreeFlange = new StandartFreeFlange();

                    TableData = standartFreeFlange.Data;


                    break;

                default:
                    sizesFlange = null;
                    TableData = null;
                    break;
            }


            LastSelectedItem = index;
            if (sizesFlange !=null)
            {

                DPar.TextBoxValue = sizesFlange.GetParam(DPar.Id);
                D1Par.TextBoxValue = sizesFlange.GetParam(D1Par.Id);
                D2Par.TextBoxValue = sizesFlange.GetParam(D2Par.Id);
                DbPar.TextBoxValue = sizesFlange.GetParam(DbPar.Id);
                HPar.TextBoxValue = sizesFlange.GetParam(HPar.Id);
                CountOfHolesPar.TextBoxValue = sizesFlange.GetParam(CountOfHolesPar.Id);

            }

            if (sizesFlange is SizesFreeFlange)
            {
                APar.TextBoxValue = sizesFlange.GetParam(APar.Id);
                SPar.TextBoxValue = sizesFlange.GetParam(SPar.Id);
            }
            
        }









        

        

        public FlangeModel()
        {
            //DVisibitily = Visibility.Hidden;
            


            DController = new Controller(false,0);
            D1Controller = new Controller(false,1);
            D2Controller = new Controller(false,2);
            HController = new Controller(false,3);
            DbController = new Controller(false,4);
            CountOfHolesConroller = new Controller(false,5);

            AController = new Controller(false, 6);
         
            SController = new Controller(false, 7);


          DPar = new ParametreDouble(0,DController);
          D1Par = new ParametreDouble(1,D1Controller);
          D2Par  = new ParametreDouble(2,D2Controller);
          DbPar= new ParametreDouble(3,DbController);
          HPar  = new ParametreDouble(4,HController);
          CountOfHolesPar  = new ParametreInt(5,CountOfHolesConroller);
          APar = new ParametreDouble(6,AController);
          SPar  = new ParametreDouble(7,SController);




            FlangeTypesCBItems = new ObservableCollection<string>
            {
                "Фланец",
                "Свободный фланец",
                "Плоский фланец"
            };
            SelectFlangeType = FlangeTypesCBItems[0] ;

            SizesSimpleFlange sizesSimpleFlange = new SizesSimpleFlange(DPar,D1Par,D2Par,DbPar,HPar,CountOfHolesPar);

            WindowWidth = 1000;
            UpdateTableWidth(WindowWidth);

            SketchOffsetX = new CanvasOffsetX(10, 0);

          

            TableOffsetX = new CanvasOffsetX(SketchOffsetX.Left + 100,0);
           
            //TableWidth = WindowWidth/2+  TableOffsetX.Left+SketchOffsetX.Left;
        }


    
       
        
    }
}
