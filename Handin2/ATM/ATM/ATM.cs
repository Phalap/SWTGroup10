﻿using System;
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
            bool flightExistFlag = false;
            for (int i = 0; i < _currentTracks.Count; i++)
            {
                if (_currentTracks[i]._Tag == trackdata._Tag)
                {
                    flightExistFlag = true;
                    _currentTracks[i]._CurrentXcord = trackdata._CurrentXcord;
                    _currentTracks[i]._CurrentYcord = trackdata._CurrentYcord;
                    _currentTracks[i]._CurrentZcord = trackdata._CurrentZcord;
                    _currentTracks[i]._CurrentCourse = trackdata._CurrentCourse;
                    _currentTracks[i]._CurrentHorzVel = trackdata._CurrentHorzVel;
                }
            }

            if (flightExistFlag == false)
            {
                AddFlight(trackdata);
            }
            

        }

        public void Update(TrackData trackData)
        {
            //Denne funktion er ikke nødvendig efter min menning, da det er nemmere at opdatere direkte i for-loopet i HandleNewTrackData.
        }

        public void AddFlight(TrackData trackData)
        {
            _currentTracks.Add(trackData);
        }

        public bool CheckForSeperationEvent(TrackData trackData1, TrackData trackData2)
        {

            //To be implemented

            return true;
        }

        public SeperationEvent GetSeperationEventInvolvedIn(TrackData trackData)
        {
            //To be implemented

            return null;
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
