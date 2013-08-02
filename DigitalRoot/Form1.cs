using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DigitalRoot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int digitalRoot(string word)
        {
            int vv = word.ToUpper().ToCharArray().Select((c) =>
            {
                int v = (int)(c - 'A') + 1;
                string sv = v.ToString();
                while (v > 9)
                {
                    v = sv.ToCharArray().Select((cc) => (int)(cc - '0')).Sum();
                    sv = v.ToString();
                }
                return v;
            }).Sum();
            string svv = vv.ToString();
            while (vv > 9)
            {
                vv = svv.ToCharArray().Select((c) => (int)(c - '0')).Sum();
                svv = vv.ToString();
            }
            return vv;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var reader = new StreamReader("dict.txt");

            var list = new List<string>();
            while (!reader.EndOfStream)
                list.Add(reader.ReadLine());

            foreach (string word in list)
            {
                string newWord = word.Replace("'", "");
                int v = digitalRoot(newWord);
                if (!_words.ContainsKey(v))
                    _words[v] = new List<string>();
                _words[v].Add(word.ToUpper());
            }
        }

        Dictionary<int, List<string>> _words = new Dictionary<int, List<string>>();
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int val = 0;
            int.TryParse(textBox1.Text, out val);
            listBox1.Items.Clear();
            if (_words.ContainsKey(val))
            {
                _words[val].Sort();
                listBox1.Items.AddRange(_words[val].ToArray());
            }
        }
    }
}
