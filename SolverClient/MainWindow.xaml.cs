using ConstraintSatisfactionProblemSolver.Data;
using ConstraintSatisfactionProblemSolver.Loader;
using System;
using System.Collections.Generic;
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

namespace SolverClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private FileLoader _fileLoader;
        private string _resultText;
        DataContainer box;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            CheckInput();
            DoLoad();
            ParseData();
            DisplayLoadedData();

        }

        private void CheckInput()
        {

            if((bool)TypeHeuristic1.IsChecked)
            {

            }
            else if ((bool)TypeHeuristic2.IsChecked)
            {

            }
            else if ((bool)TypeHeuristic3.IsChecked)
            {

            }
            else if ((bool)TypeHeuristic4.IsChecked)
            {

            }

            if ((bool)TypeAlg1.IsChecked)
            {

            }
            else if ((bool)TypeAlg2.IsChecked)
            {

            }

            Env.FILE_NAME_I = TextBox_FileName.Text;

        }

        private void Btm_Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_Result.Text = "RESULT";
            TextBlock_Problem.Text = "PROBLEM CONTENT";
            TypeAlg1.IsChecked = false;
            TypeAlg2.IsChecked = false;
            TypeHeuristic1.IsChecked = false;
            TypeHeuristic2.IsChecked = false;
            TypeHeuristic3.IsChecked = false;
            TypeHeuristic4.IsChecked = false;
            TextBox_FileName.Text = "test_futo_4_0.txt";
        }

        private bool DoLoad()
        {
            _fileLoader = new FileLoader(Env.FILE_NAME_I);
            if (!_fileLoader.IsFileGood())
            {
                _resultText = "Bad loading file";
                return false;
            }
            else
            {
                _resultText = "file loaded;";
                return true;
            }
        }

        private bool ParseData()
        {
            DataParser dataParser = new DataParser();
            dataParser.ParseDataFromFileStream(_fileLoader.GetFileStream());

            return true;
        }

        private void DisplayLoadedData()
        {
            box = DataContainer.Instance;
            string resultText = "";
            
            //Console.WriteLine("_________________________________________________________");
            resultText += $"Dimension: {box.DimensionOfProblem}\n\n";
            resultText += box.Problem.ToString() + "\n";
            resultText += box.Problem.RestrictionsToString();

            TextBlock_Problem.Text = resultText;

        }

        public void DisplaySolution(String htmlText)
        {
            //SolutionWindow.NavigateToString(htmlText);

        }


    }
}
