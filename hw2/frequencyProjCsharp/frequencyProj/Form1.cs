using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;





namespace frequencyProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Width = 300;
            textBox1.Height = 300;
            textBox1.Multiline = true;
            StreamReader reader = new StreamReader("C:/Users/miche/source/repos/frequencyProj/frequencyProj/languageFile");
            List<string> lines = new List<string>();
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                string[] words = line.Split(' ', '.', ',', ';', '-'); // Split words based on delimiters
                foreach (string word in words)
                {
                    string cleanedWord = word.Trim().ToLower(); // Clean and convert to lowercase
                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        if (wordFrequency.ContainsKey(cleanedWord))
                        {
                            wordFrequency[cleanedWord]++;
                        }
                        else
                        {
                            wordFrequency[cleanedWord] = 1;
                        }
                    }
                }
            }

            String result= "\"Word Frequency Distribution:" + Environment.NewLine;
    
            foreach (var pair in wordFrequency)
            {
                result += $"{pair.Key}: {pair.Value}"+ Environment.NewLine;
            }

            textBox1.Text = result;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Width = 300;
            textBox2.Height = 300;
            textBox2.Multiline = true;
            StreamReader reader = new StreamReader("C:/Users/miche/source/repos/frequencyProj/frequencyProj/ageFile.txt");
            List<string> lines = new List<string>();
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                string[] words = line.Split(' ', '.', ',', ';', '-'); // Split words based on delimiters
                foreach (string word in words)
                {
                    string cleanedWord = word.Trim().ToLower(); // Clean and convert to lowercase
                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        if (wordFrequency.ContainsKey(cleanedWord))
                        {
                            wordFrequency[cleanedWord]++;
                        }
                        else
                        {
                            wordFrequency[cleanedWord] = 1;
                        }
                    }
                }
            }

            String result = "\"Age Frequency Distribution:" + Environment.NewLine;

            foreach (var pair in wordFrequency)
            {
                result += $"{pair.Key}: {pair.Value}" + Environment.NewLine;
            }

            textBox2.Text = result;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Width = 300;
            textBox3.Height = 300;
            textBox3.Multiline = true;
            StreamReader reader = new StreamReader("C:/Users/miche/source/repos/frequencyProj/frequencyProj/weight.txt");
            List<string> lines = new List<string>();
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                string[] words = line.Split(' ', ',', ';', '-'); // Split words based on delimiters
                foreach (string word in words)
                {
                    string cleanedWord = word.Trim().ToLower(); // Clean and convert to lowercase
                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        if (wordFrequency.ContainsKey(cleanedWord))
                        {
                            wordFrequency[cleanedWord]++;
                        }
                        else
                        {
                            wordFrequency[cleanedWord] = 1;
                        }
                    }
                }
            }

            String result = "\"Weight Frequency Distribution:" + Environment.NewLine;

            foreach (var pair in wordFrequency)
            {
                result += $"{pair.Key}: {pair.Value}" + Environment.NewLine;
            }

            textBox3.Text = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible==false)
            {
                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox4.Visible = false;
            }
            else
            {
                textBox1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Visible == false)
            {
                textBox2.Visible = true;
                textBox1.Visible=false;
                textBox3.Visible = false;
                textBox4.Visible = false;

            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Visible == false)
            {
                textBox3.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox4.Visible = false;
            }
            else
            {
                textBox3.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Visible == false)
            {
                textBox4.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible=false;
            }
            else
            {
                textBox4.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Width = 300;
            textBox4.Height = 300;
            textBox4.Multiline = true;
            textBox4.ScrollBars = ScrollBars.Both;

            string[] lines = File.ReadAllLines("C:/Users/miche/source/repos/frequencyProj/frequencyProj/bivariate.txt");
            List<Tuple<string, string>> dataPairs = new List<Tuple<string, string>>();

            foreach (string line in lines)
            {
                string[] values = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length >= 2)
                {
                    dataPairs.Add(new Tuple<string, string>(values[0], values[1]));
                }
            }

            Dictionary<Tuple<string, string>, int> frequencyDict = new Dictionary<Tuple<string, string>, int>();
            foreach (var pair in dataPairs)
            {
                if (frequencyDict.ContainsKey(pair))
                {
                    frequencyDict[pair]++;
                }
                else
                {
                    frequencyDict[pair] = 1;
                }
            }
            Dictionary<string, int> absoluteFrequencyDict = new Dictionary<string, int>();
            foreach (var pair in frequencyDict)
            {
                string key = $"{pair.Key.Item1}, {pair.Key.Item2}";
                absoluteFrequencyDict[key] = pair.Value;
            }
            int totalPairs = dataPairs.Count;

            Dictionary<string, double> relativeFrequencyDict = new Dictionary<string, double>();
            foreach (var pair in absoluteFrequencyDict)
            {
                relativeFrequencyDict[pair.Key] = (double)pair.Value / totalPairs;
            }

            Dictionary<string, double> percentageFrequencyDict = new Dictionary<string, double>();
            foreach (var pair in relativeFrequencyDict)
            {
                percentageFrequencyDict[pair.Key] = pair.Value * 100;
            }



            StringBuilder result = new StringBuilder();
            foreach (var pair in frequencyDict)
            {
                string key = $"{pair.Key.Item1}, {pair.Key.Item2}";
                result.AppendLine($"{pair.Key.Item1} with and age that is equal to {pair.Key.Item2} are");
                result.AppendLine($"Absolute Frequency: { absoluteFrequencyDict[key]},Relative Frequency: {relativeFrequencyDict[key]:F4}, Percentage Frequency: {percentageFrequencyDict[key]:F2}%");
                result.AppendLine();
            }

            textBox4.Text = result.ToString();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
