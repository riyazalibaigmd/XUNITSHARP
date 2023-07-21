using TestProject1.Utils;

namespace TestProject1
{   
    public class PutTests
    {
        public static IEnumerable<object[]> testData = TestDataHelper.GetTestData(Constants.PutData);

        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(testData))]
        public void PutTestParameterized(TestData data)
        {
            restActions.SetBaseURL(data.param1, data.param2);
            restActions.AddHeader(data.headerName, data.headerValue);
            restActions.AddBody(new { data.name, data.job });
            restActions.PutCall();
            restActions.CheckStatusCode(data.code);
            restActions.ValidateRespFields(data.name, data.job);
        }
    }
}