using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeperationEvent
    {

        private DateTime _occurrenceTime;
        private List<String> _involvedTracks;
        private bool _isRaised;

        public SeperationEvent(DateTime occurrenceTime, List<String> involvedTracks, bool isRaised)
        {
            _occurrenceTime = occurrenceTime;
            _involvedTracks = involvedTracks;
            _isRaised = isRaised;
        }

        public DateTime _OccurrenceTime { get; set; }
        public List<String> _InvolvedTracks { get; set; }
        public bool _IsRaised { get; set; }




    }
}
