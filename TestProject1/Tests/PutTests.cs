using TestProject1.Utils;
using System;
using System.IO;
using System.Collections.Generic;

namespace TestProject1
{   
    public class PutTests
    {
        public static string data = Constants.PutData;
        public static IEnumerable<object[]> _testData = TestDataHelper.GetTestData(data);

        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(_testData))]
        public void PutTestParameterized(TestData data)
        {
            restActions.setBaseURL(data.param1, data.param2);
            restActions.AddHeader("Content-Type", "application/json");
            restActions.AddBody(new { data.name, data.job });
            restActions.PutCall();
            restActions.checkStatusCode(data.code);
            restActions.validateRespFields(data.name, data.job);
        }
    }
}