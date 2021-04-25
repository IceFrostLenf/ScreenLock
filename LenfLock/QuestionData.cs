using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LenfLock {
    public class QuestionData {
        #region Interface
        static QuestionData _i = null;
        public static QuestionData instance { get { return _i ??= new QuestionData(); } }

        public QPersonal Pinstance = new QPersonal();
        public QSystem System = new QSystem();
        public QMath Math = new QMath();
        public QChinese Chinese = new QChinese();
        #endregion
        #region SaveLoad
        static string Directoryname = $@".\LenfLock";
        static string Filename = "saveData.txt";

        public static void Save() {
            var question = JsonConvert.SerializeObject(instance);
            Directory.CreateDirectory(Directoryname);
            var filestream = File.Create($@"{Directoryname}\{Filename}");
            filestream.Close();
            File.WriteAllText($@"{Directoryname}\{Filename}", question);
        }
        public static void Load() {
            if(File.Exists($@"{Directoryname}\{Filename}")) {
                _i = JsonConvert.DeserializeObject<QuestionData>(File.ReadAllText($@"{Directoryname}\{Filename}"));
            }
        }
        #endregion
        #region Person
        public class QPersonal {
            public string password = "123";
        }
        #endregion
        #region System
        public class QSystem {
            public int TimeForRecall = 30;
        }
        #endregion

        #region Math
        public class QMath {
            public int minNum { get; set; }
            public int maxNum { get; set; }
            public int plusCount { get; set; }
            public int minusCount { get; set; }
            public int mutlyCount { get; set; }
            public QMath() {
                minNum = 3;
                maxNum = 9;
                plusCount = 1;
                minusCount = 0;
                mutlyCount = 0;
            }
            public Tuple<string, string> GenerateQuestion() {
                Random r = new Random();
                short count = (short)(plusCount + minusCount + mutlyCount + 1);
                var num = Enumerable.Range(0, count).Select(x => r.Next(maxNum - minNum + 1) + minNum).ToList();
                var op = Enumerable.Repeat('+', plusCount).Concat(Enumerable.Repeat('-', minusCount)).Concat(Enumerable.Repeat('*', mutlyCount)).OrderBy(x => Guid.NewGuid()).ToList();
                string q = "";
                List<int> ansNum = new List<int>() { num[0] };
                for(int i = 0; i < count - 1; i++) {
                    var la = ansNum.Last();
                    switch(op[i]) {
                        case '*':
                            ansNum.Add(la * num[i + 1]);
                            ansNum.Remove(la);
                            break;
                        case '-':
                            ansNum.Add(-num[i + 1]);
                            break;
                        default:
                            ansNum.Add(num[i + 1]);
                            break;
                    }
                    q += $"{num[i]} {op[i]} ";
                }
                q += num[count - 1];
                string ans = ansNum.Sum().ToString();
                return new Tuple<string, string>(q, ans);
            }
        }
        #endregion
        #region Chinese
        public class QChinese {
            public Tuple<string, string> GenerateQuestion() {
                return null;
            }
        }
        #endregion
    }
}
