using ConstraintSatisfactionProblemSolver.Data;
using ConstraintSatisfactionProblemSolver.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintSatisfactionProblemSolver.View
{
    public class ConsoleInterface
    {
        public const string TITLE = "\t\t\tTTP CSP SOLVER APPLICATION";
        public const string COMMANDS = "\nCommands:\n" +
            "0 - load data from file \n" +
            "1 - Futoshiki \n" +
            "2 - Skycraper \n" +
            "3 - | \n" +
            "4 - Display loaded data\n" +
            "9 - exit\n\n";
        public const string SOME = "\t\t\tTTP PROBLEM SOLVER";

        private readonly IEnumerable<string> _commands = new string[] { "0", "1", "2", "3", "4", "9" };

        private bool _exit;
        private FileLoader _fileLoader;

        public void Start()
        {
            Console.WriteLine(TITLE);

            _exit = false;
            while (_exit != true)
            {
                DisplayStartMessage();
                DoActionDependOnCommand(ValidateCommand());
            }

        }

        private void DisplayStartMessage()
        {
            Console.WriteLine(COMMANDS);
        }

        private string ValidateCommand()
        {
            Console.Write(">");
            string myCommand = Console.ReadLine();
            if (_commands.Contains(myCommand))
            {
                return myCommand;
            }
            else
            {
                return "error";
            }
        }

        private void DoActionDependOnCommand(string command)
        {
            switch (command)
            {
                case "0":
                    if (!DoLoad())
                    {
                        Console.WriteLine("BAD LOADING");
                        return;
                    }
                    ParseData();
                    break;
                case "1":
                    SolveFutoshiki();
                    break;
                case "2":
                    SolveSkyscrapper();
                    break;
                case "3":
                    break;
                case "4":
                    DisplayLoadedData();
                    break;
                case "9":
                    _exit = true;
                    break;

                case "error":
                    Console.WriteLine("BAD COMMAND"); ;
                    break;

            }

        }

        private bool DoLoad()
        {
            Console.WriteLine("Give file's name: ");
            Env.FILE_NAME_I = Console.ReadLine();
            _fileLoader = new FileLoader(Env.FILE_NAME_I);
            if (!_fileLoader.IsFileGood())
            {
                Console.WriteLine("Bad loading file");
                return false;
            }
            else
            {
                Console.WriteLine("file loaded;");
                return true;
            }
        }

        private bool ParseData()
        {
            DataParser dataParser = new DataParser();
            dataParser.ParseDataFromFileStream(_fileLoader.GetFileStream());

            return true;
        }

        private void SolveFutoshiki()
        {
            throw new NotImplementedException();
        }

        private void SolveSkyscrapper()
        {
            throw new NotImplementedException();
        }
        

        private void DisplayLoadedData()
        {
            DataContainer box = DataContainer.Instance;
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("Dimension: {0}", box.DimensionOfProblem);
            Console.WriteLine();
            Console.WriteLine(box.Problem);
            Console.WriteLine(box.Problem.RestrictionsToString());

        }


    }
}
