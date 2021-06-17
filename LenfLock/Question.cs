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
    public partial class Question : Form {
        string ans;
        public Question() {
            InitializeComponent();

            textBox2.TextChanged += (x, e) => {
                if(textBox2.Text == QuestionData.instance.Pinstance.password)
                    MainInterface.instance.add(new Setting());
            };

            start();

            button1.Click += (x, e) => {
                if(textBox1.Text.Trim(new char[] { '\n', '\r', ' ' }) == ans) {
                    textBox1.Text = "";
                    MainInterface.instance.hide();
                }
            };
            textBox1.KeyDown += (x, e) => {
                if(e.KeyCode == Keys.Enter && textBox1.Text.Trim(new char[] { '\n', '\r', ' ' }) == ans) {
                    textBox1.Text = "";
                    MainInterface.instance.hide();
                }
            };
        }
        public void start() {
            var math = QuestionData.instance.Math.GenerateQuestion();
            label1.Text = $"Question：\n{math.Item1}";
            ans = math.Item2;
        }
    }
}
