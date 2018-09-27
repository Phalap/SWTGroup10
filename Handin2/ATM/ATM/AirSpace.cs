using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace ATM
{
    public class AirSpace : IAirspace
    {
        private double _Xcord, _Ycord, _Zcord;

        public AirSpace(double Xcord, double Ycord, double Zcord)
        {
            _Xcord = Xcord;
            _Ycord = Ycord;
            _Zcord = Zcord;
        }

        public bool CheckIfInMonitoredArea(double xCord, double yCord, double zCord)
        {

            //To be implemented

            return
        }
    }
}
