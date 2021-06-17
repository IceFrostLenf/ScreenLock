using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text;

namespace LenfLock {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using(Mutex m = new Mutex(false, "ScreenLock")) {
                if(!m.WaitOne(0, false)) {
                    new LenfClient().Connect("127.0.0.1", 3141).Send("secondApp").DisConnect();
                } else {

                    // Load Storage
                    QuestionData.Load();
                    // lan Server
                    new LenfServer().Start();
                    // Run
                    Application.Run(new MainInterface());
                    m.ReleaseMutex();
                }
            }
        }
    }
}
