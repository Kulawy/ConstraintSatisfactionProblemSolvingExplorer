using ConstraintSatisfactionProblemSolver.SkyscrapperProblem;
using ConstraintSatisfactionProblemSolver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///<sumary>
///
/// by Jakub Geroń
///</sumary> 

namespace ConstraintSatisfactionProblemSolver.FutoshikiProblem
{
    public class BackTracking
    {

        private Stack<Futoshiki> _futoProblemStack;
        private Stack<Skyscraper> _skyProblemStack;
        public List<Futoshiki> _solutionsFuto = new List<Futoshiki>();
        public List<Skyscraper> _solutionsSky = new List<Skyscraper>();

        public long Iterations { get; set; } 
        //private Random _rnd;

        public BackTracking()
        {
            _futoProblemStack = new Stack<Futoshiki>();
            _skyProblemStack = new Stack<Skyscraper>();

            Iterations = 0;
        }

        /*
        dopuki pola z wartoscia 0 to :
        1. znajdz pole z wartoscia 0
        2. wybierz co chcesz wpisac
        3. wpisz
        4. sprawdz ograniczenia i poprawnosc
        5a. ok - wpisza na stos 
        5b. bad - wpisuj inne wartosci w to miejsce az do skutku, jak dziedzina sie wyczerpie to sciagnij ze stosu kolejna tablice
        
        */
        

        public List<Futoshiki> FutoSolver(Futoshiki problem)
        {
            Stack<Field> fields = new Stack<Field>();
            Futoshiki solvingProblem;
            Field field;
            SearchFieldHeuristic fieldPicker = new SearchFieldHeuristic(ChooseOneByOne);
            
            _futoProblemStack.Push(problem);
            
            solvingProblem = (Futoshiki)problem.Clone();
            
            field = fieldPicker(solvingProblem.Board);
            var root = (Field) field.Clone();
            root.Value = -1;
            root.RowNum = -1;
            root.ColumnNum = -1;

            fields.Push(root);
            //fields.Push(field);
            int valueToSet;
            int earlierValue = field.Value;

            while (fields.Any())
            {
                if( field.Value > 0)
                {
                    earlierValue = field.Value;
                }
                valueToSet = PickValueFromDomain(field.Domain, earlierValue);
                earlierValue = valueToSet;

                while ( valueToSet >= 0 && (!solvingProblem.CheckConstraints(field, valueToSet) || solvingProblem.IsRepetingInRowOrColumn(field, valueToSet)) )
                {
                    earlierValue = valueToSet;
                    valueToSet = PickValueFromDomain(field.Domain, earlierValue);
                    Iterations++;
                }

                if ( valueToSet > 0 )
                {
                    field = solvingProblem.Board[field.RowNum, field.ColumnNum];
                    field.Value = valueToSet;
                    fields.Push(field);

                    //Iterations++;

                    if (solvingProblem.CheckIfSolved())
                    {
                        _solutionsFuto.Add((Futoshiki) solvingProblem.Clone());
                        //solvingProblem = _futoProblemStack.Pop();
                        //field = fields.Pop();
                    }
                    else
                    {
                        _futoProblemStack.Push((Futoshiki) solvingProblem.Clone());
                        //fields.Push(field);
                        //solvingProblem = (Futoshiki)_futoProblemStack.Pop().Clone();
                        field = fieldPicker(solvingProblem.Board);
                        earlierValue = 0;
                    }
                }
                else
                {
                    field = fields.Pop();
                    if (field.Value == -1)
                    {
                        break;
                    }
                    solvingProblem = _futoProblemStack.Pop();
                    field = solvingProblem.Board[field.RowNum, field.ColumnNum];
                    //valueToSet = PickValueFromDomain(field.Domain, earlierValue);
                }

                
            }

            return _solutionsFuto;
        }

        public delegate Field SearchFieldHeuristic(Field[,] board);

        private Field ChooseOneByOne(Field[,] board)
        {
            foreach (Field f in board)
            {
                if (f.Value == 0)
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

        public int PickValueFromDomain(List<int> domain, int earlier)
        {
            if (domain.Contains(earlier) && domain.IndexOf(earlier) != domain.Count - 1)
            {
                return domain[domain.IndexOf(earlier) + 1];
            }
            else if (earlier == 0)
            {
                return domain.First();
            }
            else
            {
                return -1;
            }

        }

        private int ChooseDomainByOrder(Field field)
        {
            return 0;
        }


    }
}


/* JUNK
    
    if (field.Value == 0  && valueToSet > -1 && solvingProblem.CheckConstraints(field, valueToSet) && !solvingProblem.IsRepetingInRowOrColumn(field, valueToSet))
                {
                    field.Value = valueToSet;
                    fields.Push(field);
                    if (solvingProblem.CheckIfSolved())
                    {
                        solutions.Add(solvingProblem);
                        solvingProblem = (Futoshiki)_futoProblemStack.Pop().Clone();
                        field = (Field) fields.Pop().Clone();
                    }
                    else
                    {
                        valueToSet = 0;
                        _futoProblemStack.Push(solvingProblem);
                        fields.Push(field);
                        solvingProblem = (Futoshiki)_futoProblemStack.Pop().Clone(); 
                    }
                }
                else
                {
                    if (valueToSet == -1)
                    {
                        solvingProblem = _futoProblemStack.Pop();
                        valueToSet = PickValueFromDomain(field.Domain, earlierValue);
                    }
                    else
                    {
                        valueToSet = PickValueFromDomain(field.Domain, earlierValue);
                        if (valueToSet != -1)
                        {
                            earlierValue = valueToSet;
                        }
                    }

                }

 */
