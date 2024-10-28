using Flange.Other.Extra_sizes.ViewModel;
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
using System.Windows.Shapes;

namespace Flange.Other.Extra_sizes
{
    /// <summary>
    /// Interaction logic for ExtraSizesWindow.xaml
    /// </summary>
    public partial class ExtraSizesWindow : Window
    {
        Binding binding = new Binding("WindowWidth");
        public ExtraSizesWindow()
        {
            InitializeComponent();


            DataContext = new ExtraViewModel();

            

            

            binding.Source = DataContext;
            binding.Mode = BindingMode.TwoWay;

            this.SetBinding(WidthProperty,binding);
        }
    }
}
