using TestProject1.Utils;
using System;
using System.IO;

namespace TestProject1
{
    public class UnitTest
    {
        const string SkipOrNot = "reason"; // Skip all tests
        RestActions restActions = new RestActions();

        [Fact]
        public void TestGetFact()
        {
            restActions.setBaseURL("/{users}/{userID}");
            restActions.AddUrlSegment("users", "users");
            restActions.AddUrlSegment("userID", "2");
            restActions.GetCall();
            restActions.checkOKStatusCode(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("users", "2", HttpStatusCode.OK)]
        [InlineData("users", "23", HttpStatusCode.NotFound)]
        [InlineData("unknown", "2", HttpStatusCode.OK)]
        [InlineData("unknown", "23", HttpStatusCode.NotFound)]
        public void TestGet(string param1, string param2, HttpStatusCode code)
        {
            restActions.setBaseURL(param1, param2);
            restActions.GetCall();
            restActions.checkStatusCode(code);
        }

        [Theory]
        [InlineData("users", "morpheus", "leader", HttpStatusCode.Created)]
        public void TestCreatePost(string pathParam, string name, string job, HttpStatusCode code)
        {
            restActions.setBaseURL(pathParam);
            restActions.AddHeader("Content-Type", "application/json");
            restActions.AddBody(new { name, job });
            restActions.PostCall();
            restActions.checkStatusCode(code);
            restActions.validateRespFields(name, job);
        }

        [Theory]
        [InlineData("register", "eve.holt@reqres.in", "pistol", HttpStatusCode.OK)]
        [InlineData("register", "sydney@fife", "", HttpStatusCode.BadRequest)]
        [InlineData("login", "eve.holt@reqres.in", "cityslicka", HttpStatusCode.OK)]
        [InlineData("login", "peter@klaven", "", HttpStatusCode.BadRequest)]
        public void TestPost(string pathParam, string email, string password, HttpStatusCode code)
        {
            restActions.setBaseURL(pathParam);
            restActions.AddHeader("Content-Type", "application/json");
            restActions.AddBody(new { email, password });
            restActions.PostCall();
            restActions.checkStatusCode(code);
        }

        [Theory]
        [InlineData("users", "2", "morpheus", "zion resident", HttpStatusCode.OK)]
        public void TestPut(string param1, string param2, string name, string job, HttpStatusCode code)
        {
            restActions.setBaseURL(param1, param2);
            restActions.AddHeader("Content-Type", "application/json");
            restActions.AddBody(new { name, job });
            restActions.PutCall();
            restActions.checkStatusCode(code);
            restActions.validateRespFields(name, job);
        }

        [Theory]
        [InlineData("users", "2", HttpStatusCode.NoContent)]
        public void TestDelete(string param1, string param2, HttpStatusCode code)
        {
            restActions.setBaseURL(param1, param2);
            restActions.AddHeader("Accept", "*/*");
            restActions.DeleteCall();
            restActions.checkStatusCode(code);
        }
    }
}