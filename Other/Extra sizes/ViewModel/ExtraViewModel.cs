using Flange.Other.Abstract_classes_and_interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Other.Extra_sizes.ViewModel
{
    internal class ExtraViewModel : ViewModelAbstract
    {
        private int windowWidth;
        public  int WindowWidth
        {
            get
            {

                return windowWidth;
            }
            set
            {
                windowWidth = value;
                OnPropertyChanged();

                MainTabStackPanelWidth = windowWidth/2;
            }
        }

        private int windowHeight;
        public int WindowHeight
        {
            get
            {
                return windowHeight;
            }
            set
            {
                windowHeight = value;
                OnPropertyChanged();

               
                MainTabTableHeight = 2*WindowHeight / 3;
                MainTabStackPanelHeight = WindowHeight - MainTabTableHeight;
            }
        }

        private int mainTabStackPanelWidth;
        public int MainTabStackPanelWidth
        {
            get
            {
                return mainTabStackPanelWidth;
            }
            private set
            {
                mainTabStackPanelWidth = value;
                OnPropertyChanged();

                MainTabButtonsWidth = 9 * MainTabStackPanelWidth / 10;
            }
        }

        private int mainTabStackPanelHeight;
        public int MainTabStackPanelHeight
        {
            get
            {
                return mainTabStackPanelHeight;
            }
            private set
            {
                mainTabStackPanelHeight = value;
                OnPropertyChanged();


                MainTabButtonsHeight = mainTabStackPanelHeight / 6;
            }
        }

        private int mainTabTableHeight;
        public int MainTabTableHeight
        {
            get
            {
                return mainTabTableHeight;
            }
            private set
            {
                mainTabTableHeight = value;
                OnPropertyChanged();
                MainTabStackPanelHeight = WindowHeight/3;
            }
        }


        private int mainTabButtonsWidth;
        public int MainTabButtonsWidth
        {
            get
            {
                return mainTabButtonsWidth;
            }
            private set
            {
                mainTabButtonsWidth = value;
                OnPropertyChanged();
            }
        }

        private int mainTabButtonsHeight;
        public int MainTabButtonsHeight
        {
            get
            {
                return mainTabButtonsHeight;
            }
            private set
            {
                mainTabButtonsHeight = value;
                OnPropertyChanged();
            }
        }

        public ExtraViewModel()
        {
            WindowWidth = 300;
            WindowHeight = 300;
        }

    }
}
