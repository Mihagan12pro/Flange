using System;
using System.Collections.Generic;
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
        public ChamferSizes(double angleInDegrees,double lenght)
        {
            this.lenght = lenght;

            this.angle = (angleInDegrees*Math.PI)/180;
        }
    }
}
