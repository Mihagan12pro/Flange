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
//using Flange.ViewModel.Tables;
using Flange.Other.Extra_sizes;
using System.Windows.Media.Animation;
using Flange.Other.Abstract_classes_and_interfaces;
//using Flange.Model.DB_classes.Default.Tables;
using Flange.Model.DB_classes.Default;
using Flange.Other.WPF_override;
using Flange.Model.DB_classes.Default.Values;





namespace Flange.Model
{
   internal class FlangeViewModel : ViewModelAbstract
    {

        //private Table tableData;
        //public Table TableData
        //{
        //    private set
        //    {
        //        tableData = value;
        //        OnPropertyChanged();
        //    }
        //    get
        //    {
        //        return tableData;
        //    }
        //}


        public  ObservableCollection<string> ModelTypesCollection { get; private set; }

     
      

        public ObservableCollection<string> FlangeTittles { get; private set; } 


        public  ModelType Modeltype { get; private set; }
        
    
    
        

        public event EventHandler CanExecuteChanged;


        private RadioMenuItem selectCADRadioMenu;

        private DefaultValues defaultValues;

  
        private string _D;
        public string D
        {
            get
            {
                return _D;
            }
            set
            {
                _D = value;
                OnPropertyChanged();
            }
        }

        private string _D1;
        public string D1
        {
            get
            {
                return _D1;
            }
            set
            {
                _D1= value;
                OnPropertyChanged();
            }
        }

        private string _D2;
        public string D2
        {
            get
            {
                return _D2;
            }
            set
            {
                _D2 = value;
                OnPropertyChanged();
            }
        }
        private string _D3;
        public string D3
        {
            get
            {
                return _D3;
            }
            set
            {
                _D3 = value;
                OnPropertyChanged();
            }
        }

        private string _D4;
        public string D4
        {
            get
            {
                return _D4;
            }
            set
            {
                _D4 = value;
                OnPropertyChanged();
            }
        }


        private string _D5;
        public string D5
        {
            get
            {
                return _D5;
            }
            set
            {
                _D5 = value;
                OnPropertyChanged();
            }
        }

        private string _Db;
        public string Db
        {
            get
            {
                return _Db;
            }
            set
            {
                _Db = value;
                OnPropertyChanged();
            }
        }

        private string _H;
        public string H
        {
            get
            {
                return _H;
            }
            set
            {
                _H = value;
                OnPropertyChanged();
            }
        }

        private string _H2;
        public string H2
        {
            get
            {
                return _H2;
            }
            set
            {
                _H2 = value;
                OnPropertyChanged();
            }
        }

        private string _H3;
        public string H3
        {
            get
            {
                return _H3;
            }
            set
            {
                _H3 = value;
                OnPropertyChanged();
            }
        }

        private string _H4;
        public string H4
        {
            get
            {
                return _H4;
            }
            set
            {
                _H4 = value;
                OnPropertyChanged();
            }
        }

        private string _n;
        public string n
        {
            get
            {
                return _n;
            }
            set
            {
                _n = value;
                OnPropertyChanged();
            }
        }

