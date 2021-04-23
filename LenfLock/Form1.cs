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
    public partial class Form1 : Form {
        string ans;
        public Form1() {
            InitializeComponent();

            short count = 3;
            TopMost = true;
            Random r = new Random();
            var num = Enumerable.Range(0, count).Select(x => r.Next(9)+1).ToList();
            var op = Enumerable.Repeat("*", count - 1).SelectMany(x => x).OrderBy(x => Guid.NewGuid()).Take(count - 1).ToList();
            string q = "";
            List<int> ansNum = new List<int>() { num[0] };
            for(int i = 0; i < count - 1; i++) {
                var la = ansNum.Last();
                switch(op[i]) {
                    case '*':
                        ansNum.Add(la * num[i + 1]);
                        ansNum.Remove(la);
                        break;
                    default:
                        ansNum.Add(num[i + 1]);
                        break;
                }
                q += $"{num[i]} {op[i]} ";
            }
            q += num[count - 1];
            label1.Text = $"Question：{q}";
            ans = ansNum.Sum().ToString();
            FormClosing += closing;
            button1.Click += (x, e) => {
                if(textBox1.Text.Trim(new char[] {'\n','\r',' ' }) == ans) {
                    FormClosing -= closing;
                    Close();
                }
            };
            textBox1.KeyDown += (x, e) =>{
                if(e.KeyCode == Keys.Enter && textBox1.Text.Trim(new char[] { '\n', '\r', ' ' }) == ans) {
                    FormClosing -= closing;
                    Close();
                }
            };
        }
        public void closing(object x, FormClosingEventArgs e) {
            e.Cancel = true;
        }
    }
}
