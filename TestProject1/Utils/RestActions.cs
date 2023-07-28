namespace TestProject1.Utils
{
    public class RestActions
    {
        private RestClient httpClient;
        private RestRequest httpRequest;
        private RestResponse httpResponse;

        public void SetBaseURL(){
            httpClient = new RestClient();
            httpRequest = new RestRequest(Constants.BaseURL);
        }

         public void SetBaseURL(string pathParam){
            httpClient = new RestClient(Constants.BaseURL);
            httpRequest = new RestRequest(pathParam);
        }

        public void SetBaseURL(string param1, string param2){
            httpClient = new RestClient();
            httpRequest = new RestRequest($"{Constants.BaseURL}/{param1}/{param2}");
        }

        public void AddUrlSegment(string name, string value){
             httpRequest.AddUrlSegment(name, value);
        }

        public void AddHeader(string name, string value){
            httpRequest.AddHeader(name, value);
        }

        public void AddOrUpdateHeader(string name, string value){
            httpRequest.AddOrUpdateHeader(name, value);
        }

        public void AddParameter(string name, string value){
            httpRequest.AddParameter(name, value);
        }

        public void AddQueryParameter(string name, string value){
            httpRequest.AddQueryParameter(name, value);
        }

        public void AddCookie(string name, string value, string path, string domain){
            httpRequest.AddCookie(name, value, path, domain);
        }

        public void AddBody(object param){
            httpRequest.RequestFormat = RestSharp.DataFormat.Json;
            httpRequest.AddBody(param);
        }

       public void AddJsonBody(object param){
            httpRequest.RequestFormat = RestSharp.DataFormat.Json;
            httpRequest.AddJsonBody(param);
        }

        public void AddJsonBody(object param, string contentType){
            httpRequest.RequestFormat = RestSharp.DataFormat.Json;
            httpRequest.AddJsonBody(param, contentType);
        }

        public void AddFile(string name, string path, string contentType){
            httpRequest.AddFile(name, path, contentType);
        }

        public void AddFile(string name, byte[] bytes, string path, string contentType){
            httpRequest.AddFile(name, bytes, path, contentType);
        }

        public void AddFileBytes(string name, byte[] bytes, string path, string contentType){
            httpRequest.AddFile(name, bytes, path, contentType);
        }
           
        public void GetCall(){
            httpResponse = httpClient.ExecuteGet(httpRequest);
        }

        public void PostCall(){
            httpResponse = httpClient.ExecutePost(httpRequest);
        }

        public void PutCall(){
            httpResponse = httpClient.ExecutePut(httpRequest);
        }

        public void DeleteCall(){
            httpResponse = httpClient.Delete(httpRequest);
        }

        public void CheckOKStatusCode(){
            int respCode = (int)httpResponse.StatusCode;
            Assert.Equal(200, respCode);
        }

        public void CheckNotFoundStatusCode(){
            Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        public void CheckStatusCode(int code){
            int respCode = (int)httpResponse.StatusCode;
            Assert.Equal(code, respCode);
        }

        public void CheckOKStatusCode(HttpStatusCode code){
           Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        public void CheckStatusCode(HttpStatusCode code){
            Assert.Equal(code, httpResponse.StatusCode);
        }

        public object RespContent(){
            return httpResponse.Content;
        }

        public void ValidateRespFields(string name, string job){
            dynamic jsonResponse = JsonConvert.DeserializeObject(httpResponse.Content);
            var respName = jsonResponse.name.ToString();
            var respJob = jsonResponse.job.ToString();
            Assert.Equal(name, respName);
            Assert.Equal(job, respJob);
        }
    }
}