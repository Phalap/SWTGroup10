using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM.Unit.Tests
{
    [TestFixture]
    public class ATM_Unit_Tests
    {
        double xMin = 10000;
        double xMax = 90000;
        double yMin = 10000;
        double yMax = 90000;
        double zMin = 500;
        double zMax = 20000;
        IAirspace airspace;
        FakeLogger logger;
        IRenderer renderer;
        ITransponderReceiver TransponderReceiver;
        List<SeperationEvent> seperationEvents;
        List<TrackData> tracks;
        double timestamp;

        ATMclass uut;

        [SetUp]
        public void setup()
        {
            //Setup stuff
            airspace = new FakeAirspace(xMin, xMax, yMin, yMax, zMin, zMax);
            logger = new FakeLogger();
            renderer = new FakeRenderer();
            //Make new fake TransponderReceiver.
            seperationEvents = new List<SeperationEvent>();
            tracks = new List<TrackData>();
            timestamp = 235928121999;

            uut = new ATMclass(logger, renderer,TransponderReceiver, airspace);
        }

        #region logging

        [Test]
        public void logging_nothingCalled_MethodHasNotBeenCalled()
        {
            Assert.That(logger.LogSeperationEvent_timesCalled.Equals(0));
        }

        [Test]
        public void logging_logSeperationEvent_MethodHasBeenCalled()
        {
            TrackData trackData1 = new TrackData("ABC", 10000, 20000, 3000, timestamp, 100, 10);
            TrackData trackData2 = new TrackData("DEF", 10000, 20000, 3000, timestamp, 100, 10);
            List<TrackData> trackDatas = new List<TrackData>
            {
                trackData1,
                trackData2
            };
            SeperationEvent seperationEvent = new SeperationEvent(timestamp, trackDatas, true);

            uut.LogSeperationEvent(seperationEvent);
            Assert.That(logger.LogSeperationEvent_timesCalled.Equals(1));
        }

        public void logging_logSeperationEvent_Tag1IsSame()
        {
            TrackData trackData1 = new TrackData("ABC", 10000, 20000, 3000, timestamp, 100, 10);
            TrackData trackData2 = new TrackData("DEF", 10000, 20000, 3000, timestamp, 100, 10);
            List<TrackData> trackDatas = new List<TrackData>
            {
                trackData1,
                trackData2
            };
            SeperationEvent seperationEvent = new SeperationEvent(timestamp, trackDatas, true);

            uut.LogSeperationEvent(seperationEvent);
            Assert.That(logger.ParametersList[0]._InvolvedTracks[0]._Tag.Equals(seperationEvent._InvolvedTracks[0]._Tag));
        }

        public void logging_logSeperationEvent_Tag2IsSame()
        {
            TrackData trackData1 = new TrackData("ABC", 10000, 20000, 3000, timestamp, 100, 10);
            TrackData trackData2 = new TrackData("DEF", 10000, 20000, 3000, timestamp, 100, 10);
            List<TrackData> trackDatas = new List<TrackData>
            {
                trackData1,
                trackData2
            };
            SeperationEvent seperationEvent = new SeperationEvent(timestamp, trackDatas, true);

            uut.LogSeperationEvent(seperationEvent);
            Assert.That(logger.ParametersList[0]._InvolvedTracks[1]._Tag.Equals(seperationEvent._InvolvedTracks[1]._Tag));
        }

        public void logging_logSeperationEvent_OccurenteTimeIsSame()
        {
            TrackData trackData1 = new TrackData("ABC", 10000, 20000, 3000, timestamp, 100, 10);
            TrackData trackData2 = new TrackData("DEF", 10000, 20000, 3000, timestamp, 100, 10);
            List<TrackData> trackDatas = new List<TrackData>
            {
                trackData1,
                trackData2
            };
            SeperationEvent seperationEvent = new SeperationEvent(timestamp, trackDatas, true);

            uut.LogSeperationEvent(seperationEvent);
            Assert.That(logger.ParametersList[0]._OccurrenceTime.Equals(seperationEvent._OccurrenceTime));
        }
        #endregion

        public void logging_logSeperationEvent_RaisedIsSame()
        {
            TrackData trackData1 = new TrackData("ABC", 10000, 20000, 3000, timestamp, 100, 10);
            TrackData trackData2 = new TrackData("DEF", 10000, 20000, 3000, timestamp, 100, 10);
            List<TrackData> trackDatas = new List<TrackData>
            {
                trackData1,
                trackData2
            };
            SeperationEvent seperationEvent = new SeperationEvent(timestamp, trackDatas, true);

            uut.LogSeperationEvent(seperationEvent);
            Assert.That(logger.ParametersList[0]._IsRaised.Equals(seperationEvent._IsRaised));
        }

        #region rendering
        #endregion

        #region airspace
        [Test]
        public void airspace_coordinateInAirspace_returnsTrue()
        {
            Assert.That(()=>airspace.CheckIfInMonitoredArea(50000, 50000, 1000).Equals(true));
        }

        #region CoordinatesTooLow
        [Test]
        public void airspace_xCoordinateTooLow_returnsFalse()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(xMin-1, 50000, 1000).Equals(false));
        }

        [Test]
        public void airspace_yCoordinateTooLow_returnsFalse()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(50000, yMin-1, 1000).Equals(false));
        }

        [Test]
        public void airspace_zCoordinateTooLow_returnsFalse()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(50000, 50000, zMin-1).Equals(false));
        }
        #endregion

        #region CoordinatesTooHigh
        [Test]
        public void airspace_xCoordinateTooHigh_returnsFalse()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(xMax + 1, 50000, 1000).Equals(false));
        }

        [Test]
        public void airspace_yCoordinateTooHigh_returnsFalse()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(50000, yMax + 1, 1000).Equals(false));
        }

        [Test]
        public void airspace_zCoordinateTooHigh_returnsFalse()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(50000, 50000, zMax + 1).Equals(false));
        }
        #endregion

        #region CoordinatesLowerBoundary
        [Test]
        public void airspace_xCoordinateLowerBoundary_returnsTrue()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(xMin, 50000, 1000).Equals(true));
        }

        [Test]
        public void airspace_yCoordinateLowerBoundary_returnsTrue()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(50000, yMin, 1000).Equals(true));
        }

        [Test]
        public void airspace_zCoordinateLowerBoundary_returnsTrue()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(50000, 50000, zMin).Equals(true));
        }
        #endregion

        #region CoordinatesUpperBoundary
        [Test]
        public void airspace_xCoordinateUpperBoundary_returnsTrue()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(xMax, 50000, 1000).Equals(true));
        }

        [Test]
        public void airspace_yCoordinateUpperBoundary_returnsTrue()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(50000, yMax, 1000).Equals(true));
        }

        [Test]
        public void airspace_zCoordinateUpperBoundary_returnsTrue()
        {
            Assert.That(() => airspace.CheckIfInMonitoredArea(50000, 50000, zMax).Equals(true));
        }
        #endregion
        #endregion

        #region AddTrack
        [Test]
        public void AddTrack_NoTracksAdded_CountIs0()
        {
            Assert.That(() => uut._currentTracks.Count.Equals(0));
        }

        [Test]
        public void AddTrack_TrackAdded_CountIs1()
        {
            uut.AddTrack(new TrackData("ABC", 10000, 10000, 1000, timestamp, 100, 10));
            Assert.That(() => uut._currentTracks.Count.Equals(1));
        }

        [Test]
        public void AddTrack_10TracksAdded_CountIs10()
        {
            for (int i=0; i<10;i++)
            {
                uut.AddTrack(new TrackData("ABC"+i, 10000, 10000, 1000, timestamp, 100, 10));
            }

            Assert.That(() => uut._currentTracks.Count.Equals(10));
        }

        [Test]
        public void AddTrack_TrackAdded_TagInFirstListObjectMatchesTagOfAddedTrack()
        {
            TrackData testTrack = new TrackData("ABC", 10000, 10000, 1000, timestamp, 100, 10);
            uut.AddTrack(testTrack);
            Assert.That(() => uut._currentTracks[0]._Tag.Equals(testTrack._Tag));
        }

        [Test]
        public void AddTrack_AddTrackThenAddTrackWithSameTag_CountIs1()
        {
            TrackData testTrack1 = new TrackData("ABC", 10000, 10000, 1000, timestamp, 100, 10);
            TrackData testTrack2 = new TrackData("ABC", 20000, 10000, 1000, timestamp, 100, 10);
            uut.AddTrack(testTrack1);
            uut.AddTrack(testTrack2);
            Assert.That(() => uut._currentTracks.Count.Equals(1));
        }

        [Test]
        public void AddTrack_AddTrackThenAddTrackWithSameTag_XPositionOfObjectInListMatchesXPositionOfLastAddedTrack()
        {
            TrackData testTrack1 = new TrackData("ABC", 10000, 10000, 1000, timestamp, 100, 10);
            TrackData testTrack2 = new TrackData("ABC", 20000, 10000, 1000, timestamp, 100, 10);
            uut.AddTrack(testTrack1);
            uut.AddTrack(testTrack2);
            Assert.That(() => uut._currentTracks[0]._CurrentXcord.Equals(testTrack2._CurrentXcord));
        }
        #endregion

        #region RemoveTrack
        [Test]
        public void RemoveTrack_Add3TracksRemove1TrackWIthValidTag_CountIs2()
        {
            uut.AddTrack(new TrackData("ABC", 10000, 10000, 1000, timestamp, 100, 10));
            uut.AddTrack(new TrackData("DEF", 10000, 10000, 1000, timestamp, 100, 10));
            uut.AddTrack(new TrackData("GHI", 10000, 10000, 1000, timestamp, 100, 10));

            uut.RemoveTrack("ABC");

            Assert.That(() => uut._currentTracks.Count.Equals(2));
        }

        [Test]
        public void RemoveTrack_Add3TracksRemove1TrackWIthInvalidTag_ThrowsArgumentOutOfRangeException()
        {
            uut.AddTrack(new TrackData("ABC", 10000, 10000, 1000, timestamp, 100, 10));
            uut.AddTrack(new TrackData("DEF", 10000, 10000, 1000, timestamp, 100, 10));
            uut.AddTrack(new TrackData("GHI", 10000, 10000, 1000, timestamp, 100, 10));

            Assert.That(() => uut.RemoveTrack("XYZ"),Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void RemoveTrack_RemoveTrackFromEmptyList_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(() => uut.RemoveTrack("XYZ"), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        #endregion

        #region CheckForSeperationEvent
        [Test]
        public void CheckForSeperationEvent_TagsForTheTwoTracksAreTheSame_ThrowsException()
        {
            TrackData track1 = new TrackData("ABC", 10000, 10000, 1000, timestamp, 150, 50);

            string message = "Provided TrackDatas have the same Tag";

            Assert.That(() => uut.CheckForSeperationEvent(track1,track1), Throws.Exception.TypeOf<Exception>().With.Message.EqualTo(message));
        }

        [Test]
        public void CheckForSeperationEvent_NoConditionsMet_ReturnsFalse()
        {
            TrackData track1 = new TrackData("ABC", 10000, 10000, 1000, timestamp, 150, 50);
            TrackData track2 = new TrackData("DEF", 50000, 50000, 5000, timestamp, 150, 50);

            Assert.That(() => uut.CheckForSeperationEvent(track1, track2).Equals(false));
        }

        [Test]
        public void CheckForSeperationEvent_AllConditionsMet_ReturnsTrue()
        {
            TrackData track1 = new TrackData("ABC", 30000, 30000, 1000, timestamp, 150, 50);
            TrackData track2 = new TrackData("DEF", 30001, 30001, 1001, timestamp, 150, 50);

            Assert.That(() => uut.CheckForSeperationEvent(track1, track2).Equals(true));
        }

        [Test]
        public void CheckForSeperationEvent_OnlyXConditionMet_ReturnsFalse()
        {
            TrackData track1 = new TrackData("ABC", 50000-1, 10000, 1000, timestamp, 150, 50);
            TrackData track2 = new TrackData("DEF", 50000, 50000, 5000, timestamp, 150, 50);

            Assert.That(() => uut.CheckForSeperationEvent(track1, track2).Equals(false));
        }

        [Test]
        public void CheckForSeperationEvent_OnlyYConditionMet_ReturnsFalse()
        {
            TrackData track1 = new TrackData("ABC", 10000, 50000-1, 1000, timestamp, 150, 50);
            TrackData track2 = new TrackData("DEF", 50000, 50000, 5000, timestamp, 150, 50);

            Assert.That(() => uut.CheckForSeperationEvent(track1, track2).Equals(false));
        }

        [Test]
        public void CheckForSeperationEvent_OnlyZConditionMet_ReturnsFalse()
        {
            TrackData track1 = new TrackData("ABC", 10000, 10000, 5000-1, timestamp, 150, 50);
            TrackData track2 = new TrackData("DEF", 50000, 50000, 5000, timestamp, 150, 50);

            Assert.That(() => uut.CheckForSeperationEvent(track1, track2).Equals(false));
        }

        [Test]
        public void CheckForSeperationEvent_XandYConditionsMet_ReturnsFalse()
        {
            TrackData track1 = new TrackData("ABC", 50000-1, 50000-1, 1000, timestamp, 150, 50);
            TrackData track2 = new TrackData("DEF", 50000, 50000, 5000, timestamp, 150, 50);

            Assert.That(() => uut.CheckForSeperationEvent(track1, track2).Equals(false));
        }

        [Test]
        public void CheckForSeperationEvent_YandZConditionsMet_ReturnsFalse()
        {
            TrackData track1 = new TrackData("ABC", 10000, 50000 - 1, 5000-1, timestamp, 150, 50);
            TrackData track2 = new TrackData("DEF", 50000, 50000, 5000, timestamp, 150, 50);

            Assert.That(() => uut.CheckForSeperationEvent(track1, track2).Equals(false));
        }


        [Test]
        public void CheckForSeperationEvent_XandZConditionsMet_ReturnsFalse()
        {
            TrackData track1 = new TrackData("ABC", 50000-1, 10000, 5000 - 1, timestamp, 150, 50);
            TrackData track2 = new TrackData("DEF", 50000, 50000, 5000, timestamp,150, 50);

            Assert.That(() => uut.CheckForSeperationEvent(track1, track2).Equals(false));
        }
        #endregion


    }
}
