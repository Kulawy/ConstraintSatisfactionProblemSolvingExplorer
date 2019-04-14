using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstraintSatisfactionProblemSolver.View;

namespace ConstraintSatisfactionProblemSolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(path);
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            Console.WriteLine(newPath);

            ConsoleInterface inter = new ConsoleInterface();
            inter.Start();

        }
    }
}
