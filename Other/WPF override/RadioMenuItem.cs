using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;

namespace Flange.Other.WPF_override
{
    internal class RadioMenuItem : MenuItem
    {
        public RadioMenuItem()
        {
            IsCheckable = true;
            Checked += UserChecked;
            Unchecked += UserUncheched;
        }

        private void UserUncheched(object sender, RoutedEventArgs e)
        {
            RadioMenuItemBox parent = (Parent as RadioMenuItemBox);
            bool isSmthChecked = false;
            for (int i = 0; i < (Parent as RadioMenuItemBox).Items.Count; i++)
            {
                RadioMenuItem radioMenu = parent.Items[i] as RadioMenuItem;
                if (radioMenu.IsChecked)
                {
                    isSmthChecked = true;
                    break;
                }
            }

            if (!isSmthChecked)
            {
                IsChecked = true;
            }
        }

        public void UserChecked(object sender, RoutedEventArgs e)
        {
            RadioMenuItemBox parent = (Parent as RadioMenuItemBox);
            for (int i = 0; i < (Parent as RadioMenuItemBox).Items.Count; i++)
            {
                RadioMenuItem radioMenu = parent.Items[i] as RadioMenuItem;
                if (radioMenu != this && radioMenu.IsChecked)
                {
                    radioMenu.IsChecked = false;
                }
            }
        }
       
    }

}
