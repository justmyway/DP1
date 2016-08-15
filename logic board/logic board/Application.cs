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

namespace logic_board
{
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }

        private void Application_Load(object sender, EventArgs e)
        {

        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {

            openFileDialog.Title = "Open een logisch circuit";
            openFileDialog.Filter = "Text Files (.txt)|*.txt|Circuits (.cir)|*.cir";

            try {
                if (openFileDialog.ShowDialog() == DialogResult.OK) {

                    StreamReader readedFile = new StreamReader(File.OpenRead(openFileDialog.FileName));

                    labelFileName.Text = openFileDialog.SafeFileName;
                    textBoxBoardFormat.Text = readedFile.ReadToEnd();

                    readedFile.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Opening File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {

            openFileDialog.Title = "Save een logisch circuit";
            openFileDialog.Filter = "Text Files (.txt)|*.txt|Circuits (.cir)|*.cir";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(File.Create(saveFileDialog.FileName));
                    sw.Write(textBoxBoardFormat.Text);
                    sw.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Saving File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
