using TestProject1.Utils;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestProject1
{   
    public class GetTests : IClassFixture<ExtentReportFixture>
    {   
        public static IEnumerable<object[]> testData = TestDataHelper.GetTestData(Constants.GetData);
        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(testData))]
        public void GetTestParameterized(TestData data)
        {
            restActions.SetBaseURL(data.param1, data.param2);
            restActions.GetCall();
            restActions.CheckStatusCode(data.code);
        }
    }
}