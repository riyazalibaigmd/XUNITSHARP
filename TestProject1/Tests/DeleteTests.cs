using TestProject1.Utils;
using System;
using System.IO;
using System.Collections.Generic;

namespace TestProject1
{   
    public class DeleteTests
    {
        public static string data = Constants.DeleteData;
        public static IEnumerable<object[]> _testData = TestDataHelper.GetTestData(data);
        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(_testData))]
        public void GetDeleteParameterized(TestData data)
        {
            restActions.setBaseURL(data.param1, data.param2);
            restActions.DeleteCall();
            restActions.checkStatusCode(data.code);
        }
    }
}