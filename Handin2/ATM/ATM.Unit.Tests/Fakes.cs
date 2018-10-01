using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Unit.Tests
{
    class FakeRenderer: IRenderer
    {
        public int RenderTrackData_TimesCalled { get; set; }
        public int RenderSeperationEvent_TimesCalled { get; set; }

        public FakeRenderer()
        {
            RenderSeperationEvent_TimesCalled = 0;
            RenderTrackData_TimesCalled = 0;
        }

        public void RenderSeperationEvent(SeperationEvent seperationEvent)
        {
            RenderSeperationEvent_TimesCalled++;
        }

        public void RenderTrack(TrackData trackData)
        {
            RenderTrackData_TimesCalled++;
        }
    }

    public class FakeLogger : ILogger
    {
        public int LogActiveSeparationEvent_timesCalled { get; set; }
        public int LogInactiveSeparationEvent_timesCalled { get; set; }
        public List<SeperationEvent> ParametersList { get; set; }

        public FakeLogger()
        {
            ParametersList = new List<SeperationEvent>();
            LogActiveSeparationEvent_timesCalled = 0;
            LogInactiveSeparationEvent_timesCalled = 0;
        }

        public void LogActiveSeparationEvent(SeperationEvent seperationEvent)
        {
            ParametersList.Add(seperationEvent);
            LogActiveSeparationEvent_timesCalled++;
        }

        public void LogInactiveSeparationEvent(SeperationEvent seperationEvent)
        {
            ParametersList.Add(seperationEvent);
            LogInactiveSeparationEvent_timesCalled++;
        }

    }

    class FakeAirspace : IAirspace
    {
        double _xMin { get; set; }
        double _xMax { get; set; }
        double _yMin { get; set; }
        double _yMax { get; set; }
        double _zMin { get; set; }
        double _zMax { get; set; }
        public FakeAirspace(double xMin, double xMax, double yMin, double yMax, double zMin, double zMax)
        {
            _xMin = xMin;
            _xMax = xMax;
            _yMin = yMin;
            _yMax = yMax;
            _zMin = zMin;
            _zMax = zMax;
        }
        
        public bool CheckIfInMonitoredArea(double xCord, double yCord, double zCord)
        {
            if(xCord<=_xMax && xCord>=_xMin) //Check if xMin<xCord<xMax
            {
                if (yCord <= _yMax && yCord >= _yMin) //Check if yMin<yCord<yMax
                {
                    if (zCord <= _zMax && zCord >= _zMin) //Check if zMin<zCord<zMax
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
