using ConstraintSatisfactionProblemSolver.Model;
using ConstraintSatisfactionProblemSolver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintSatisfactionProblemSolver.FutoshikiProblem { 
    public class Futoshiki : ICloneable
    {
        private int _sizeOfProblem;
        public List<int> Domain;
        public Field[,] Board { get; set; }
        public List<RelationRestriction> RelationRestrictions { get; set; }
        


        public Futoshiki(int n)
        {
            _sizeOfProblem = n;
            Board = new Field[n, n];
            Domain = new List<int>(n);
            for(short i=0; i<n; i++)
            {
                Domain[i] = i + 1;
            }

            RelationRestrictions = new List<RelationRestriction>();
        }

        public string RestrictionsToString()
        {
            string result = "";
            foreach(RelationRestriction r in RelationRestrictions)
            {
                result += r.ToString() + "\n";
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            for(int i = 0; i < _sizeOfProblem; i++)
            {
                result += " | ";
                for(int j = 0; j < _sizeOfProblem; j++)
                {
                    result += Board[i, j].ToString() + " | ";
                }
                result += "\n";
            }

            return result;
        }

        private bool CheckIfSmaller(Field one, Field two)
        {
            return one.Value < two.Value;
        }

        public bool CheckConstraints()
        {
            for(int i = 0; i < RelationRestrictions.Count; i++)
            {
                if (!RelationRestrictions[i].CheckRestrictionIfSmaller())
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckIfSolved() {
            foreach(Field f in Board)
            {
                if ( f.Value == 0)
                {
                    return false;
                }
            }
            return true;

        }

        public object Clone()
        {
            Futoshiki newFuto = new Futoshiki(_sizeOfProblem);
            newFuto.Board = new Field[_sizeOfProblem, _sizeOfProblem];
            for(int i = 0; i < _sizeOfProblem; i++)
            {
                for(int j = 0; j < _sizeOfProblem; j++)
                {
                    newFuto.Board[i, j] = Board[i, j];
                }
            }
            Domain = new List<int>(_sizeOfProblem);
            for (short i = 0; i < _sizeOfProblem; i++)
            {
                Domain[i] = i + 1;
            }
            RelationRestrictions = this.RelationRestrictions;


            return newFuto;
        }





    }
}
