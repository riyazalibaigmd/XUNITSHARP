using System.IO;
using System.Collections.Generic;

namespace TestProject1.Utils
{
    public class TestData
    {
        public string param1 { get; set; }
        public string param2 { get; set; }
        public int code { get; set; }
    }

    public static class TestDataHelper
    {
        public static IEnumerable<object[]> GetTestData(string path)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string jsonFilePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + path;
            List<TestData> testDataList = JsonConvert.DeserializeObject<List<TestData>>(File.ReadAllText(jsonFilePath));
            foreach (var testData in testDataList)
            {
                yield return new object[] { testData };
            }
        }
    }
}