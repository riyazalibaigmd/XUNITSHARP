using TestProject1.Utils;
using System;
using System.IO;
using System.Collections.Generic;

namespace TestProject1
{   
    public class GetTests
    {
        public static string GetJsonData = "\\TestData\\Get.json";
        public static IEnumerable<object[]> _testData = TestDataHelper.GetTestData(GetJsonData);
        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(_testData))]
        public void GetTestParameterized(TestData data)
        {
            restActions.setBaseURL(data.param1, data.param2);
            restActions.GetCall();
            restActions.checkStatusCode(data.code);
        }
    }
}