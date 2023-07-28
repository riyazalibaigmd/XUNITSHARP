using TestProject1.Utils;

namespace TestProject1
{   
    public class PostTests
    {
        public static IEnumerable<object[]> testData = TestDataHelper.GetTestData(Constants.PostData);
        public static IEnumerable<object[]> createData = TestDataHelper.GetTestData(Constants.PostCreateData);

        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(testData))]
        public void PostTestParameterized(TestData data)
        {
            restActions.SetBaseURL(data.param1);
            restActions.AddHeader(data.headerName, data.headerValue);
            restActions.AddBody(new { data.email, data.password });
            restActions.PostCall();
            restActions.CheckStatusCode(data.code);
        }

        [Theory]
        [MemberData(nameof(createData))]
        public void PostCreateParameterized(TestData data)
        {
            restActions.SetBaseURL(data.param1);
            restActions.AddHeader(data.headerName, data.headerValue);
            restActions.AddBody(new { data.name, data.job });
            restActions.PostCall();
            restActions.CheckStatusCode(data.code);
            restActions.ValidateRespFields(data.name, data.job);
        }
    }
}