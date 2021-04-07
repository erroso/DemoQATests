using System;
using RestSharp;
using Newtonsoft.Json;

namespace DemoQATests.Hooks
{
    public class AccountAPI
    {
        private static string _endPoint = "https://demoqa.com/Account/v1/User";

        public static IRestResponse registerUser(Login user)
        {
            var request = new RestRequest();
            request.Parameters.Clear();
            request.Method = Method.POST;
            var json = JsonConvert.SerializeObject(user);

            if (!String.IsNullOrWhiteSpace(json))
            {
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }
            var restClient = new RestClient(_endPoint);
            var response = restClient.Execute(request);

            return response;
        }
    }
}
