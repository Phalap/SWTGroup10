using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class TrackData
    {

        private string _tag;
        private double _currentXcord, _currentYcord, _currentZcord;

        public TrackData(string tag, double currentXcord, double currentYcord, double currentZcord)
        {
            _tag = tag;
            _currentXcord = currentXcord;
            _currentYcord = currentYcord;
            _currentZcord = currentZcord;
        }

        public String _Tag { get; set; }
        public double _CurrentXcord { get; set; }
        public double _CurrentYcord { get; set; }
        public double _CurrentZcord { get; set; }

 
    }
}
