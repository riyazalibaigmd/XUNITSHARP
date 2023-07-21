namespace TestProject1.Utils
{
    public class RestActions
    {
        public RestClient client;
        public RestRequest request;
        public RestResponse response;
        public const string URL = Constants.baseURL;

        public void setBaseURL(){
            client = new RestClient();
            request = new RestRequest(URL);
        }

         public void setBaseURL(string pathParam){
            client = new RestClient(URL);
            request = new RestRequest(pathParam);
        }

        public void setBaseURL(string param1, string param2){
            client = new RestClient();
            request = new RestRequest($"{URL}/{param1}/{param2}");
        }

        public void AddUrlSegment(string name, string value){
             request.AddUrlSegment(name, value);
        }

        public void AddHeader(string name, string value){
            request.AddHeader(name, value);
        }

        public void AddOrUpdateHeader(string name, string value){
            request.AddOrUpdateHeader(name, value);
        }

        public void AddParameter(string name, string value){
            request.AddParameter(name, value);
        }

        public void AddQueryParameter(string name, string value){
            request.AddQueryParameter(name, value);
        }

        public void AddCookie(string name, string value, string path, string domain){
            request.AddCookie(name, value, path, domain);
        }

        public void AddBody(object param){
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(param);
        }

       public void AddJsonBody(object param){
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddJsonBody(param);
        }

        public void AddJsonBody(object param, string contentType){
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddJsonBody(param, contentType);
        }

        public void AddFile(string name, string path, string contentType){
            request.AddFile(name, path, contentType);
        }

        public void AddFile(string name, byte[] bytes, string path, string contentType){
            request.AddFile(name, bytes, path, contentType);
        }

        public void AddFileBytes(string name, byte[] bytes, string path, string contentType){
            request.AddFile(name, bytes, path, contentType);
        }
           
        public void GetCall(){
            response = client.ExecuteGet(request);
        }

        public void PostCall(){
            response = client.ExecutePost(request);
        }

        public void PutCall(){
            response = client.ExecutePut(request);
        }

        public void DeleteCall(){
            response = client.Delete(request);
        }

        public void checkOKStatusCode(){
            int respCode = (int)response.StatusCode;
            Assert.Equal(200, respCode);
        }

        public void checkNotFoundStatusCode(){
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        public void checkStatusCode(int code){
            int respCode = (int)response.StatusCode;
            Assert.Equal(code, respCode);
        }

        public void checkOKStatusCode(HttpStatusCode code){
           Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public void checkStatusCode(HttpStatusCode code){
            Assert.Equal(code, response.StatusCode);
        }

        public object respContent(){
            return response.Content;
        }

        public void validateRespFields(string name, string job){
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            var respName = jsonResponse.name.ToString();
            var respJob = jsonResponse.job.ToString();
            Assert.Equal(name, respName);
            Assert.Equal(job, respJob);
        }
    }
}