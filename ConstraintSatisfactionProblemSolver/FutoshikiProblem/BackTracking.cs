using ConstraintSatisfactionProblemSolver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintSatisfactionProblemSolver.FutoshikiProblem
{
    public class BackTracking
    {

        private Stack<Field[,]> _problemStack;
        private Random _rnd;

        public BackTracking()
        {
            _problemStack = new Stack<Field[,]>();

        }

        /*
        1. znajdz pole z wartoscia 0
        2. wybierz co chcesz wpisac
        3. sprawdz czy mozesz to wpisac
        4a. wpisz
        5a. odłóż 

        */


        public Futoshiki FutoSolver(Futoshiki problem)
        {
            Field[,] solvingProblem;
            SearchFieldHeuristic filePicker = new SearchFieldHeuristic(ChooseOneByOne);
            //valueFromDomainPicker = new 

            _problemStack.Push(problem.Board);


            solvingProblem = (Field[,]) _problemStack.Peek().Clone();


            Field field = filePicker(solvingProblem);
            if ( field == null)
            {
                problem.Board = solvingProblem;
                return problem;
            }
            else
            {
                int valueToSet = field.Domain[_rnd.Next(field.Domain.Count)];
                

            }


            return null;
        }

        public delegate Field SearchFieldHeuristic(Field[,] board);

        private Field ChooseOneByOne(Field[,] board)
        {
            foreach(Field f in board)
            {
                if ( f.Value == 0)
                {
                    return f;
                }
            }
            return null;
        }

        private Field ChooseByBiggestConstraint(Futoshiki futo)
        {
            return null;
        }


    }
}
