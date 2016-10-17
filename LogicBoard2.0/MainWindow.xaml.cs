using LogicBoard2._0.Logic;
using LogicBoard2._0.Models;
using LogicBoard2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        private CircuitDrawer _circuitDrawer;

        public MainWindow()
        {
            InitializeComponent();
            Log.Instance.AddRecipient(this);
            boardReader = new BoardReader();
            _circuitDrawer = new CircuitDrawer();
        }

        public void DisplayLogLine(string[] logLines)
        {
            foreach (string newLogLine in logLines)
                LogBookText.AppendText(Environment.NewLine + newLogLine);

            //LogBookText.SelectionStart = LogBookText.Text.Length;
            LogBookText.CaretIndex = LogBookText.Text.Length;
            LogBookText.ScrollToEnd();
        }

        public void DisplayErrorLogLine(string[] logLines)
        {
            string[] errorLogLines = new string[logLines.Length + 1];
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

            RunFile.IsEnabled = false;

            Log.Instance.AddLogLine("--- starting reading file ---");

            circuit = boardReader.Compile(CircuitText.Text);

            //hier komt het wel of niet todo met het valide bord ingelezen en wel, klaar voor gebruik of dus niet
            if (circuit.Valid)
            {
                Console.WriteLine("bord is valide!!!");
                RunCircuit.IsEnabled = true;

                DrawCircuit();
            }
            else
            {
                Console.WriteLine("bord is not valide!!!");
                RunCircuit.IsEnabled = false;
            }

            RunFile.IsEnabled = true;

        }

        private void RunCircuit_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (!regex.IsMatch(Delay.Text))
            {
                Log.Instance.AddErrorLogLine("Delay is not a valid number");
                return;
            }

            // run circuit
            //circuit.Run(Delay.Text);

            DrawCircuit();
        }

        private void DrawCircuit()
        {
            scheme.Children.Clear();
            _circuitDrawer.SetCircuit(circuit);
            _circuitDrawer.SetMedium(scheme);

            _circuitDrawer.Draw();
        }
    }
}