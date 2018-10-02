using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class ATMclass : IObserver
    {
        private ILogger _logger;
        private IRenderer _renderer;
        //private ITransponderReceiver _transponderReceiver;

        public List<TrackData> _currentTracks { get; }
        public List<SeperationEvent> _currentSeperationEvents { get; }

        private IAirspace _airspace;

        public ATMclass(ILogger logger, IRenderer renderer, IAirspace airspace)
        {
            _logger = logger;
            _renderer = renderer;
            //_transponderReceiver = transponderReceiver;
            _airspace = airspace;
            _currentSeperationEvents = new List<SeperationEvent>();
            _currentTracks = new List<TrackData>();
        }

        public void HandleNewTrackData(TrackData trackdata)
        {

            if (_currentTracks.Exists(x => x._Tag == trackdata._Tag) == false)
            {

                // Add the new track 
                if (_airspace.CheckIfInMonitoredArea(trackdata._CurrentXcord, trackdata._CurrentYcord,
                    trackdata._CurrentZcord))
                {
                    AddTrack(trackdata);
                }

                // Check for potential seperation events 
                CheckForSeperationEvents(trackdata);

                // Check if new track already is involved in separation event 


                // Render trackdata to console 
                RenderTracks();

                // Render seperationevents
                RenderSeperationEvents();
            }
            else
            {
                // Update trackdata
                TrackData trackToEdit = _currentTracks.Find(x => x._Tag == trackdata._Tag);
                trackToEdit._CurrentXcord = trackdata._CurrentXcord;
                trackToEdit._CurrentYcord = trackdata._CurrentYcord;
                trackToEdit._CurrentZcord = trackdata._CurrentZcord;
                trackToEdit._CurrentCourse = trackdata._CurrentCourse;
                trackToEdit._CurrentHorzVel = trackToEdit._CurrentHorzVel;

                // Remove tracks if out of airspace

                if (_airspace.CheckIfInMonitoredArea(trackToEdit._CurrentXcord, trackToEdit._CurrentYcord,
                    trackToEdit._CurrentZcord))
                {

                }
                else
                {
                    RemoveTrack(trackToEdit._Tag);
                }
                     

                // Check for potential seperation events
                CheckForSeperationEvents(trackToEdit);

                // Remove separations event after update
                RemoveSeparationEvents();

                // Render updated tracks to console 
                RenderTracks();

                // Render seperation events
                RenderSeperationEvents();
            }
            
        }

        public void AddTrack(TrackData trackData)
        {
            //Check if TrackData with given tag already exists.
            if(_currentTracks.Exists(x => x._Tag == trackData._Tag))
            {
                //Find index of existing data.
                int index = _currentTracks.FindIndex(x => x._Tag == trackData._Tag);
                //replace existing data with new data.
                _currentTracks[index] = trackData;
            }
            else
            {
                //Add trackData.
                _currentTracks.Add(trackData);
            }
            
        }

        public void RemoveTrack(string tag)
        {
            int index = _currentTracks.FindIndex(x => x._Tag.Equals(tag));
            _currentTracks.RemoveAt(index);
        }

        public void CheckForSeperationEvents(TrackData trackData)
        {
            foreach (var track in _currentTracks)
            {
                if (track._Tag == trackData._Tag)
                {

                }
                else
                    CheckForSeperationEvent(trackData, track);
            }
        }

        public bool CheckForSeperationEvent(TrackData trackData1, TrackData trackData2)
        {
            //Check if both tracks are the same
            if(trackData1._Tag==trackData2._Tag)
            {
                throw new Exception("Provided TrackDatas have the same Tag");
            }
            else
            {
                if (Math.Abs(trackData1._CurrentXcord - trackData2._CurrentXcord) < 10000 &&
                    Math.Abs(trackData1._CurrentYcord - trackData2._CurrentYcord) < 10000 &&
                    Math.Abs(trackData1._CurrentZcord - trackData2._CurrentZcord) < 20000)
                {
                    // Check if separation event already exists
                    if (GetSeperationEventInvolvedIn(trackData1, trackData2))
                    {
                        return true;
                    }
                    else
                    {
                        // Add new separation event 
                        string time = DateTime.Now.ToString();
                        List<TrackData> trackDataInSeperationEvent = new List<TrackData>();
                        trackDataInSeperationEvent.Add(trackData1);
                        trackDataInSeperationEvent.Add(trackData2);

                        SeperationEvent SeperationEvent = new SeperationEvent(time, trackDataInSeperationEvent, true);
                        _currentSeperationEvents.Add(SeperationEvent);
                        _logger.LogActiveSeparationEvent(SeperationEvent);
                        _logger.LogActiveSeparationEvent(SeperationEvent);
                        return true;
                    }

                }

                else
                    return false;
            }
        }

        public bool GetSeperationEventInvolvedIn(TrackData trackData1, TrackData trackData2)
        {

            if(_currentSeperationEvents.Exists(x => x._InvolvedTracks[0]._Tag == trackData1._Tag &&
                                                    x._InvolvedTracks[1]._Tag == trackData2._Tag) || 
               _currentSeperationEvents.Exists(x => x._InvolvedTracks[1]._Tag == trackData1._Tag &&
                                                    x._InvolvedTracks[0]._Tag == trackData2._Tag))
            {
                return true;
            }
            else
            {
                return false;
            }
                                                                                                                                          
        }


        public void RenderSeperationEvents()
        {
            foreach (var seperationEvent in _currentSeperationEvents)
            {
                _renderer.RenderSeperationEvent(seperationEvent);
            }
            Console.WriteLine("Number of separation events: " + _currentSeperationEvents.Count);
        }

        public void RenderTracks()
        {
            Console.Clear();

            foreach (var trackData in _currentTracks)
            {
                _renderer.RenderTrack(trackData);
            }

        }

        public void RemoveSeparationEvents()
        {
            foreach (var separationEvent in _currentSeperationEvents)
            {
                if (Math.Abs(separationEvent._InvolvedTracks[0]._CurrentXcord -
                             separationEvent._InvolvedTracks[1]._CurrentXcord) < 100000 &&
                    Math.Abs(separationEvent._InvolvedTracks[0]._CurrentYcord -
                             separationEvent._InvolvedTracks[1]._CurrentYcord) < 100000 &&
                    Math.Abs(separationEvent._InvolvedTracks[0]._CurrentZcord -
                             separationEvent._InvolvedTracks[1]._CurrentZcord) < 20000)
                {

                }
                else
                {
                    _currentSeperationEvents.Remove(separationEvent);
                    _logger.LogInactiveSeparationEvent(separationEvent);
                }
            }
        }

        public void Update(TrackData trackdata)
        {
            HandleNewTrackData(trackdata);
        }
        
    }
}
