using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch sw;
        private readonly List<string> laps;
        
        public Chronometer()
        {
            sw = new Stopwatch();
            laps = new List<string>();
        }

        public string GetTime => sw.Elapsed.ToString(@"mm\:ss\:ffff");

        public List<string> Laps => laps;
        
        public void Start()
        {
            sw.Start();
        }

        public void Stop()
        {
            sw.Stop();
        }

        public string Lap()
        {
            var result = GetTime;
            
            laps.Add(result);
            
            return result;
        }

        public void Reset()
        {
            sw.Reset();
            laps.Clear();
        }
    }
}