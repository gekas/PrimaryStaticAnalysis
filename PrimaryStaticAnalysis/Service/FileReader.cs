using PrimaryStaticAnalysis.DAL;
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

        public static Tuple<List<double>, List<double>> ReadTwoFromFile(string fileName)
        {
            List<double> firstSequence = new List<double>();
            List<double> secondSequence = new List<double>();

            foreach (string l in File.ReadAllLines(fileName))
            {
                var r = l.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);
                firstSequence.Add(Convert.ToDouble(r[0].Replace('.', ',')));
                secondSequence.Add(Convert.ToDouble(r[1].Replace('.', ',')));
            }

            return new Tuple<List<double>, List<double>>(firstSequence, secondSequence);
        }

        public static List<DensityKvantilA> ReadDensityKvantils()
        {
            var result = new List<DensityKvantilA>();

            using (var stream = new StreamReader(@"KvantilDensity.txt"))
            {
                double alpha = 0;
                Dictionary<int, double> kvantilsM = new Dictionary<int, double>();
                int m = 0;

                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    if (line == string.Empty)
                    {
                        break;
                    }
                    else if (line.Contains("a"))
                    {
                        if (kvantilsM.Count > 0)
                        {
                            result.Add(new DensityKvantilA(alpha, kvantilsM));
                        }

                        m = 0;
                        alpha = Double.Parse(line.Remove(0, 1));
                        kvantilsM.Clear();

                        continue;
                    }

                    m++;
                    kvantilsM.Add(m, Double.Parse(line));
                }

                result.Add(new DensityKvantilA(alpha, kvantilsM));
            }

            return result;
        }
    }
}
