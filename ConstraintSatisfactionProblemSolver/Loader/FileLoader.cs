using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintSatisfactionProblemSolver.Loader
{
    public class FileLoader
    {
        private readonly FileStream _fileStream;

        public FileLoader(string fileName)
        {
            //string path = @"c:\AIdata\e1\" + fileName;
            //string path = Path.GetFullPath("resources/ai-lab2-data/" + fileName);
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string newPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string path = newPath + "resources/ai-lab2-data/" + fileName;
            try
            {
                _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("error on loading files");
            }

        }

        public bool IsFileGood()
        {
            if (_fileStream != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ReadFileLine()
        {

            string line;
            using (var streamReader = new StreamReader(_fileStream, Encoding.UTF8))
            {
                line = null;
                while ((line = streamReader.ReadLine()) != null)
                {
                    line = streamReader.ReadLine();
                }
            }

            return line;

        }

        public FileStream GetFileStream()
        {
            return _fileStream;
        }


    }
}
