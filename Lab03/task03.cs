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
            dataGridView1.Columns.Add("Numbers", "Valid Numbers");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Take input from the RichTextBox
            string inputText = richTextBox1.Text;
            // Split the input based on spaces
            string[] words = inputText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // Regular expression for matching the specific floating-point format
            Regex regex = new Regex(@"^[1-9]\d*e[+-]?\d+$");

            // Clear the DataGridView before adding new results
            dataGridView1.Rows.Clear();

            foreach (string word in words)
            {
                Match match = regex.Match(word);

                if (match.Success)
                {
                    // Add valid numbers to the DataGridView
                    dataGridView1.Rows.Add(word);
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