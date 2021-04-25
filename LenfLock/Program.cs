using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Time = System.Timers;
using System.Threading;

namespace LenfLock {
    static class Program {
        static Panel panel;
        static TableLayoutPanel tableLayoutPanel;
        static MainInterface mainInterface;
        static List<Form> AllScreens;
        static NotifyIcon notifyIcon;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Load Storage
            QuestionData.Load();
            // init 
            mainInterface = new MainInterface(Closing, out panel, out tableLayoutPanel, out notifyIcon);
            // NotifyIcon
            notifyIcon.ContextMenu = new ContextMenu();
            notifyIcon.Visible = false;
            notifyIcon.ContextMenu.MenuItems.Add("Exit", (x, e) => { mainInterface.FormClosing -= Closing; mainInterface.Close(); });
            // Load UI
            Program.add(new Question());
            // All Screen Lock
            AllScreens = new List<Form>(Screen.AllScreens.Length);
            for(int i = 0; i < AllScreens.Count; i++) {
                AllScreens[i] = new Form();
                AllScreens[i].FormBorderStyle = FormBorderStyle.None;
                AllScreens[i].Bounds = Screen.AllScreens[i].Bounds;
                AllScreens[i].WindowState = FormWindowState.Maximized;
            }
            // Run
            Application.Run(mainInterface);

        }
        public static void add(Form form) {
            form.TopLevel = false;
            panel.Controls.Clear();
            panel.Controls.Add(form);
            tableLayoutPanel.ColumnStyles[1].Width = form.Size.Width;
            tableLayoutPanel.RowStyles[1].Height = form.Size.Height;
            form.Show();
        }
        public static Time.ElapsedEventHandler show = (x, e) => {
            mainInterface.Show();
            AllScreens.ForEach(x => x.Visible = true);
            notifyIcon.Visible = false;
        };
        public static void hide() {
            mainInterface.Hide();
            AllScreens.ForEach(x => x.Visible = false);
            notifyIcon.Visible = true;

            Time.Timer timer = new Time.Timer(QuestionData.instance.System.TimeForRecall * 60000);
            timer.SynchronizingObject = mainInterface;
            timer.AutoReset = false;
            timer.Elapsed += show;
            timer.Start();
        }
        public static FormClosingEventHandler Closing = (x, e) => e.Cancel = true;
    }
}
