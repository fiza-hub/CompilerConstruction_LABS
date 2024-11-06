using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Take input from the RichTextBox
            string inputText = richTextBox1.Text;
            // Split the input based on spaces
            string[] words = inputText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // Regular expression for validating floating point numbers with length <= 6
            Regex regex = new Regex(@"^[+-]?(\d{1,5}(\.\d{0,5})?|\.\d{1,5})([eE][+-]?\d{1,2})?$");

            // Clear the output RichTextBox before adding new results
            richTextBox2.Clear();

            foreach (string word in words)
            {
                // Check if the word's length is within the limit
                if (word.Length > 6)
                {
                    MessageBox.Show($"Invalid: {word} (Length exceeds 6 characters)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                Match match = regex.Match(word);

                if (match.Success)
                {
                    // Append valid numbers to the output RichTextBox
                    richTextBox2.AppendText(word + " ");
                }
                else
                {
                    // Show a message box for invalid numbers
                    MessageBox.Show($"Invalid number: {word}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}