namespace TestProject1.Utils
{
    public static class TestDataHelper
    {
        public static IEnumerable<TestData[]> GetTestData(string path)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string jsonFilePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + path;
            var testDataList = JsonConvert.DeserializeObject<List<TestData>>(File.ReadAllText(jsonFilePath));
            foreach (var testData in testDataList)
            {
                yield return new TestData[] { testData };
            }
        }
    }
}