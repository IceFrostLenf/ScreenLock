using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time = System.Timers;
using System.Windows.Forms;

namespace LenfLock {
    public partial class MainInterface : Form {

        public static MainInterface instance;
        Panel panel;
        TableLayoutPanel tableLayoutPanel;
        NotifyIcon notifyIcon;
        List<Form> AllScreens;

        public MainInterface() {
            InitializeComponent();
            init();

            add(new Question());
        }
        private void init() {
            //property
            instance = this;
            panel = panel1;
            tableLayoutPanel = tableLayoutPanel1;
            notifyIcon = notifyIcon1;
            AllScreens = new List<Form>(Screen.AllScreens.Length);

            //init
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormClosing += Closing;

            //notifyIcon
            notifyIcon1.ContextMenu = new ContextMenu();
            notifyIcon1.Visible = false;
            notifyIcon1.ContextMenu.MenuItems.Add("Exit", (x, e) => { FormClosing -= Closing; Close(); });

            // All Screen Lock
            for(int i = 0; i < AllScreens.Count; i++) {
                AllScreens[i] = new Form();
                AllScreens[i].FormBorderStyle = FormBorderStyle.None;
                AllScreens[i].Bounds = Screen.AllScreens[i].Bounds;
                AllScreens[i].WindowState = FormWindowState.Maximized;
            }

        }
        public static void add(Form form) {
            form.TopLevel = false;
            instance.panel.Controls.Clear();
            instance.panel.Controls.Add(form);
            instance.tableLayoutPanel.ColumnStyles[1].Width = form.Size.Width;
            instance.tableLayoutPanel.RowStyles[1].Height = form.Size.Height;
            form.Show();
        }

        private Action<Task> show = (x) => {
            instance.Show();
            instance.AllScreens.ForEach(x => x.Visible = true);
            instance.notifyIcon.Visible = false;
        };
        public void hide() {
            instance.Hide();
            AllScreens.ForEach(x => x.Visible = false);
            notifyIcon.Visible = true;

            Task.Delay(QuestionData.instance.System.TimeForRecall * 60000).ContinueWith(show);
        }

        FormClosingEventHandler Closing = (x, e) => e.Cancel = true;
    }
}
