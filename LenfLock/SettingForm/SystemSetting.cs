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
    public partial class SystemSetting : Form {
        public SystemSetting() {
            InitializeComponent();
            textBox1.Text = QuestionData.instance.System.TimeForRecall.ToString();
            button1.Click += (x, e) => {
                int time;
                if(!int.TryParse(textBox1.Text, out time)) {
                    MessageBox.Show("請輸入數字");
                    return;
                }

                QuestionData.instance.System.TimeForRecall = time;
                try {
                    QuestionData.Save();
                    MessageBox.Show("儲存成功");
                } catch(Exception err) {
                    MessageBox.Show(err.Message);
                }
                MainInterface.add(new Setting());
            };
        }
    }
}
