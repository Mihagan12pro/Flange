﻿using Flange.Model.Interface;
using Flange.Other.Abstract_classes_and_interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Flange.Other.Extra_sizes.ViewModel
{
    internal class ExtraViewModel : ViewModelAbstract
    {
        private IFlangeModel flangeModel;
        public IFlangeModel FlangeModel
        {
            get { return flangeModel; }
            private set {  flangeModel = value; OnPropertyChanged(); }
        }

        

        private Visibility chooseSizeOfHolesVisibility;
        public Visibility ChooseSizeOfHolesVisibility
        {
            get
            {
                return chooseSizeOfHolesVisibility;
            }
            private set
            {
                chooseSizeOfHolesVisibility = value;
                OnPropertyChanged();
            }
        }



        private double chamferTopLength;
        public double ChamferTopLength
        {
            get => chamferTopLength;
            set { chamferTopLength = value; OnPropertyChanged();} 
        }

        private double chamferBottomLength;
        public double ChamferBottomLength
        {
            get => chamferBottomLength;
            set { chamferBottomLength = value;OnPropertyChanged();}
        }




        private Visibility diskChamferTopVisibility;
        public Visibility DiskChamferTopVisibility
        {
            get
            {
                return diskChamferTopVisibility;
            }
            private set
            {
                diskChamferTopVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility diskFilletTopVisibility;
        public Visibility DiskFilletTopVisibility
        {
            get
            {
                return diskFilletTopVisibility;
            }
            private set
            {
                diskFilletTopVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility diskChamferBottomVisibility;
        public Visibility DiskChamferBottomVisibility
        {
            get
            {
                return diskChamferBottomVisibility;
            }
            private set
            {
                diskChamferBottomVisibility = value;
                OnPropertyChanged();
            }
        }
        private Visibility diskFilletBottomVisibility;
        public Visibility DiskFilletBottomVisibility
        {
            get
            {
                return diskFilletBottomVisibility;
            }
            private set
            {
                diskFilletBottomVisibility = value;
                OnPropertyChanged();
            }
        }






        private bool isDiskBottomFilletChecked;
        public bool IsDiskBottomFilletChecked
        {
            get
            {
                return isDiskBottomFilletChecked;
            }
            set
            {
                if (value)
                {
                    DiskChamferBottomVisibility = Visibility.Collapsed;
                    DiskFilletBottomVisibility = Visibility.Visible;
                }
                isDiskBottomFilletChecked = value;
                OnPropertyChanged();
            }
        }

        private bool isDiskTopFilletChecked;
        public bool IsDiskTopFilletChecked
        {
            get
            {
                return isDiskTopFilletChecked;
            }
            set
            {
                if (value)
                {
                    DiskChamferTopVisibility = Visibility.Collapsed;
                    DiskFilletTopVisibility = Visibility.Visible;
                }
                isDiskTopFilletChecked = value;
                OnPropertyChanged();
            }
        }

        private bool isDiskBottomChamferChecked;
        public bool IsDiskBottomChamferChecked
        {
            get
            {
                return isDiskBottomChamferChecked;
            }
            set
            {
                if (value)
                {
                    DiskChamferBottomVisibility = Visibility.Visible;
                    DiskFilletBottomVisibility = Visibility.Collapsed;
                }
                isDiskBottomChamferChecked = value;
                OnPropertyChanged();
            }
        }

        private bool isDiskTopChamferChecked;
        public bool IsDiskTopChamferChecked
        {
            get
            {
                return isDiskTopChamferChecked;
            }
            set
            {
                if (value)
                {
                    DiskChamferTopVisibility = Visibility.Visible;
                    DiskFilletTopVisibility = Visibility.Collapsed;
                }
                isDiskTopChamferChecked = value;
                OnPropertyChanged();
            }
        }



        private  BitmapImage image;
        public BitmapImage Image
        {
            get
            {
                return image;
            }
            private set
            {
                image = value;
                OnPropertyChanged();
            }
        
        }

        public ExtraViewModel(IFlangeModel flangeModel)
        {
            this.flangeModel = flangeModel;

            chooseSizeOfHolesVisibility = Visibility.Collapsed;

            IsDiskTopChamferChecked = flangeModel._Chamfers.DiskChamferTop.IsSelected;
            IsDiskBottomChamferChecked = flangeModel._Chamfers.DiskChamferBottom.IsSelected;

            IsDiskBottomFilletChecked = flangeModel._Fillets.DiskFilletBottom.IsSelected;
            IsDiskTopFilletChecked = flangeModel._Fillets.DiskFilletTop.IsSelected;

            if (flangeModel is IFlangeModelWithHolesForScrews)
            {
                if (flangeModel is IFreeFlangeModel)
                {
                    Image = new BitmapImage(new Uri(MainExplorer.SketchesExpl.FreeFlange));
                }
            }
            else
            {

            }

        }

    }
}
