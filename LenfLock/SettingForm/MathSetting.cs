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
    public partial class MathSetting : Form {
        public MathSetting() {
            InitializeComponent();
            List<TextBox> textBoxes = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5 };

            List<string> TextdataSource = new List<string>() { "minNum", "maxNum", "plusCount", "minusCount", "mutlyCount" };

            ErrorProvider error = new ErrorProvider();

            BindingSource math = new BindingSource(QuestionData.instance.Math, "");

            for(int i = 0; i < 5; i++) {
                textBoxes[i].Validating += (x, e) => {
                    error.SetError((x as TextBox), int.TryParse((x as TextBox).Text, out _) ? "" : "The value need to be a number");
                };
                textBoxes[i].DataBindings.Add("Text", math, TextdataSource[i], true);
            }
            button1.Click += (x, e) => {
                if(!textBoxes.All(x=>error.GetError(x) == "")) {
                    MessageBox.Show("請確認輸入是否正確");
                    return;
                }
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
