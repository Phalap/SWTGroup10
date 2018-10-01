using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATM;
using TransponderReceiver; //Needed in order to use the TransponderReceiver dll


namespace ConsoleApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // MATHIAS TEST
            /*
            double timestamp = 235928121999;

            IRenderer renderer = new ConsoleRenderer();

            List<TrackData> involvedTracks = new List<TrackData>();
            involvedTracks.Add(new TrackData("ABC", 10000, 10000, 1000, timestamp, 150, 50));
            involvedTracks.Add(new TrackData("DEF", 10001, 10001, 1001, timestamp, 150, 50));

            SeperationEvent seperationEvent = new SeperationEvent(timestamp, involvedTracks, true);

            renderer.RenderSeperationEvent(seperationEvent);

            TrackData trackData = new TrackData("XYZ", 100, 200, 300, timestamp, 10, 270);
            
            renderer.RenderTrack(trackData);

            Console.ReadLine();
            */

            // TEST AF SYSTEM UDEN SEPARATION EVENT
            FileLogger filelogger = new FileLogger();
            ConsoleRenderer consolerender = new ConsoleRenderer();
            Airspace airspace = new Airspace(10000, 90000, 10000, 90000, 500, 20000);

            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            var system = new ATM.TransponderReceiver(receiver);

            ATMclass atm = new ATMclass(filelogger, consolerender, airspace);
            system.Attach(atm);

            // TEST AF SYSTEM MED SEPARATION EVENTS
            TrackData trackData1 = new TrackData("TEST1", 12000, 12000, 1000, "14322018", 10, 270);
            TrackData trackData2 = new TrackData("TEST2", 12000, 12000, 1000, "14322018", 10, 270);
  
            atm._currentTracks.Add(trackData1);

            atm.CheckForSeperationEvents(trackData2);
            atm.CheckForSeperationEvents(trackData2);

            // TEST AF SYSTEM MED LOGGER

            while (true)
                Thread.Sleep(1000);
        }
    }
}
