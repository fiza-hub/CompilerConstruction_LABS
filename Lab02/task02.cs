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
            dataGridView1.Columns.Add("Words", "Matched Words");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Take input from the RichTextBox
            string inputText = richTextBox1.Text;
            // Regular expression for matching words starting with 't' or 'm'
            Regex regex = new Regex(@"\b[tTmM]\w*\b");

            // Clear the DataGridView before adding new results
            dataGridView1.Rows.Clear();

            // Find matches
            MatchCollection matches = regex.Matches(inputText);

            foreach (Match match in matches)
            {
                // Add matched words to the DataGridView
                dataGridView1.Rows.Add(match.Value);
            }

            if (matches.Count == 0)
            {
                MessageBox.Show("No words starting with 't' or 'm' found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}