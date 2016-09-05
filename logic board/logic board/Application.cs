using logic_board.Model;
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

        Board circuit;
        BoardReader reader;

        public Application()
        {
            InitializeComponent();
            circuit = new Board();
            reader = new BoardReader();
        }

        private void Application_Load(object sender, EventArgs e)
        {
            addLogLine("--- application started ---");
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

                    addLogLine("\"" + openFileDialog.SafeFileName + "\" is loaded");
                }
            }
            catch (Exception ex)
            {
                addErrorLogLine(ex.Message);
                MessageBox.Show(ex.Message, "Opening File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {

            saveFileDialog.Title = "Save een logisch circuit";
            saveFileDialog.Filter = "Text Files (.txt)|*.txt|Circuits (.cir)|*.cir";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(File.Create(saveFileDialog.FileName));
                    sw.Write(textBoxBoardFormat.Text);
                    sw.Dispose();

                    addLogLine("\"" + saveFileDialog.FileName + "\" is saved");
                }
            }
            catch (Exception ex)
            {
                addErrorLogLine(ex.Message);
                MessageBox.Show(ex.Message, "Saving File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNewLogLine(String newLine) {
            if (textBoxLog.Text.Length == 0)
            {
                textBoxLog.AppendText(newLine);
            }
            else
            {
                textBoxLog.AppendText(Environment.NewLine + newLine);
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }   
        }

        public void addLogLine(String newLine) {
            addNewLogLine(newLine);
        }

        public void addMultipleLogLine(String[] newLine) {
            foreach (String line in newLine)
                addNewLogLine(line);
        }

        public void addErrorLogLine(String newLine)
        {
            addNewLogLine("A error occurred:");
            addNewLogLine("-> " + newLine);
        }

        public void addMultipleErrorLogLine(String[] newLines) {
            addNewLogLine("A error occurred:");
            foreach (String newLine in newLines)
                addNewLogLine("-> " + newLine);
        }

        private void buttonRunFile_Click(object sender, EventArgs e)
        {
            if (textBoxBoardFormat.Text.Length == 0) {
                addErrorLogLine("No circuit to run.");
            }
            else
            {
                addLogLine("--- start to process circuit ---");

                reader.read(textBoxBoardFormat.Text);

                addLogLine("--- verify renderd circuit ---");

                circuit.setInputProbes(reader.InputProbes);
                circuit.setOutputProbes(reader.OutputProbes);

                //todo
                //draw rendered circuit
            }
        }
    }
}
