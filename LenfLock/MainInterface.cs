using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using Time = System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LenfLock {
    public partial class MainInterface : Form {
        public bool isShow;

        public static MainInterface instance;
        Panel panel;
        TableLayoutPanel tableLayoutPanel;
        NotifyIcon notifyIcon;
        List<Form> allScreens;
        Time.Timer lateShow;

        Form currentForm;

        public MainInterface() {
            InitializeComponent();
            init();

            add(new Question());
        }
        private void init() {
            //property
            isShow = true;

            instance = this;
            panel = panel1;
            tableLayoutPanel = tableLayoutPanel1;
            notifyIcon = notifyIcon1;
            allScreens = new List<Form>(Screen.AllScreens.Length);

            //init
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormClosing += Closing;

            //notifyIcon
            notifyIcon1.ContextMenu = new ContextMenu();
            notifyIcon1.Visible = false;
            notifyIcon1.ContextMenu.MenuItems.Add("Exit", (x, e) => { FormClosing -= Closing; Close(); });

            // All Screen Lock
            for(int i = 0; i < allScreens.Count; i++) {
                allScreens[i] = new Form();
                allScreens[i].FormBorderStyle = FormBorderStyle.None;
                allScreens[i].Bounds = Screen.AllScreens[i].Bounds;
                allScreens[i].WindowState = FormWindowState.Maximized;
            }

            // timer
            lateShow = new Time.Timer(QuestionData.instance.System.TimeForRecall * 60000);
            lateShow.SynchronizingObject = instance;
            lateShow.AutoReset = false;
            lateShow.Elapsed += (x, e) => show();
        }
        public void add(Form form) {
            currentForm = form;

            form.TopLevel = false;
            instance.panel.Controls.Clear();
            instance.panel.Controls.Add(form);
            instance.tableLayoutPanel.ColumnStyles[1].Width = form.Size.Width;
            instance.tableLayoutPanel.RowStyles[1].Height = form.Size.Height;
            form.Show();
        }
        public void show() {
            (currentForm as Question).start();
            lateShow.Stop();

            instance.isShow = true;
            instance.Show();
            instance.allScreens.ForEach(x => x.Visible = true);
            instance.notifyIcon.Visible = false;
        }
        public void hide() {
            instance.isShow = false;
            instance.Hide();
            allScreens.ForEach(x => x.Visible = false);
            notifyIcon.Visible = true;

            lateShow.Start();
        }

        FormClosingEventHandler Closing = (x, e) => e.Cancel = true;
    }
}