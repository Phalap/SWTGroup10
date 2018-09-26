using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver; //Needed in order to use the TransponderReceiver dll

namespace ATM
{
        public class RawTransponderDataEventArgs : EventArgs
        {
            public RawTransponderDataEventArgs(List<string> transponderData)
            {
                TransponderData = transponderData;
            }
            public List<string> TransponderData { get; }
        }
        public interface ITransponderReceiver
        {
            event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
        }

}
