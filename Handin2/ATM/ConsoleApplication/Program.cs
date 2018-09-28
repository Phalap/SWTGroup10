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

            List<string> involvedTracks = new List<string>();
            involvedTracks.Add("ABC");
            involvedTracks.Add("DEF");

            SeperationEvent seperationEvent = new SeperationEvent(timeOfOccurence, involvedTracks, true);

            renderer.RenderSeperationEvent(seperationEvent);

            TrackData trackData = new TrackData("XYZ", 100, 200, 300, 10, 270);
            
            

            renderer.RenderTrack(trackData);

            Console.ReadLine();
        }
    }
}
