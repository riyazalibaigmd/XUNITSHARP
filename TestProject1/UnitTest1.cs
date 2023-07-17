namespace TestProject1;
using System.Net;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var test = new APIRequests();
        test.getRequest();
    }

    [Theory]
    [InlineData("users", "2", HttpStatusCode.OK)]
    [InlineData("users", "23", HttpStatusCode.NotFound)]
    // [InlineData("users", "23", HttpStatusCode.OK)]
    [InlineData("unknown", "2", HttpStatusCode.OK)]
    [InlineData("unknown", "23", HttpStatusCode.NotFound)]
    // [InlineData("unknown", "23", HttpStatusCode.OK)] 
    public void TestGet(string param1, string param2, HttpStatusCode code)
    {
        var test = new APIRequests();
        test.getRequest(param1, param2, code);
    }

    [Theory]
    [InlineData("users", "morpheus", "leader", HttpStatusCode.Created)]
    public void TestCreatePost(string pathParam, string name, string job, HttpStatusCode code)
    {
        var test = new APIRequests();
        test.postCreateRequest(pathParam, name, job, code);
    }

    [Theory]
    [InlineData("register", "eve.holt@reqres.in", "pistol", HttpStatusCode.OK)]
    [InlineData("register", "sydney@fife", "", HttpStatusCode.BadRequest)]
    // [InlineData("register", "sydney@fife", "", HttpStatusCode.OK)]
    [InlineData("login", "eve.holt@reqres.in", "cityslicka", HttpStatusCode.OK)]
    [InlineData("login", "peter@klaven", "", HttpStatusCode.BadRequest)]
    // [InlineData("login", "peter@klaven", "", HttpStatusCode.OK)]
    public void TestPost(string pathParam, string email, string pwd, HttpStatusCode code)
    {
        var test = new APIRequests();
        test.postRequest(pathParam, email, pwd, code);
    }

    [Theory]
    [InlineData("users", "2", "morpheus", "zion resident", HttpStatusCode.OK)]
    public void TestPut(string param1, string param2, string name, string job, HttpStatusCode code)
    {
        var test = new APIRequests();
        test.putRequest(param1, param2, name, job, code);
    }


    [Theory]
    [InlineData("users", "2", HttpStatusCode.NoContent)]
    // [InlineData("users", "2300", HttpStatusCode.OK)]
    public void TestDelete(string param1, string param2, HttpStatusCode code)
    {
        var test = new APIRequests();
        test.deleteRequest(param1, param2, code);
    }

}