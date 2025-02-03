using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Flange.Model
{
    public struct Diameters
    {
        public Diameters()
        {

        }

        public double D, D1, D2, D3, D4, D5, Db;
    }



    public struct Heights
    {
        public Heights()
        {

        }
        public double H, H1, H2, H3, H4;
    }



    public struct Counts
    {
        public Counts()
        {

        }
        public int n;
    }



    public struct ChamferSizes
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
        public ChamferSizes(double angle, double lenght)
        {
            this.lenght = lenght;

            IsSelected = true;

            this.angle = angle;
        }
    }

    public struct ChamferSizesCollection
    {
        public ChamferSizes DiskChamferTop, DiskChamferBottom;
        public ChamferSizes CentralHoleChamferTop, CentralHoleChamferBottom;
        public ChamferSizes HoleForScrewChamferTop, HoleForScrewChamferBottom;
        public ChamferSizesCollection()
        {

        }
    }


    public struct FilletSizes
    {
        public readonly bool IsSelected;

        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            private set
            {
                radius = value;
            }
        }
        public FilletSizes(double Radius)
        {
            IsSelected = true;

            this.Radius = Radius;
        }
    }

    public struct FilletSizesCollection
    {
        public FilletSizes DiskFilletTop, DiskFilletBottom;
        public FilletSizes CentralHoleFilletTop, CentralHoleFilletBottom;
        public FilletSizes HoleForScrewFilletTop, HoleForScrewFilletBottom;
        public FilletSizesCollection()
        {
            
        }
    }


    public struct ExtraSizesCollection
    {
        public ExtraSizesCollection()
        {
            
        }
        public ChamferSizesCollection Chamfers;
        public FilletSizesCollection Fillets;
    }
}
