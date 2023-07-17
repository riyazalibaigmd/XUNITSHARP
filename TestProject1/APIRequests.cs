using RestSharp;
using System.Net;
using Newtonsoft.Json;
using Xunit;

namespace TestProject1
{
    public class APIRequests
    {
        public const string URL = "https://reqres.in/api";

        public void getRequest()
        {
            var client = new RestClient(URL);    
            var request = new RestRequest("users").AddParameter("page", "2");
            var response = client.Get(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void getRequest(string param1, string param2, HttpStatusCode code){
            var client = new RestClient($"{URL}/{param1}/{param2}");
            var request = new RestRequest();
            var response = client.Get(request);
            Assert.Equal(code, response.StatusCode);
        }

        public void postCreateRequest(string pathParam, string name, string job, HttpStatusCode code){
            var client = new RestClient(URL);
            var request = new RestRequest(pathParam);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name, job });
            
            var response = client.ExecutePost(request);
            Assert.Equal(code, response.StatusCode);

            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            validateResponseFields(name, job, jsonResponse);
        }

        public void validateResponseFields(string name, string job, dynamic jsonResponse){
            var respName = jsonResponse.name.ToString();
            var respJob = jsonResponse.job.ToString();
            Assert.Equal(name, respName);
            Assert.Equal(job, respJob);
        }

        public void postRequest(string pathParam, string email, string password, HttpStatusCode code){
            var client = new RestClient(URL);
            var request = new RestRequest(pathParam);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { email, password });
            
            var response = client.ExecutePost(request);
            Assert.Equal(code, response.StatusCode);
        }

        public void putRequest(string param1, string param2, string name, string job, HttpStatusCode code){
            var client = new RestClient($"{URL}/{param1}/{param2}");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name, job });
            
            var response = client.ExecutePut(request);
            Assert.Equal(code, response.StatusCode);
            
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            validateResponseFields(name, job, jsonResponse);
        }

        public void deleteRequest(string param1, string param2, HttpStatusCode code){
            var client = new RestClient($"{URL}/{param1}/{param2}");
            var request = new RestRequest();
            request.AddHeader("Accept", "*/*");

            var response = client.Delete(request);
            Assert.Equal(code, response.StatusCode);
        }

    }
}