using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Flange.Databases.Classes.Standart;
using Flange.Model;
namespace Flange
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       private readonly MainWindow programWindow;
        public MainWindow()
        {
            InitializeComponent();

            programWindow = this;

            SketchImage.Height = WindowGrid.Height;
            //SketchImage.MaxHeight = SketchImage.Height;

            SizeD1Lbl.MaxWidth = SizeD1Lbl.Width;
            SizeDLbl.MaxWidth = SizeDLbl.Width;
            SizeD2Lbl.MaxWidth = SizeD2Lbl.Width;
            SizeHLbl.MaxWidth = SizeHLbl.Width;

            
            //TableDataGr.Visibility= Visibility.Hidden;

           


            DataContext = new FlangeModel(programWindow);
           
          
        }




        private void FlangeTypesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DeleteColumns();
            switch(FlangeTypesCB.SelectedIndex)
            {
                

                case 1:

                    StandartFreeFlange standartFree = new StandartFreeFlange();


                    TableDataGr.ItemsSource = standartFree.Data;

                    TableDataGr.Columns.Add(new DataGridTextColumn
                    {
                        Header = "D",
                        Binding = new System.Windows.Data.Binding("D")
                    });
                    TableDataGr.Columns.Add(new DataGridTextColumn
                    {
                        Header = "D1",
                        Binding = new System.Windows.Data.Binding("D1")
                    });
                    TableDataGr.Columns.Add(new DataGridTextColumn
                    {
                        Header = "D2",
                        Binding = new System.Windows.Data.Binding("D2")
                    });
                    TableDataGr.Columns.Add(new DataGridTextColumn
                    {
                        Header = "N",
                        Binding = new System.Windows.Data.Binding("N")
                    });

                    break;

                case 2:
                    break;
            }
        }

        private void DeleteColumns()
        {
            TableDataGr.ItemsSource = null;
            TableDataGr.Columns.Clear();
        }
    }
}
