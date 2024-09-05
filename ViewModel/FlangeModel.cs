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
using Flange.Databases.GOST_tables;
namespace Flange.Model
{
    internal class FlangeModel : DependencyObject,INotifyPropertyChanged
    {
       
      
        private string flangeTypeCrl;
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




        public Parametre DPar { get; private set; } = new Parametre(0);
        public Parametre D1Par { get;private set; } = new Parametre(1);
        public Parametre D2Par { get;private set; } = new Parametre(2);
        public Parametre DbPar { get; private set; } = new Parametre(3);
        public Parametre HPar { get; private set; } = new Parametre(4);
        public Parametre CountOfHolesPar { get;private set; } = new Parametre(5);

        public Parametre APar { get; private set; } = new Parametre(6);
        public Parametre SPar { get; private set; } = new Parametre(7);


        private FreeFlangeGostTable gostTableFree; 

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

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
                        gostTableFree.Dispose();
                        break;
                }
                lastSelectedItem = value;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FlangeTypeCrl
        {
            get
            {
                return flangeTypeCrl;
            }
            set
            {
                if (value!=flangeTypeCrl)
                {
                    flangeTypeCrl = value;

                    FileInfo file;

                    switch (FlangeTypesCBItems.IndexOf(flangeTypeCrl))
                    {
                        case 0:

                            AController.ReadOnly = true;
                            SController.ReadOnly = true;

                            SPar.TextBoxValue = "";
                            APar.TextBoxValue = "";


                            ChangeTextBoxElems(0);



                            file = new FileInfo(@"..\..\Sketches\SimpleFlange.bmp");
                           
                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;

                        case 1:

                            AController.ReadOnly = false;
                            SController.ReadOnly = false;

                            

                            ChangeTextBoxElems(1);


                            file = new FileInfo(@"..\..\Sketches\FreeFlange.bmp");

                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;

                        case 2:
                            ChangeTextBoxElems(2);
                            file = new FileInfo(@"..\..\Sketches\FlatFlange.bmp");

                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;

                        default:
                            MessageBox.Show("Error!");
                            break;


                    }

                }
            }
        }
        private int click=0;
        public int Clicks
        {
            get
            {
                return click;
            }
            set
            {
                click = value;
            }
        }

        private void CreateFlange()
        {

           switch( FlangeTypesCBItems.IndexOf(flangeTypeCrl))
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

        public ButtonCommand BuildFlangeCommand
        {
            get
            {
                return new ButtonCommand((obj) =>
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

        private void ChangeTextBoxElems(int index)
        {
            SizesSimpleFlange sizesFlange;


            switch(index)
            {
                case 0:
                    sizesFlange = new SizesSimpleFlange();

                    
                    break;

                case 1:
                    sizesFlange = new SizesFreeFlange();


                    gostTableFree = new FreeFlangeGostTable();
                  

                    break;

                default:
                    sizesFlange = null;
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

            AController = new Controller(true, 6);
         
            SController = new Controller(true, 7);

            FlangeTypesCBItems = new ObservableCollection<string>
            {
                "Фланец",
                "Свободный фланец",
                "Плоский фланец"
            };
            FlangeTypeCrl = FlangeTypesCBItems[0] ;

            SizesSimpleFlange sizesSimpleFlange = new SizesSimpleFlange();

  
        }
        
    }
}
