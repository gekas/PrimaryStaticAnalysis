using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Utils
{
    public static class FileReader
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
                    line = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries)[0];
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

        public static Tuple<List<double>, List<double>> ReadTwoFromFile(string fileName)
        {
            List<double> firstSequence = new List<double>();
            List<double> secondSequence = new List<double>();

            foreach (string l in File.ReadAllLines(fileName))
            {
                var r = l.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
                firstSequence.Add(double.Parse(r[0], CultureInfo.InvariantCulture));
                secondSequence.Add(double.Parse(r[1], CultureInfo.InvariantCulture));
            }

            return new Tuple<List<double>, List<double>>(firstSequence, secondSequence);
        }
    }
}
