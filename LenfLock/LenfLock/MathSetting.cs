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
            textBoxes[0].Text = QuestionData.instance.Math.minNum.ToString();
            textBoxes[1].Text = QuestionData.instance.Math.maxNum.ToString();
            textBoxes[2].Text = QuestionData.instance.Math.plusCount.ToString();
            textBoxes[3].Text = QuestionData.instance.Math.minusCount.ToString();
            textBoxes[4].Text = QuestionData.instance.Math.mutlyCount.ToString();
            button1.Click += (x, e) => {
                int num;
                if(!textBoxes.All(x => int.TryParse(x.Text, out num))) {
                    MessageBox.Show("請確認輸入全為數字");
                } else {
                    List<int> nums = textBoxes.Select(x => int.Parse(x.Text)).ToList();
                    QuestionData.instance.Math = new QuestionData.QMath() {
                        minNum = nums[0],
                        maxNum = nums[1],
                        plusCount = nums[2],
                        minusCount = nums[3],
                        mutlyCount = nums[4]
                    };
                    try {
                        QuestionData.Save();
                        MessageBox.Show("儲存成功");
                    } catch(Exception err) {
                        MessageBox.Show(err.Message);
                    }
                    Program.add(new Question());
                }
            };
        }
    }
}
