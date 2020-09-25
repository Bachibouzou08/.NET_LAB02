using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                return lines;
            }
            catch (Exception ex)
            {
                Constants constants = new Constants();
                Console.WriteLine(constants.Errors(2), ex);
                return null;
            }
        }
    }
}
