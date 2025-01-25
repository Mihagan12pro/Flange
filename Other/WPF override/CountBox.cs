using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Flange.Other.WPF_override
{
    internal class CountBox : TextBox
    {
        public CountBox()
        {
            LostFocus += CountBox_LostFocus;
        }

        private void CountBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Text = Text.Replace(",", ".");

                if (int.TryParse(Text, out int i))
                {
                    Text = Convert.ToString(Math.Abs(Convert.ToInt32(Text)));
                    return;
                }
                MessageBox.Show("Некорректный ввод!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                Text = "0";
            }
        }
    }
}
