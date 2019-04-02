﻿using System;

namespace RL.Geo.Geomagnetism.Models
{
    public class Wmm1990 : IGeomagneticModel
    {
        public DateTime ValidFrom { get { return new DateTime(1990, 1, 1);} }
        public DateTime ValidTo { get { return new DateTime(1995, 1, 1); } }

        public double[,] MainCoefficientsG
        {
            get
            {
                return new[,]
                {
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -29780.5, -1851.7, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { -2134.3, 3062.2, 1691.9, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 1312.9, -2244.7, 1246.8, 808.6, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 933.5, 784.9, 323.5, -421.7, 139.2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { -208.3, 352.2, 246.5, -110.8, -162.3, -37.2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 59, 63.7, 60, -181.3, 0.4, 15.4, -96, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 76.1, -62.1, 1.3, 30.2, 4.7, 7.9, 10.1, 1.9, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 22.9, 2.3, -1.2, -11.7, -17.5, 2.2, 5.7, 3, -7, 0.0, 0.0, 0.0, 0.0 }, 
                    { 3.6, 9.5, -0.9, -10.7, 10.7, -3.2, -1.4, 6.3, 0.8, -5.5, 0.0, 0.0, 0.0 },
                    { -3.3, -2.6, 4.5, -5.6, -3.6, 3.9, 3.2, 1.7, 3, 3.7, 0.7, 0.0, 0.0 }, 
                    { 1.3, -1.4, -2.5, 3.2, 0.2, -1.1, 0.3, -0.3, 0.9, -1.1, 2.4, 3, 0.0 }, 
                    { -1.3, 0.1, 0.5, 0.7, 0.4, -0.2, -1.1, 0.9, -0.6, 0.8, 0.2, 0.4, 0.2 }
                };
            }
        }

        public double[,] MainCoefficientsH
        {
            get
            {
                return new[,]
                {
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 5407.2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, -2278.3, -384.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, -284.9, 291.7, -352.4, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 249.4, -232.7, 91.3, -296.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 40.8, 148.7, -154.6, -67.6, 97.4, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -14.7, 82.2, 70, -56.2, -1.4, 24.6, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, -78.6, -26.7, 0.1, 19.9, 17.9, -21.5, -6.8, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 9.7, -19.3, 6.6, -20.1, 13.4, 9.8, -19, -9.1, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, -21.9, 14.3, 9.5, -6.7, -6.4, 9.1, 8.9, -8, 2.1, 0.0, 0.0, 0.0 }, 
                    { 0.0, 2.6, 1.2, 2.6, 5.7, -4, -0.4, -1.7, 3.8, -0.8, -6.5, 0.0, 0.0 }, 
                    { 0.0, 0.0, 1, -1.6, -2.2, 1.1, -0.7, -1.7, -1.5, -1.3, -1.1, 0.6, 0.0 }, 
                    { 0.0, 0.7, 0.7, 1.3, -1.5, 0.3, 0.2, -1.1, 1.2, -0.2, -1.3, 0.6, 0.6 }
                };
            }
        }

        public double[,] SecularCoefficientsG
        {
            get
            {
                return new[,]
                {
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 16, 9.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -11.7, 3.7, 1.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 2.1, -7.6, 0.0, -5.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { -0.8, 1, -7.4, 0.8, -6.4, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 1.7, 0.0, 0.0, -2.7, 0.0, 3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.8, 0.0, 1.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.5, 0.0, -0.9, 1.5, 2.7, -1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, -1.1, 0.0, 0.0, -2.1, 0.0, 1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }
                };
            }
        }

        public double[,] SecularCoefficientsH
        {
            get
            {
                return new[,]
                {
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -13.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, -12.8, -14.9, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 3.1, 0.8, -11.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 3.3, 3.7, 2.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.0, -2.1, 1.2, 1.2, 0.6, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, -0.6, -0.6, 0.0, -2.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.6, 0.8, 0.0, 0.0, 0.0, 0.4, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.4, -0.8, 0.5, 0.3, 0.5, 0.0, -0.7, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }, 
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }
                };
            }
        }
    }
}