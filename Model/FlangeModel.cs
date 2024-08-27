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
namespace Flange.Model
{
    internal class FlangeModel : DependencyObject,INotifyPropertyChanged
    {

        private string flangeTypeCrl;
        private readonly string SimpleFlangeType;


        private BitmapImage image;



        public ObservableCollection<string> FlangeTypesCBItems { get; private set; }

        public Controller DController { get; private set; }
        public Controller D1Controller { get; private set; }
        public Controller D2Controller { get; private set; }
        public Controller HController { get; private set; }
        public Controller DbController { get; private set; }
        public Controller CountOfHolesConroller { get; private set; }



        public event PropertyChangedEventHandler PropertyChanged;

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
                            file = new FileInfo(@"..\..\Sketches\SimpleFlange.bmp");
                           
                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;
                        case 1:
                            file = new FileInfo(@"..\..\Sketches\FreeFlange.bmp");

                            BitmapImage = new BitmapImage(new Uri(file.FullName));
                            break;
                        case 2:
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

        
        

        public FlangeModel()
        {
           //DVisibitily = Visibility.Hidden;



            DController = new Controller(false,0);
            D1Controller = new Controller(false,1);
            D2Controller = new Controller(false,2);
            HController = new Controller(false,3);
            DbController = new Controller(false,4);
            CountOfHolesConroller = new Controller(false,5);

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
