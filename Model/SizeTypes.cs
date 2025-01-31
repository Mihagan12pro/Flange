using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model
{
    struct Diameters
    {
        public Diameters()
        {

        }

        public double D, D1, D2, D3, D4, D5, Db;
    }
    struct Heights
    {
        public Heights()
        {

        }
        public double H,H1, H2, H3, H4;
    }

    struct Counts
    {
        public Counts()
        {

        }
        public int n;
    }

    struct ChamferSizes
    {
        private double angle, lenght;

        public readonly bool IsSelected;
        public double Angle
        {
            get
            {
                return angle;
            }
            private set
            {
                angle = value;
            }
        }
        public double Lenght
        {
            get
            {
                return lenght;
            }
            private set
            {
                lenght = value;
            }
        }
        public ChamferSizes(double angle,double lenght)
        {
            this.lenght = lenght;

            IsSelected = true;

            this.angle = angle;
        }
    }

    struct ChamferSizesCollection
    {
        public ChamferSizesCollection()
        {
            
        }

        public ChamferSizes DiskChamferTop, DiskChamferBottom;
    }
}
