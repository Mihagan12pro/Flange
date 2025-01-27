using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
namespace Flange.Other.WPF_override
{
    internal class ParametersBox: TextBox
    {
        public ParametersBox()
        {
            LostFocus += ParameteresBox_LostFocus;
        }
        private void ParameteresBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                if (double.TryParse(Text.Replace(",","."), out double d))
                {
                    Text = Convert.ToString(Math.Abs(d));
                    return;
                }
                else if (double.TryParse(Text.Replace(".",","),out d))
                {
                    Text = Convert.ToString(Math.Abs(d));
                    return;
                }
                else
                {
                    MessageBox.Show("Некорректный ввод!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                 
            }
            // && !double.TryParse(Text.Replace(".",","),out double d2)
        }
    }
}
