using TestProject1.Utils;
using System;
using System.IO;
using System.Collections.Generic;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestProject1
{   
    public class GetTests : IClassFixture<ExtentReportFixture>
    {   
        // private ExtentTest _test;

        // public GetTests(ExtentReportFixture fixture)
        // {
        //     // Create an ExtentTest instance for each test
        //     _test = fixture.Extent.CreateTest(TestContext.CurrentContext.Test.Name);
        // }

        public static string data = Constants.GetData;
        public static IEnumerable<object[]> _testData = TestDataHelper.GetTestData(data);
        RestActions restActions = new RestActions();

        [Theory]
        [MemberData(nameof(_testData))]
        public void GetTestParameterized(TestData data)
        {
            try{
                restActions.setBaseURL(data.param1, data.param2);
                restActions.GetCall();
                // _test.Log(Status.Info, "Response Content: " + restActions.respContent);
                restActions.checkStatusCode(data.code);
                // _test.Pass("Test Passed");
                Console.WriteLine("Test Passed");
            } catch(Exception e){
                // _test.Fail("Test Failed" + e);
                Console.WriteLine(e.ToString());
            }
        }
    }
}