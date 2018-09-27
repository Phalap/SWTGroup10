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

    class FakeLogger : ILogger
    {
        public int LogSeperationEvent_timesCalled { get; set; }

        public FakeLogger()
        {
            LogSeperationEvent_timesCalled = 0;
        }

        public void LogSeperationEvent(SeperationEvent seperationEvent)
        {
            LogSeperationEvent_timesCalled++;
        }
    }
}
