using Flange.Other.Abstract_classes_and_interfaces;
using System;
using System.Collections.Generic;
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
            }
        }

        public ExtraViewModel()
        {
            WindowWidth = 300;
        }

    }
}
