using System.IO;
using System.Text.RegularExpressions;

namespace BLL.Utilities
{
    public class CsvHelper
    {
        public static string[] ReadCsvFile(string csvFileName)
        {
            var rootDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Substring(6);
            return File.ReadAllLines(rootDir + "\\Resources\\Data\\" + csvFileName);
        }

    }
}
