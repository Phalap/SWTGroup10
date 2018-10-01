using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver; //Needed in order to use the TransponderReceiver dll

namespace ATM
{
    public class TransponderReceiver
    {
        private ITransponderReceiver receiver;


        public TransponderReceiver(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            // Just display data
            foreach (var data in e.TransponderData)
            {
                System.Console.WriteLine($"Transponderdata {data}");
            }

            foreach (var data in e.TransponderData)
            {
                List<string> TrackList = data.Split(';').ToList<string>();

                new TrackData(TrackList[0], double.Parse(TrackList[1]), double.Parse(TrackList[2]),
                    double.Parse(TrackList[3]), double.Parse(TrackList[4]), 0, 0);



            }
        }
    }

}
