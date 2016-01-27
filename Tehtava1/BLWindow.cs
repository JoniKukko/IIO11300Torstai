using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class Ikkuna
    {
        #region Muuttujat (variables)
        private double korkeus;
        //private double pintaala;
        #endregion
        #region Ominaisuudet (properties)
        //olio suunniyttelun aikana on päätetty etä pinta-ala ja hinta ovat read-only ominaisuuksia
        public double PintaAla
        {
            get
            {
                return korkeus * leveys;
            }
        }
        public float Hinta
        {
            get
            {
                return LaskeHinta();
            }
        }
        public double Korkeus
        {
            get
            {
                return korkeus;
            }
            set
            {
                //tässä kohdassa voisi tarvittaessa tehdä tarkistuksia
                korkeus = value;
            }
        }
        private double leveys;

        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }

        #endregion
        #region Konstruktorit (constructors)
        #endregion
        #region Metodit (methods)
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
        private float LaskeHinta()
        {
            //hinta lasketaan työn, ja materiaalimenekin ja katteen avulla
            float kate = 100;
            float tyo = 200;
            float materiaali;
            materiaali = 100 * (float)(leveys * korkeus / 1000000);
            return (kate + tyo + materiaali);
        }
        #endregion

    }
    public class IkkunaVE0
    {
        //joskus tehdään näin "oikaistaan"
        //en suosittele by Esa
        public double korkeus;
        public double leveys;
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
    }
    public class BusinessLogicWindow
    {
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>
        public static double CalculatePerimeter(double width, double height, double frame)
        {
            double perimeter = (2 * (height+ width)) / 1000;
            return perimeter;
        }
        public static double CalculateWindowArea(double width, double height)
        {
            double area = (width * height) / 1000000;
            return area;
        }
        public static double CalculateFrameArea(double width, double height, double frame)
        {
            double area = ((frame + height * frame + width) - (width * height)) / 1000000;
            return area;

        }
    }
}

