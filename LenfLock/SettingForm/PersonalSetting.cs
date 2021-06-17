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
    public partial class PersonalSetting : Form {
        public PersonalSetting() {
            InitializeComponent();
            button1.Click += (x, e) => {
                if(textBox1.Text != QuestionData.instance.Pinstance.password) {
                    MessageBox.Show("舊密碼輸入錯誤");
                    return;
                }
                if(textBox2.Text != textBox3.Text) {
                    MessageBox.Show("新密碼不相符");
                    return;
                }

                QuestionData.instance.Pinstance.password = textBox2.Text;
                try {
                    QuestionData.Save();
                    MessageBox.Show("儲存成功");
                } catch(Exception err) {
                    MessageBox.Show(err.Message);
                }
                MainInterface.instance.add(new Setting());
            };
        }
    }
}
