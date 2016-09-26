using LogicBoard2._0.Logic;
using LogicBoard2._0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogicBoard2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ILoggeble
    {
        private BoardReader boardReader;
        private Circuit circuit;

        public MainWindow()
        {
            InitializeComponent();
            Log.Instance.AddRecipient(this);
            boardReader = new BoardReader();
        }

        public void DisplayLogLine(string[] logLines)
        {
            foreach(string newLogLine in logLines)
                LogBookText.AppendText(Environment.NewLine + newLogLine);

            //LogBookText.SelectionStart = LogBookText.Text.Length;
            LogBookText.CaretIndex = LogBookText.Text.Length;
            LogBookText.ScrollToEnd();
        }

        public void DisplayErrorLogLine(string[] logLines)
        {
            string[] errorLogLines = new string[logLines.Length+1];
            errorLogLines[0] = "A error occurred:";
            for (int i = 0; i < logLines.Length; i++) {
                errorLogLines[i + 1] = String.Format("-> {0}", logLines[i]);
            }

            DisplayLogLine(errorLogLines);
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.DefaultExt = "txt";
            fileDialog.Filter = "Text Files (.txt)|*.txt|Circuits (.cir)|*.cir";

            Nullable<bool> dialogResult = fileDialog.ShowDialog();

            if (dialogResult == true) {
                FileName.Content = fileDialog.FileName;

                StreamReader readedFile = new StreamReader(File.OpenRead(fileDialog.FileName));
                CircuitText.Text = readedFile.ReadToEnd();

                Log.Instance.AddLogLine("File opened");
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog();

            fileDialog.Filter = "Text Files (.txt)|*.txt|Circuits (.cir)|*.cir";

            if (fileDialog.ShowDialog() == true) {
                File.WriteAllText(fileDialog.FileName, CircuitText.Text);
            }
        }

        private void RunFile_Click(object sender, RoutedEventArgs e)
        {
            Log.Instance.AddLogLine("--- starting reading file ---");

            circuit = boardReader.Compile(CircuitText.Text);

        }
    }
}
