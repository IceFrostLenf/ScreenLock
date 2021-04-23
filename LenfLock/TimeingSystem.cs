using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LenfLock {
    class TimeingSystem {
        public static int timeForUse;
        public static EventHandler UseCall;
        static Timer timerUse;
        public TimeingSystem(int timeForUse, ElapsedEventHandler RestCall) {
            timerUse = new Timer();
            timerUse.Interval = timeForUse * 60;
            timerUse.Elapsed += RestCall;
            timerUse.AutoReset = false;

        }
        public void StartRest() {
            timerUse.Start();
        }
    }
}
