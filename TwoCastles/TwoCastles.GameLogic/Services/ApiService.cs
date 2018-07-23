using RestSharp;
using TwoCastles.GameLogic.Interfaces;

namespace TwoCastles.GameLogic.Services
{
    public class ApiService : IApiService
    {
        public void Get<T>(string url)
        {

        }

        public void Post<T>(string url, T model)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(model);
            IRestResponse response = client.Execute(request);
        }
    }
}
