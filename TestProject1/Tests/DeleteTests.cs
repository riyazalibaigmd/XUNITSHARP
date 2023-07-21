using TestProject1.Utils;

namespace TestProject1
{   
    public class DeleteTests
    {
        public static IEnumerable<object[]> testData = TestDataHelper.GetTestData(Constants.DeleteData);
        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(testData))]
        public void GetDeleteParameterized(TestData data)
        {
            restActions.SetBaseURL(data.param1, data.param2);
            restActions.AddHeader(data.headerName, data.headerValue);
            restActions.DeleteCall();
            restActions.CheckStatusCode(data.code);
        }
    }
}