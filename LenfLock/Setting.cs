using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LenfLock {
    public partial class Setting : Form {
        public Setting() {
            InitializeComponent();
            button1.Click += (x, e) => {
                Program.add(new Question());
            };
        }

        private void 基本設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            add(new PersonalSetting());
        }
        private void 系統設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            add(new SystemSetting());
        }

        private void 數學設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            add(new MathSetting());
        }
        public void add(Form form) {
            form.TopLevel = false;
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Show();
        }

    }
}
