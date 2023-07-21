using TestProject1.Utils;
using System;
using System.IO;
using System.Collections.Generic;

namespace TestProject1
{   
    public class PostTests
    {
        public static string data = Constants.PostData;
        public static IEnumerable<object[]> _testData = TestDataHelper.GetTestData(data);

        public static string createData = Constants.PostCreateData;
        public static IEnumerable<object[]> _createData = TestDataHelper.GetTestData(createData);

        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(_testData))]
        public void PostTestParameterized(TestData data)
        {
            restActions.setBaseURL(data.param1);
            restActions.AddHeader("Content-Type", "application/json");
            restActions.AddBody(new { data.email, data.password });
            restActions.PostCall();
            restActions.checkStatusCode(data.code);
        }

        [Theory]
        [MemberData(nameof(_createData))]
        public void PostCreateParameterized(TestData data)
        {
            restActions.setBaseURL(data.param1);
            restActions.AddHeader("Content-Type", "application/json");
            restActions.AddBody(new { data.name, data.job });
            restActions.PostCall();
            restActions.checkStatusCode(data.code);
            restActions.validateRespFields(data.name, data.job);
        }
    }
}