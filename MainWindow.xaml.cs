using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
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
       
        public MainWindow()
        {
            InitializeComponent();




        //            < DataGrid Canvas.Left = "{Binding TableOffsetX.Left}" Canvas.Right = "100" ColumnWidth = "{Binding ColumnWidth}" Grid.Column = "0"  CanUserSortColumns = "False" BorderBrush = "White" Width = "{Binding  TableWidth}" IsReadOnly = "True"  CanUserReorderColumns = "False"   CanUserAddRows = "False"  SelectedIndex = "{Binding TableRowIndex}"   SelectionMode = "Single"  Background = "White"  ItemsSource = "{Binding TableData.Data}"     Name = "TableDataGr" Grid.ColumnSpan = "2" Margin = "230,39,162,83" >

        //    < DataGrid.Columns >

        //    </ DataGrid.Columns >
        //</ DataGrid >


            SizeD1Lbl.MaxWidth = SizeD1Lbl.Width;
            SizeDLbl.MaxWidth = SizeDLbl.Width;
            SizeD2Lbl.MaxWidth = SizeD2Lbl.Width;
            SizeHLbl.MaxWidth = SizeHLbl.Width;


            DataContext = new FlangeModel();



            MainCanvas.SizeChanged += MainCanvas_SizeChanged;

            MouseDown += MainWindow_MouseDown;

          
        }

     

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // TableDataGr.SelectedIndex = -1;
            
        }

        private void MainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (DataContext is FlangeModel flangeModel)
            {
                flangeModel.UpdateTableWidth(e.NewSize.Width);
            }
        }


    }

   
}
