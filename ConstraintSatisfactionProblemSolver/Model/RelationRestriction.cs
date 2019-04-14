using ConstraintSatisfactionProblemSolver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintSatisfactionProblemSolver.Model
{
    public class RelationRestriction
    {
        private Field _one;
        private Field _two;
        private int _restrict;

        public RelationRestriction(Field one, Field two, int restriction)
        {
            _one = one;
            _two = two;
            _restrict = restriction;
        }

        public RelationRestriction(Field one, Field two)
        {
            _one = one;
            _two = two;
            _restrict = -1;
        }

        public bool CheckRestrictionIfSmaller()
        {
            if (_one.Value < _two.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckRestriction()
        {
            if ( _one.Value != 0 && _two.Value != 0)
            {
                switch (_restrict)
                {
                    case -1:
                        return (_one.Value < _two.Value);
                    case 1:
                        return (_one.Value > _two.Value);
                    default:
                        return _one.Value == _two.Value;
                }
            }
            else
            {
                return true;
            }

            
        }

        public override string ToString()
        {
            string result = _one.RowNum.ToString() + "/" + _one.ColumnNum.ToString();
            switch (_restrict)
            {
                case (-1):
                    result += "<";
                    break;
                default:
                    result += "=";
                    break;
            }
            result += _two.RowNum.ToString() + "/" + _two.ColumnNum.ToString();
            return result;
        }


    }
}
