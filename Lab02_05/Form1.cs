using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_05
{
    public partial class frmDocument : Form
    {
        public frmDocument()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tscFont.Text = "Tahoma";
            tscSize.Text = "14";

            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                tscFont.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                tscSize.Items.Add(s);
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() == DialogResult.Cancel)
            {
                rtbText.ForeColor = fontDlg.Color;
                rtbText.Font = fontDlg.Font;
            }
        }

        private void NewDocument()
        {
            rtbText.Clear();
            rtbText.Font = new Font("Tahoma", 14);
            tscFont.Text = "Tahoma";
            tscSize.Text = "14";
        }

        private void OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        rtbText.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        rtbText.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }

                }
            }
        }

        private void SavingFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf| Text File (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rtbText.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    rtbText.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }

            }
        }

        private void Bold()
        {
            FontStyle style = rtbText.SelectionFont.Style;

            if (rtbText.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;
            }
            rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);
        }

        private void Italic()
        {
            FontStyle style = rtbText.SelectionFont.Style;

            if (rtbText.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;
            }
            rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);

        }

        private void Underline()
        {
            FontStyle style = rtbText.SelectionFont.Style;

            if (rtbText.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            rtbText.SelectionFont = new Font(rtbText.SelectionFont, style);
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SavingFile();
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingFile();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Italic();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Underline();
        }

        private void tscFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtbText.SelectionFont != null)
            {
                string selectionFont = tscFont.Text;
                float currentSize = rtbText.SelectionFont.Size;
                rtbText.SelectionFont = new Font(selectionFont, currentSize, rtbText.SelectionFont.Style);
            }      
        }

        private void tscSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtbText.SelectionFont != null)
            {
                string currentFont = rtbText.SelectionFont.FontFamily.Name;
                float selectedSize = float.Parse(tscSize.Text);
                rtbText.SelectionFont = new Font(currentFont, selectedSize, rtbText.SelectionFont.Style);
            }
        }
    }
}

