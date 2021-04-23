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
        static NotifyIcon notifyIcon;
        static ImageList imageList;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            QuestionData.Load();

            // init 
            mainInterface = new MainInterface(Closing, out panel, out tableLayoutPanel, out notifyIcon);
            //mainInterface.show();
            hide();


            //TimeingSystem timeingSystem = new TimeingSystem(30, show);

            // NotifyIcon
            notifyIcon.ContextMenu = new ContextMenu();
            notifyIcon.ContextMenu.MenuItems.Add("AAA", (x, e) => { });

            Program.add(new Question());


            Application.Run(mainInterface);

            //Form form = new Form();
            //form.FormBorderStyle = FormBorderStyle.None;
            //form.Bounds = Screen.AllScreens[0].Bounds;
            //form.WindowState = FormWindowState.Maximized;
            //Application.Run(form);
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
            notifyIcon.Visible = false;
        };
        public static Action hide = () => {
            mainInterface.Hide();
            notifyIcon.Visible = true;
        };
        public static void Close() {
            mainInterface.FormClosing -= Closing;
            mainInterface.Close();
        }
        public static FormClosingEventHandler Closing = (x, e) => e.Cancel = true;
    }
}
