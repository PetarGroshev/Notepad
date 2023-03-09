namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстови файлове|*.txt|Word files|*.doc,docx|All files|*.*";
            openFileDialog1.ShowDialog();
            richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Текстови файлове|*.txt|Word files|*.doc,docx|All files|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.ShowDialog();
            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
            richTextBox1.SelectionColor = fontDialog1.Color;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified)
            {
                DialogResult result = MessageBox.Show("Искаш ли да се запази файла?","Запазване", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    menuSaveAs_Click(sender, e);
                }

                if(result == DialogResult.Cancel)
                {
                    richTextBox1.Clear();
                }
                
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Modified)
            {
                DialogResult result = MessageBox.Show("Искаш ли да се запази файла?", "Запазване", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    menuSaveAs_Click(sender, e);
                }

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }


            }
        }
    }
}