        private bool isFreeFlangeSelected;
        public bool IsFreeFlangeSelected
        {
            get
            {
                return isFreeFlangeSelected;
            }
            set
            {

                isFreeFlangeSelected = value;

                if (value == true)
                {
                    BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.FreeFlange));

                    CollapseAll();

                    FreeFlangeDefaultValues free = new FreeFlangeDefaultValues();

                    VisibilityOfD1 = Visibility.Visible;
                    VisibilityOfD2 = Visibility.Visible;
                    VisibilityOfDb = Visibility.Visible;
                    VisibilityOfn = Visibility.Visible;

                    defaultValues = new FreeFlangeDefaultValues();

                    D = Convert.ToString(defaultValues.D);
                    D1 = Convert.ToString((defaultValues as FreeFlangeDefaultValues).D1);
                    D2 = Convert.ToString((defaultValues as FreeFlangeDefaultValues).D2);
                    Db = Convert.ToString((defaultValues as FreeFlangeDefaultValues).Db);
                    H = Convert.ToString(defaultValues.H);
                    n = Convert.ToString((defaultValues as FreeFlangeDefaultValues).n);
                }
                OnPropertyChanged();
            }
        }

        private bool isFlatFlangeSelected;
        public bool IsFlatFlangeSelected
        {
            get
            {
                return isFlatFlangeSelected;
            }
            set
            {
                isFlatFlangeSelected = value;
                if (value == true)
                {
                    BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.FlatFlange));

                    CollapseAll();

                    VisibilityOfD1 = Visibility.Visible;
                    VisibilityOfD2 = Visibility.Visible;
                    VisibilityOfD3 = Visibility.Visible;
                    VisibilityOfDb = Visibility.Visible;
                    VisibilityOfH4 = Visibility.Visible;
                    VisibilityOfn = Visibility.Visible;

                    defaultValues = new FlatFlangeDefaultValues();

                    D = Convert.ToString(defaultValues.D);
                    D1 = Convert.ToString((defaultValues as FlatFlangeDefaultValues).D1);
                    D2 = Convert.ToString((defaultValues as FlatFlangeDefaultValues).D2);
                    Db = Convert.ToString((defaultValues as FlatFlangeDefaultValues).Db);
                    H = Convert.ToString(defaultValues.H);
                    n = Convert.ToString((defaultValues as FlatFlangeDefaultValues).n);
                    D3 = Convert.ToString((defaultValues as FlatFlangeDefaultValues).D3);
                    H4 = Convert.ToString((defaultValues as FlatFlangeDefaultValues).H4);
                }
                OnPropertyChanged();

            }
        }

        private bool isBlindFlangeSelected;
        public bool IsBlindFlangeSelected
        {
            get
            {
                return isBlindFlangeSelected;
            }
            set
            {
               
                isBlindFlangeSelected = value;
                if (value == true)
                {
                    CollapseAll();
                    BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.BlindFlange));

                    VisibilityOfD1 = Visibility.Visible;
                    VisibilityOfD2 = Visibility.Visible;
                    VisibilityOfD3 = Visibility.Visible;
                    VisibilityOfH4 = Visibility.Visible;
                    VisibilityOfn = Visibility.Visible;


                    defaultValues = new BlindFlangeDefaultValues();

                    D = Convert.ToString(defaultValues.D);
                    H = Convert.ToString(defaultValues.H);
                    D1 = Convert.ToString((defaultValues as BlindFlangeDefaultValues).D1);
                    D2 = Convert.ToString((defaultValues as BlindFlangeDefaultValues).D2);
                    D3 = Convert.ToString((defaultValues as BlindFlangeDefaultValues).D3);
                    H4 = Convert.ToString((defaultValues as BlindFlangeDefaultValues).H4);
                    n = Convert.ToString((defaultValues as BlindFlangeDefaultValues).n);



                }
                OnPropertyChanged();
            }
        }

        private bool isCollarFlangeSelected;
        public bool IsCollarFlangeSelected
        {
            get
            {
                return isCollarFlangeSelected;
            }
            set
            {
                
                isCollarFlangeSelected = value;
                if (value == true)
                {
                    CollapseAll();
                    BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.CollarFlange));

                    VisibilityOfD1 = Visibility.Visible;
                    VisibilityOfD2 = Visibility.Visible;
                    VisibilityOfD3 = Visibility.Visible;
                    VisibilityOfD4 = Visibility.Visible;
                    VisibilityOfD5 = Visibility.Visible;
                    VisibilityOfDb = Visibility.Visible;
                    VisibilityOfH2 = Visibility.Visible;
                    VisibilityOfH3 = Visibility.Visible;
                    VisibilityOfH4 = Visibility.Visible;
                    VisibilityOfn = Visibility.Visible;

                    defaultValues = new CollarFlangeDefaultValues();

                    D = Convert.ToString(defaultValues.D);
                    D1 = Convert.ToString((defaultValues as CollarFlangeDefaultValues).D1);
                    D2 = Convert.ToString((defaultValues as CollarFlangeDefaultValues).D2);
                    D3 = Convert.ToString((defaultValues as CollarFlangeDefaultValues).D3);
                    D4 = Convert.ToString((defaultValues as CollarFlangeDefaultValues).D4);
                    D5 = Convert.ToString((defaultValues as CollarFlangeDefaultValues).D5);
                    Db = Convert.ToString((defaultValues as CollarFlangeDefaultValues).Db);
                    H = Convert.ToString(defaultValues.H);
                    H2 = Convert.ToString((defaultValues as CollarFlangeDefaultValues).H2);
                    H3 = Convert.ToString((defaultValues as CollarFlangeDefaultValues).H3);
                    H4 = Convert.ToString((defaultValues as CollarFlangeDefaultValues).H4);
                    n = Convert.ToString((defaultValues as CollarFlangeDefaultValues).n);
                }
                OnPropertyChanged();
            }
        }

        public readonly Visibility VisibilityOfD;
        public readonly Visibility VisibilityOfH;

        private Visibility visibilityOfD1;
        public Visibility VisibilityOfD1
        {
            get
            {
                return visibilityOfD1;
            }
            private set
            {
                visibilityOfD1 = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityOfD2;
        public Visibility VisibilityOfD2
        {
            get
            {
                return visibilityOfD2;
            }
            private set
            {
                visibilityOfD2 = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityOfD3;
        public Visibility VisibilityOfD3
        {
            get
            {
                return visibilityOfD3;
            }
            private set
            {
                visibilityOfD3 = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityOfD4;
        public Visibility VisibilityOfD4
        {
            get
            {
                return visibilityOfD4;
            }
            private set
            {
                visibilityOfD4 = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityOfD5;
        public Visibility VisibilityOfD5
        {
            get
            {
                return visibilityOfD5;
            }
            private set
            {
                visibilityOfD5 = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityOfDb;
        public Visibility VisibilityOfDb
        {
            get
            {
                return visibilityOfDb;
            }
            private set
            {
                visibilityOfDb = value;
                OnPropertyChanged();
            }
        }

        //private Visibility visibilityOfH1;
        //public Visibility VisibilityOfH1
        //{
        //    get
        //    {
        //        return visibilityOfH1;
        //    }
        //    private set
        //    {
        //        visibilityOfH1 = value;
        //        OnPropertyChanged();
        //    }
        //}

        private Visibility visibilityOfH2;
        public Visibility VisibilityOfH2
        {
            get
            {
                return visibilityOfH2;
            }
            private set
            {
                visibilityOfH2 = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityOfH3;
        public Visibility VisibilityOfH3
        {
            get
            {
                return visibilityOfH3;
            }
            private set
            {
                visibilityOfH3 = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityOfH4;
        public Visibility VisibilityOfH4
        {
            get
            {
                return visibilityOfH4;
            }
            private set
            {
                visibilityOfH4 = value;
                OnPropertyChanged();
            }
        }

        private Visibility visibilityOfn;
        public Visibility VisibilityOfn
        {
            get
            {
                return visibilityOfn;
            }
            private set
            {
                visibilityOfn = value;
                OnPropertyChanged();
            }
        }
        
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

        private Visibility helpMenuVisibility;
        public Visibility HelpMenuVisibility
        {
            get
            {
                return helpMenuVisibility;
            }
            private set
            {
                helpMenuVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility extraMenuVisibility;
        public Visibility ExtraMenuVisibility
        {
            get
            {
                return extraMenuVisibility;
            }
            private set
            {
                extraMenuVisibility = value;
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
            set
            {
                windowWith = value;
                if (value < 725)
                {
                    HelpMenuVisibility = Visibility.Collapsed;
                    
                    if (value < 660)
                    {
                        ExtraMenuVisibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    HelpMenuVisibility = Visibility.Visible;
                    ExtraMenuVisibility= Visibility.Visible;
                }
                OnPropertyChanged();
            }
        }

        private void CollapseAll()
        {
            VisibilityOfD1 = Visibility.Collapsed;
            VisibilityOfD2 = Visibility.Collapsed;
            VisibilityOfD3 = Visibility.Collapsed;
            VisibilityOfD4 = Visibility.Collapsed;
            VisibilityOfD5 = Visibility.Collapsed;
            VisibilityOfDb = Visibility.Collapsed;
            //VisibilityOfH1 = Visibility.Collapsed;
            VisibilityOfH2 = Visibility.Collapsed;
            VisibilityOfH3 = Visibility.Collapsed;
            VisibilityOfH4 = Visibility.Collapsed;
            VisibilityOfn = Visibility.Collapsed;
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

        private BitmapImage bitmapImage;
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

        //private int selectedFlangeType;
        //public int SelectedFlangeType
        //{
        //    get
        //    {
        //        return selectedFlangeType;
        //    }

        //    set 
        //    {
               
        //        switch(value)
        //        {
        //            case Constants.FreeFlange:
        //                Validator = ValidatorDefaultTable.Instance(new DefaultFreeFlangeTable());

                     
        //                   BitmapImage = new BitmapImage(new Uri( MainExplorer.SketchesExpl.FreeFlange));
        //                break;

        //            case Constants.FlatFlange:
        //                BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.FlatFlange));
        //                break;

        //            case Constants.BlindFlange:
        //                BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.BlindFlange));
        //                break;

        //            case Constants.CollarFlange:
        //                BitmapImage = new BitmapImage(new Uri(MainExplorer.SketchesExpl.CollarFlange));
        //                break;
        //        }
        //        selectedFlangeType = value;
        //        OnPropertyChanged();
        //    }
        //}


        private void CreateFlange()
        {
           //switch( SelectedFlangeType)
           //{
           //     case 0:
           //         //Console.WriteLine(ColumnWidth);
           //         SimpleFlange simpleFlange = new SimpleFlange(DController.RowValue, D1Controller.RowValue ,D2Controller.RowValue, HController.RowValue, NConroller.RowValue, DbController.RowValue);
           //         //simpleFlange.TryToBuild();

           //         break;
           //     case 1:
           //         FreeFlange freeFlange = new FreeFlange(DController.RowValue, D1Controller.RowValue, D2Controller.RowValue, HController.RowValue, NConroller.RowValue, DbController.RowValue,A1Controller.RowValue, S1Controller.RowValue);
           //         //freeFlange.TryToBuild();

           //         break;
           //     default:
           //         MessageBox.Show("Error!");
           //         break;
           //}
        }

        private void CreateExtraSizesWindow()
        {
            //ExtraSizesWindow window = new ExtraSizesWindow(SelectedFlangeType);

           // window.ShowDialog();
            
       

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
            VisibilityOfD = Visibility.Visible;
            VisibilityOfH = Visibility.Visible;

            CollapseAll();

            //FlangeTittles = new ObservableCollection<string>(( from fl in FlangeType.AllFlangeTypes select fl.Tittle).ToArray());
            OnPropertyChanged(nameof(FlangeTittles));

            IsFreeFlangeSelected = true;
            OnPropertyChanged(nameof(IsFreeFlangeSelected));

            UpdateTableWidth(WindowWidth);
        }
    }
}
