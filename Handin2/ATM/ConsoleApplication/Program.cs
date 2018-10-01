using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            IRenderer renderer = new ConsoleRenderer();
            
            DateTime timeOfOccurence = DateTime.Now;

            List<TrackData> involvedTracks = new List<TrackData>();
            involvedTracks.Add(new TrackData("ABC", 10000, 10000, 1000, 150, 50));
            involvedTracks.Add(new TrackData("DEF", 10001, 10001, 1001, 150, 50));

            SeperationEvent seperationEvent = new SeperationEvent(timeOfOccurence, involvedTracks, true);

            renderer.RenderSeperationEvent(seperationEvent);

            TrackData trackData = new TrackData("XYZ", 100, 200, 300, 10, 270);
            
            

            renderer.RenderTrack(trackData);

            Console.ReadLine();
        }
    }
}
