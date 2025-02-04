using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
//using Flange.Databases.Classes.Standart;
using Flange.Model;
using Flange.Model.DB_classes.Default.Values;
using Flange.Other;
using Flange.Other.WPF_override;
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

            Kompas3DMenuItem.IsChecked = true;

            SizeChanged += MainWindow_SizeChanged;

   
            DefaultValues.Connection = new System.Data.SQLite.SQLiteConnection("Data Source="+MainExplorer.DataBaseExpl.DefaultSizes.FilePath);

            DataContext = new FlangeViewModel();

            Closing += MainWindow_Closing;
            

            
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DefaultValues.Connection.Close();
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            (DataContext as FlangeViewModel).WindowWidth = Width;
        }
    }
}
