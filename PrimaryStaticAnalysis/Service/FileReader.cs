using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PrimaryStaticAnalysis.Service
{
    static class FileReader
    {
        public static List<double> ReadFromFile(string fileName)
        {
            var result = new List<double>();

            double currentFloatValue;
            using (var stream = new StreamReader(fileName))
            {
                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    if (line == string.Empty)
                    {
                        break;
                    }
                    else if (!Double.TryParse(line.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out currentFloatValue))
                    {
                        throw new FileLoadException("Data at the file has an incorrect format.");
                    }

                    result.Add(currentFloatValue);
                }
            }

            return result;
        }
    }
}
