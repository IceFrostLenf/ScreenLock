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
    public partial class MainInterface : Form {
        public static Panel panel;
        public static TableLayoutPanel tableLayoutPanel;
        public MainInterface() {
            InitializeComponent();
            panel = panel1;
            tableLayoutPanel = tableLayoutPanel1;
        }
        public void setvisible(bool value) {
            SetVisibleCore(value);
        }
    }
}
