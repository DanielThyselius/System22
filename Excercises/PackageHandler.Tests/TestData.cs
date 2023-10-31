using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageHandler.Tests
{
    public class TestData 
    {
        public static IEnumerable<object[]> Normal()
        {
            var list = new List<object[]>
            {
                new object[] { 0, 3770 },
                new object[] { 1, 3770 },
                new object[] { 2, 3770 },
                new object[] { 3, 5655 },
                new object[] { 8, 15080 },
                new object[] { 20, 37700 }
            };

            return list;
        }

        public static IEnumerable<object[]> FromCsv() {
            string[] csvLines = File.ReadAllLines("data.csv");
            var testCases = new List<object[]>();

            foreach (var line in csvLines)
            {
                IEnumerable<int> values = line.Split(',').Select(int.Parse);

                object[] testCase = values.Cast<object>().ToArray();

                testCases.Add(testCase);
            }

            return testCases;
        }
    }
}
