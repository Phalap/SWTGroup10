using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class ATM
    {
        private ILogger _logger;
        private IRenderer _renderer;
        private ITransponderReceiver _transponderReceiver;

        private List<TrackData> _currentTracks;
        private List<SeperationEvent> _currentSeperationEvents;

        private IAirspace _airspace;

        public ATM(ILogger logger, IRenderer renderer, ITransponderReceiver transponderReceiver, IAirspace airspace)
        {
            _logger = logger;
            _renderer = renderer;
            _transponderReceiver = transponderReceiver;
            _airspace = airspace;

        }

        public void HandleNewTrackData(TrackData trackdata)
        {
            //To be implemented

        }

        public bool CheckForSeperationEvent(TrackData trackData1, TrackData trackData2)
        {

            //To be implemented

            return
        }

        public SeperationEvent GetSeperationEventInvolvedIn(TrackData trackData)
        {
            //To be implemented

            return
        }

        public void RenderSeperationEvents(List<SeperationEvent> seperationEvents)
        {
            //To be implemented

        }

        public void RenderTracks(List<TrackData> trackDatas)
        {
            //To be implemented

        }

        public void LogSeperationEvent(SeperationEvent seperationEvent)
        {
            //To be implemented

        }

        public void SubscribeToTransponderDataReady()
        {
            //To be implemented

        }

        public void OnTransponderDataReady()
        {
            //To be implemented

        }






    }
}
