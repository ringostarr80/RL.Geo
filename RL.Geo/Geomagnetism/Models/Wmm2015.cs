﻿using System;

namespace RL.Geo.Geomagnetism.Models
{
    public class Wmm2015 : IGeomagneticModel
    {
        public DateTime ValidFrom { get { return new DateTime(2015, 1, 1); } }
        public DateTime ValidTo { get { return new DateTime(2020, 1, 1); } }

        public double[,] MainCoefficientsG
        {
            get
            {
                return new[,]
                {
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -29438.5, -1501.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -2445.3, 3012.5, 1676.6, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 1351.1, -2352.3, 1225.6, 581.9, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 907.2, 813.7, 120.3, -335.0, 70.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -232.6, 360.1, 192.4, -141.0, -157.4, 4.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 69.5, 67.4, 72.8, -129.8, -29.0, 13.2, -70.9, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 81.6, -76.1, -6.8, 51.9, 15.0, 9.3, -2.8, 6.7, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 24.0, 8.6, -16.9, -3.2, -20.6, 13.3, 11.7, -16.0, -2.0, 0.0, 0.0, 0.0, 0.0 },
                    { 5.4, 8.8, 3.1, -3.1, 0.6, -13.3, -0.1, 8.7, -9.1, -10.5, 0.0, 0.0, 0.0 },
                    { -1.9, -6.5, 0.2, 0.6, -0.6, 1.7, -0.7, 2.1, 2.3, -1.8, -3.6, 0.0, 0.0 },
                    { 3.1, -1.5, -2.3, 2.1, -0.9, 0.6, -0.7, 0.2, 1.7, -0.2, 0.4, 3.5, 0.0 },
                    { -2.0, -0.3, 0.4, 1.3, -0.9, 0.9, 0.1, 0.5, -0.4, -0.4, 0.2, -0.9, 0.0 }
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
                    { 0.0, 4796.2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -2845.6, -642.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -115.3, 245.0, -538.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 283.4, -188.6, 180.9, -329.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 47.4, 196.9, -119.4, 16.1, 100.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -20.7, 33.2, 58.8, -66.5, 7.3, 62.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -54.1, -19.4, 5.6, 24.4, 3.3, -27.5, -2.3, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 10.2, -18.1, 13.2, -14.6, 16.2, 5.7, -9.1, 2.2, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -21.6, 10.8, 11.7, -6.8, -6.9, 7.8, 1.0, -3.9, 8.5, 0.0, 0.0, 0.0 },
                    { 0.0, 3.3, -0.3, 4.6, 4.4, -7.9, -0.6, -4.1, -2.8, -1.1, -8.7, 0.0, 0.0 },
                    { 0.0, -0.1, 2.1, -0.7, -1.1, 0.7, -0.2, -2.1, -1.5, -2.5, -2.0, -2.3, 0.0 },
                    { 0.0, -1.0, 0.5, 1.8, -2.2, 0.3, 0.7, -0.1, 0.3, 0.2, -0.9, -0.2, 0.7 }
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
                    { 10.7, 17.9, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -8.6, -3.3, 2.4, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 3.1, -6.2, -0.4, -10.4, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -0.4, 0.8, -9.2, 4.0, -4.2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -0.2, 0.1, -1.4, 0.0, 1.3, 3.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { -0.5, -0.2, -0.6, 2.4, -1.1, 0.3, 1.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.2, -0.2, -0.4, 1.3, 0.2, -0.4, -0.9, 0.3, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 0.1, -0.5, 0.5, -0.2, 0.4, 0.2, -0.4, 0.3, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -0.1, -0.1, 0.4, -0.5, -0.2, 0.1, 0.0, -0.2, -0.1, 0.0, 0.0, 0.0 },
                    { 0.0, 0.0, -0.1, 0.3, -0.1, -0.1, -0.1, 0.0, -0.2, -0.1, -0.2, 0.0, 0.0 },
                    { 0.0, 0.0, -0.1, 0.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.1, -0.1, 0.0 },
                    { 0.1, 0.0, 0.0, 0.1, -0.1, 0.0, 0.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }
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
                    { 0.0, -26.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -27.1, -13.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 8.4, -0.4, 2.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -0.6, 5.3, 3.0, -5.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 0.4, 1.6, -1.1, 3.3, 0.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 0, -2.2, -0.7, 0.1, 1.0, 1.3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, 0.7, 0.5, -0.2, -0.1, -0.7, 0.1, 0.1, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -0.3, 0.3, 0.3, 0.6, -0.1, -0.2, 0.3, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    { 0.0, -0.2, -0.1, -0.2, 0.1, 0.1, 0.0, -0.2, 0.4, 0.3, 0.0, 0.0, 0.0 },
                    { 0.0, 0.1, -0.1, 0.0, 0.0, -0.2, 0.1, -0.1, -0.2, 0.1, -0.1, 0.0, 0.0 },
                    { 0.0, 0.0, 0.1, 0.0, 0.1, 0.0, 0.0, 0.1, 0.0, -0.1, 0.0, -0.1, 0.0 },
                    { 0.0, 0.0, 0.0, -0.1, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }
                };
            }
        }
    }
}