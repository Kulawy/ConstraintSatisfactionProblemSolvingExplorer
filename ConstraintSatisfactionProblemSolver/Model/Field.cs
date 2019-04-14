using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintSatisfactionProblemSolver.Utils
{
    public class Field: ICloneable
    {
        public int Value { get; set; }

        public int RowNum { get; set; }
        public int ColumnNum { get; set; }
        public List<int> Domain { get; set; }

        public int UpConstrinat { get; set; }
        public int DownConstrinat { get; set; }
        public int RightConstrinat { get; set; }
        public int LeftConstrinat { get; set; }

        public Field(int value, List<int> domain)
        {
            Value = value;
            Domain = domain;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public object Clone()
        {
            Field copy = new Field(this.Value, new List<int>(Domain));
            copy.RowNum = this.RowNum;
            copy.ColumnNum = this.ColumnNum;

            return copy;
        }

    }
}
