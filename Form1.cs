using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day6AdvWinFormslab
{
    public partial class Notes : Form
    {
        public Notes()
        {
            InitializeComponent();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                rtbtxt.SaveFile(saveFileDialog1.FileName + ".rtf");
                rtbtxt.Clear();
                MessageBox.Show("Text Saved");

            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbtxt.Clear();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "")
            {
                rtbtxt.SaveFile(openFileDialog1.FileName);
                openFileDialog1.FileName = "";
                rtbtxt.Clear();
                MessageBox.Show("File Saved");

            }



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                rtbtxt.LoadFile(openFileDialog1.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are Want to save work", "Ask", MessageBoxButtons.OKCancel);
            if (d == DialogResult.OK)
                if (rtbtxt.Text != "" && openFileDialog1.FileName != "")
                {
                    rtbtxt.SaveFile(openFileDialog1.FileName);

                }
            if (d == DialogResult.Cancel)
                this.Close();
                
            if (rtbtxt.Text == "")
            {
                this.Close();
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
                this.Close();
            }

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbtxt.Text != "")
            {

                rtbtxt.Copy();
                MessageBox.Show("Text Copied To Clipboard");
            }

            else
                MessageBox.Show("No Thing to Copy");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                rtbtxt.Text += Clipboard.GetText();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbtxt.Text != "" && rtbtxt.SelectedText != "")
            {
                rtbtxt.Cut();
                MessageBox.Show("Text Cuted To Clipboard");
            }
            else { MessageBox.Show("Please Select Text To Cut"); }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (rtbtxt.Text != "" && rtbtxt.SelectedText != "")
            {
                rtbtxt.Text = rtbtxt.Text.Remove(rtbtxt.SelectionStart);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult f = fontDialog1.ShowDialog();
            if (f == DialogResult.OK && rtbtxt.Text != "" && rtbtxt.SelectedText == "")
            {
                rtbtxt.Font = fontDialog1.Font;


            }
            else if (f == DialogResult.OK && rtbtxt.SelectedText != "")
            {
                rtbtxt.SelectionFont = fontDialog1.Font;


            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = colorDialog1.ShowDialog();
            if (d == DialogResult.OK && rtbtxt.Text != "" && rtbtxt.SelectedText == "")
            {
                rtbtxt.ForeColor = colorDialog1.Color;
            }
            else if (d == DialogResult.OK && rtbtxt.SelectedText != "")
                rtbtxt.SelectionColor = colorDialog1.Color;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font currentFont = rtbtxt.SelectionFont;
            float s = currentFont.Size;
            FontStyle newFontStyle = (FontStyle)(currentFont.Style);
            rtbtxt.SelectionFont = new Font(currentFont.FontFamily, s+10, newFontStyle);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font currentFont = rtbtxt.SelectionFont;
            float s = currentFont.Size;
            FontStyle newFontStyle = (FontStyle)(currentFont.Style);
            if (s>10)
            {
                rtbtxt.SelectionFont = new Font(currentFont.FontFamily, s-10, newFontStyle);
            }
           
        }

        
    }
}

