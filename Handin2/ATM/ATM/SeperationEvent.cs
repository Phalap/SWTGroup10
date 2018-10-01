using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeperationEvent
    {

        private double _occurrenceTime;
        private List<TrackData> _involvedTracks;
        private bool _isRaised;

        public SeperationEvent(double occurrenceTime, List<TrackData> involvedTracks, bool isRaised)
        {
            _occurrenceTime = occurrenceTime;
            _involvedTracks = involvedTracks;
            _isRaised = isRaised;
        }

        public double _OccurrenceTime { get { return _occurrenceTime; } set {_occurrenceTime = value; } }
        public List<TrackData> _InvolvedTracks { get { return _involvedTracks; } set { _involvedTracks = value; } }
        public bool _IsRaised { get { return _isRaised; } set { _isRaised = value; } }

    }
}
