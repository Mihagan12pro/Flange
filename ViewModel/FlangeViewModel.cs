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
using System.Data.SqlTypes;
using System.Windows.Input;
using Flange.ViewModel;
using Flange.Kompas.Modeling;
using System.Windows.Controls;
using Flange.Other;
using KompasAPI7;
using Flange.ViewModel.Tables;
using Flange.Other.Extra_sizes;
using System.Windows.Media.Animation;
using Flange.Other.Abstract_classes_and_interfaces;
using Flange.Model.DB_classes.Default.Tables;
using Flange.Model.DB_classes.Default;





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

    public struct ValidatorDefaultTable
    {
        private static ValidatorDefaultTable instance;

        public readonly dynamic DefaultTableClass;

        private ValidatorDefaultTable(dynamic defaultTableClass)
        {
            if (defaultTableClass is not DefaultFlangeTable)
            {
                throw new ArgumentException("An argument must be DefaultFlangeTable class object!");
            }
            DefaultTableClass = defaultTableClass;
        }
        public static ValidatorDefaultTable Instance(dynamic defaultTableClass)
        {

            instance = new ValidatorDefaultTable(defaultTableClass); 


            return instance;

        }
    }
    internal class FlangeViewModel : ViewModelAbstract
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


        public  ObservableCollection<string> ModelTypesCollection { get; private set; }

        private BitmapImage bitmapImage;
      


        public ObservableCollection<string> FlangeTittles { get; private set; } 

        public Controller DController { get; private set; }
        public Controller D1Controller { get; private set; }
        public Controller D2Controller { get; private set; }
        public Controller HController { get; private set; }
        public Controller DbController { get; private set; }
        public Controller NConroller { get; private set; }
        public Controller A1Controller { get;private set; }
        public Controller S1Controller {  get; private set; }




        //public CanvasOffsetX SketchOffsetX { get;private set; }
        //public CanvasOffsetX TableOffsetX { get;private set; }
       public ValidatorDefaultTable Validator { get; private set; }

        public  ModelType Modeltype { get; private set; }


        public DefaultFlangeTable DefaultTable { get; private set; }
        //  DefaultFlangeTable flangeTable;

        

        public event EventHandler CanExecuteChanged;





        public ObservableCollection<string>ModelTypeList
        {
            get
            {
                return Modeltype.AllModels;
            }
        }

        private int tableHeight;
        public int TableHeight
        {
            get
            {
                return tableHeight;
            }
            set
            {
                tableHeight = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                    case Constants.FreeFlange:
                        Validator = ValidatorDefaultTable.Instance(new DefaultFreeFlangeTable());

                     
                           BitmapImage = new BitmapImage(new Uri( MainExplorer.SketchesExpl.FreeFlange));
                        break;

                    case Constants.FlatFlange:
                        BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.FlatFlange));
                        break;

                    case Constants.BlindFlange:
                        BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.BlindFlange));
                        break;

                    case Constants.CollarFlange:
                        BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.CollarFlange));
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
                    //Console.WriteLine(ColumnWidth);
                    SimpleFlange simpleFlange = new SimpleFlange(DController.RowValue, D1Controller.RowValue ,D2Controller.RowValue, HController.RowValue, NConroller.RowValue, DbController.RowValue);
                    //simpleFlange.TryToBuild();

                    break;
                case 1:
                    FreeFlange freeFlange = new FreeFlange(DController.RowValue, D1Controller.RowValue, D2Controller.RowValue, HController.RowValue, NConroller.RowValue, DbController.RowValue,A1Controller.RowValue, S1Controller.RowValue);
                    //freeFlange.TryToBuild();

                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
           }
        }

        private void CreateExtraSizesWindow()
        {
            ExtraSizesWindow window = new ExtraSizesWindow(SelectedFlangeType);

            window.ShowDialog();
            
       

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

        public Command CreateExtraSizesWindowCommand
        {
            get
            {
                return new Command((obj) =>
                {
                    CreateExtraSizesWindow();
                });
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
                                     
                    bitmapImage = value;

                    OnPropertyChanged();
                
            }
        }


        public void UpdateTableWidth(double width)
        {
            //TableWidth = width * 0.5;
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


        

        public FlangeViewModel()
        {
            //DVisibitily = Visibility.Hidden;
            


            DController = new Controller(false,0);
            D1Controller = new Controller(false,1);
            D2Controller = new Controller(false,2);
            HController = new Controller(false,3);
            DbController = new Controller(false,4);
            NConroller = new Controller(false,5);

            A1Controller = new Controller(false, 6);
         
            S1Controller = new Controller(false, 7);


            FlangeTittles = new ObservableCollection<string>(( from fl in FlangeType.AllFlangeTypes select fl.Tittle).ToArray());
            OnPropertyChanged(nameof(FlangeTittles));


            // SelectFlangeType = FlangeTypesCBItems[0] ;

            //DefaultFreeFlangeDb sizesSimpleFlange = new DefaultFreeFlangeDb();

            WindowWidth = 1000;
            UpdateTableWidth(WindowWidth);

            //SketchOffsetX = new CanvasOffsetX(10, 0);

            Modeltype = new ModelType(0);

            TableHeight = 600;

            //TableOffsetX = new CanvasOffsetX(SketchOffsetX.Left + 100,0);

            SelectedFlangeType = 0;
        }
    }
}
