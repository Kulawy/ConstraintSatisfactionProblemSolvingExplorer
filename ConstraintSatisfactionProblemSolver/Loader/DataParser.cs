using ConstraintSatisfactionProblemSolver.Data;
using ConstraintSatisfactionProblemSolver.FutoshikiProblem;
using ConstraintSatisfactionProblemSolver.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintSatisfactionProblemSolver.Loader
{
    public class DataParser
    {
        DataContainer _container;

        public DataParser()
        {
            DataContainer.Clear();
            _container = DataContainer.Instance;
        }

        public void ParseDataFromFileStream(FileStream fileStream)
        {
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                FitDimensionOfProblem(streamReader.ReadLine());
                _container.ProblemFuto = new Futoshiki(_container.DimensionOfProblem);

                streamReader.ReadLine();

                for (int i = 0; i < _container.DimensionOfProblem; i++)
                {
                    FitInitBoardRow(streamReader.ReadLine(), i);
                }
                streamReader.ReadLine();
                
                string line = streamReader.ReadLine();
                while ( line != null &&  !line.Equals("") && !line.Equals(" "))
                {
                    FitRestrictions(line);
                    line = streamReader.ReadLine();
                }
            }

        }

        private void FitRestrictions(string text)
        {
            string[] splitContent = text.Split(';');
            char[] firstField = splitContent[0].ToArray();
            char[] secondField = splitContent[1].ToArray();

            _container.ProblemFuto.RelationRestrictions
                .Add(
                    new Model.RelationRestriction(
                        _container.ProblemFuto.Board[Convert.ToInt32(firstField[0])-65, int.Parse(firstField[1].ToString())-1],
                        _container.ProblemFuto.Board[Convert.ToInt32(secondField[0])-65, int.Parse(secondField[1].ToString())-1]
                    )
                );

        }

        private void FitCity(string text)
        {
            string sep = "\t";
            string[] splitContent = text.Split(sep.ToCharArray());
            //_container._Cities.Add(new Model.City(Int32.Parse(splitContent[0]), Double.Parse(splitContent[1].Replace(".", ",")), Double.Parse(splitContent[2].Replace(".", ","))));
        }

        private void FitInitBoardRow(string text, int rowNum)
        {
            if (text == null)
                return;
            //string[] splited = text.Split(new Char[] { ' ', ',', '.', ':', '\t' });
            //string[] splitContent = text.Split(new char[0]); // Split(new char[0]) splits text by white spaces
            string[] splitContent = text.Split(';');
            if( _container.DimensionOfProblem != splitContent.Length)
            {
                throw new Exception("Size of a row is not sieze of a problem");
            }
            for(int i=0; i < splitContent.Length ; i++)
            {
                _container.ProblemFuto.Board[rowNum, i] = new Field(Int32.Parse(splitContent[i]), _container.ProblemFuto.Domain);
                _container.ProblemFuto.Board[rowNum, i].RowNum = rowNum;
                _container.ProblemFuto.Board[rowNum, i].ColumnNum = i;
            }
        }

        private void FitDimensionOfProblem(string text)
        {
            _container.DimensionOfProblem = Int32.Parse(text);
            
        }

        private void FitCapacity(string text)
        {
            if (text.ToUpper().Contains("CAPACITY".ToUpper()))
            {
                string[] words = text.Trim().Split(':');
                //_container.Capacity = Int32.Parse(words[1]);
            }
        }

        
    }
}
