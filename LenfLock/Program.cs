using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Time = System.Timers;
using System.Threading;

namespace LenfLock {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Load Storage
            QuestionData.Load();
            // Run
            Application.Run(new MainInterface());
        }
    }
}
