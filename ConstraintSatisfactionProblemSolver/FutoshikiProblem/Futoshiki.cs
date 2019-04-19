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
            for(int i=0; i<n; i++)
            {
                Domain.Add( i + 1);
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

        public bool CheckConstraints(Field f, int value)
        {
            foreach(RelationRestriction r in RelationRestrictions)
            {
                if ( (r.OneRowNumber == f.RowNum && r.OneColNumber == f.ColumnNum)  && this.Board[r.TwoRowNumber, r.TwoColNumber].Value != 0)
                {
                    //r.One.Value = value;
                    if (r.CheckRestrictionIfSmaller( value,this.Board[r.TwoRowNumber, r.TwoColNumber].Value))
                    {
                        return true;
                    }
                    else
                    {
                        this.Board[r.OneRowNumber, r.OneColNumber].Value = 0;
                        //r.One.Value = 0;
                        return false;
                    }
                }

                if ( (r.TwoRowNumber == f.RowNum && r.TwoColNumber == f.ColumnNum) && this.Board[r.OneRowNumber, r.OneColNumber].Value != 0)
                {
                    //r.Two.Value = value;
                    if (r.CheckRestrictionIfSmaller( this.Board[r.OneRowNumber, r.OneColNumber].Value, value))
                    {
                        return true;
                    }
                    else
                    {
                        this.Board[r.TwoRowNumber, r.TwoColNumber].Value = 0;
                        //r.Two.Value = 0;
                        return false;
                    }
                    
                }
            }
            return true ;
        }

        //public bool CheckConstraints()
        //{
        //    for(int i = 0; i < RelationRestrictions.Count; i++)
        //    {
        //        if (!RelationRestrictions[i].CheckRestrictionIfSmaller())
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public bool IsRepetingInRowOrColumn(Field field, int value)
        {
            for(int i = 0; i < Board.GetLength(0); i++)
            {
                if ( field.ColumnNum != i )
                {
                    if (Board[field.RowNum, i].Value == value)
                    {
                        return true;
                    }
                }
                if ( field.RowNum != i)
                {
                    if (Board[i, field.ColumnNum].Value == value)
                    {
                        return true;
                    }
                }
            }
            return false;
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
                    newFuto.Board[i, j] = (Field) Board[i, j].Clone();
                }
            }
            Domain = new List<int>(_sizeOfProblem);
            for (int i = 0; i < _sizeOfProblem; i++)
            {
                Domain.Add(i + 1);
            }

            newFuto.RelationRestrictions = new List<RelationRestriction>();
            foreach (RelationRestriction r in RelationRestrictions)
            {
                newFuto.RelationRestrictions.Add((RelationRestriction) r.Clone());
            }
            return newFuto;
        }





    }
}
