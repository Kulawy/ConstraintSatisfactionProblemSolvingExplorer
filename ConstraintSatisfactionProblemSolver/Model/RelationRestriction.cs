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
     


namespace ConstraintSatisfactionProblemSolver.Model
{
    public class RelationRestriction : ICloneable
    {
        //public Field One;
        //public Field Two;

        public  int OneRowNumber { get; set; }
        public int OneColNumber { get; set; }
        public int TwoRowNumber { get; set; }
        public int TwoColNumber { get; set; }

        private int _restrict;

        public RelationRestriction()
        {
            _restrict = -1;
        }

        public RelationRestriction(Field one, Field two, int restriction)
        {
            OneRowNumber = one.RowNum;
            OneColNumber = one.ColumnNum;
            TwoRowNumber = two.RowNum;
            TwoColNumber = two.ColumnNum;

            _restrict = restriction;
        }

        public RelationRestriction(Field one, Field two)
        {
            OneRowNumber = one.RowNum;
            OneColNumber = one.ColumnNum;
            TwoRowNumber = two.RowNum;
            TwoColNumber = two.ColumnNum;
            _restrict = -1;
        }

        public bool CheckRestrictionIfSmaller(int oneValue, int twoValue)
        {
            if (oneValue < twoValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public bool CheckRestriction(int oneValue, int twoValue)
        {
            if ( oneValue != 0 && twoValue != 0)
            {
                switch (_restrict)
                {
                    case -1:
                        return (oneValue < twoValue);
                    case 1:
                        return (oneValue > twoValue);
                    default:
                        return oneValue == twoValue;
                }
            }
            else
            {
                return true;
            }

            
        }

        public Object Clone()
        {
            RelationRestriction newValue = new RelationRestriction();
            newValue.OneRowNumber = OneRowNumber;
            newValue.OneColNumber = OneColNumber;
            newValue.TwoRowNumber = TwoRowNumber;
            newValue.TwoColNumber = TwoColNumber;
            newValue._restrict = _restrict;
            return newValue;
        }

        public override string ToString()
        {
            string result = (OneRowNumber+1).ToString() + "/" + (OneColNumber+1).ToString();
            switch (_restrict)
            {
                case (-1):
                    result += "<";
                    break;
                default:
                    result += "=";
                    break;
            }
            result += (TwoRowNumber+1).ToString() + "/" + (TwoColNumber+1).ToString();
            return result;
        }


    }
}
