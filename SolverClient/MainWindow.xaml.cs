using ConstraintSatisfactionProblemSolver.Data;
using ConstraintSatisfactionProblemSolver.FutoshikiProblem;
using ConstraintSatisfactionProblemSolver.Loader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

///<sumary>
///
/// by Jakub Geroń
///</sumary> 

namespace SolverClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private FileLoader _fileLoader;
        //private string _resultText;
        private int _problemType;
        private DataContainer _box;
        private List<Futoshiki> _solutionsFuto;

        private long _iterations;
        
        private Stopwatch _watch;
        

        public MainWindow()
        {
            InitializeComponent();
            _watch = new Stopwatch();
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            CheckInput();
            DoLoad();
            ParseData();
            DisplayLoadedData();
            _watch.Reset();
            _watch.Start();
            SolveProblem();
            _watch.Stop();
            DisplaySolutions();

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
            
            if ((bool)RadioButton_Futoshiki.IsChecked)
            {
                _problemType = 1;
            }
            else if ((bool)RadioButton_Skyscraper.IsChecked)
            {
                _problemType = 2;
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
            RadioButton_Skyscraper.IsChecked = false;
            RadioButton_Futoshiki.IsChecked = false;
            Label_SolutionCount.Content = "?";
            TextBox_FileName.Text = "test_futo_4_0.txt";
        }

        private bool DoLoad()
        {
            _fileLoader = new FileLoader(Env.FILE_NAME_I);
            if (!_fileLoader.IsFileGood())
            {
                //_resultText = "Bad loading file";
                return false;
            }
            else
            {
                //_resultText = "file loaded;";
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
            _box = DataContainer.Instance;
            string resultText = "";
            
            //Console.WriteLine("_________________________________________________________");
            resultText += $"Dimension: {_box.DimensionOfProblem}\n\n";
            resultText += _box.ProblemFuto.ToString() + "\n";
            resultText += _box.ProblemFuto.RestrictionsToString();

            TextBlock_Problem.Text = resultText;

        }

        private void SolveProblem()
        {
            if (_problemType == 1)
            {
                BackTracking bct = new BackTracking();
                _solutionsFuto = bct.FutoSolver(_box.ProblemFuto);
                _iterations = bct.Iterations;
            }
            else if(_problemType == 2)
            {

            }
        }

        public void DisplaySolutions()
        {
            string resultText = "";
            if (_solutionsFuto != null)
            {
                if (_solutionsFuto.Count == 0)
                {
                    resultText = "Empty";
                }
                foreach (Futoshiki f in _solutionsFuto)
                {
                    resultText += f.ToString() + "\n";
                }

                Label_SolutionCount.Content = _solutionsFuto.Count;

                Label_IterationsNum.Content = _iterations;
                Label_TimeEval.Content = _watch.ElapsedMilliseconds;

                //resultText += "\nIterations: " + _iterations + "\n";
                //resultText += "\nTime: " + _watch.ElapsedMilliseconds + "ms\n";


                TextBlock_Result.Text = resultText;
            }


            
            //SolutionWindow.NavigateToString(htmlText);

        }


    }
}
