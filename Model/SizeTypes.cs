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
        public double H,H1, H2, H3, H4;
    }

    struct Counts
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
        public ChamferSizes(double angle,double lenght)
        {
            this.lenght = lenght;

            IsSelected = true;

            this.angle = angle;
        }
    }


    public struct ChamferSizesCollection
    {
        public ChamferSizesCollection()
        {
            
        }

        public ChamferSizes DiskChamferTop, DiskChamferBottom;
    }

    public struct ExtraSizesCollection
    {
        public ExtraSizesCollection()
        {
            
        }
        public ChamferSizesCollection Chamfers;
    }
}
