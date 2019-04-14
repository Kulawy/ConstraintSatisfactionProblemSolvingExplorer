using ConstraintSatisfactionProblemSolver.FutoshikiProblem;
using ConstraintSatisfactionProblemSolver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintSatisfactionProblemSolver.Data
{
    public sealed class DataContainer
    {

        private static DataContainer _oInstance = null;
        public int DimensionOfProblem { get; set; }
        public Futoshiki Problem { get; set; }

        public List<Field[,]> FoundSolutions { get; set; }


        public static DataContainer Instance
        {
            get
            {
                if (_oInstance == null)
                {
                    _oInstance = new DataContainer();
                }
                return _oInstance;
            }
        }

        public static void Clear()
        {
            if (_oInstance != null)
                _oInstance = new DataContainer();
        }

        private DataContainer()
        {
            
        }

    }
}
