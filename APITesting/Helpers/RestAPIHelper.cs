using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace APITesting.Helpers
{
    public class RestAPIHelper
    {
    
        public static RestClient _restClient;
        public static RestRequest _restRequest;
        public static IRestResponse _response;

        public static string baseUrl = "https://api.postcodes.io/postcodes/";

        public static RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            return _restClient = new RestClient(url);
        }
        public static RestClient BaseUrl()
        {
          return _restClient = new RestClient(baseUrl);
        }

        private static RestRequest SetMethod(string method)
        {
            switch (method)
            {
                case "GET":
                    _restRequest.Method = Method.GET;
                    break;
                case "POST":
                    _restRequest.Method = Method.POST;
                    break;
                case "PUT":
                    _restRequest.Method = Method.PUT;
                    break;
                default:
                    _restRequest.Method = Method.GET;
                    break;
            }
            return _restRequest;
        }

        
        public static RestRequest CreateGetRequest()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public static RestRequest CreatePostcodePostRequest(IList <string> postcodess)
        {
            var userInfo = new postCodeBody();
            userInfo.postcodes = postcodess;
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddBody(userInfo); 
           _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }
        public static IRestResponse GetResponse()
        {
            return _restClient.Execute(_restRequest);
        }


        public HttpStatusCode ReturnStatusCode()
        {
            return _response.StatusCode;
        }

        public ResponseStatus ReturnResponseStatus()
        {
            return _response.ResponseStatus;
        }
    }
}



/*
 * using RestSharp;
using System.IO;
using System.Net;

namespace APITesting.Helpers
{
    public class RestAPIHelper
    {
    
        public static RestClient _restClient;
        public static RestRequest _restRequest;
        private IRestResponse _response;

        public static string baseUrl = "api.postcodes.io/postcodes/";

        public static RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            return _restClient = new RestClient(url);
        }

        private static RestRequest SetMethod(string method)
        {
            switch (method)
            {
                case "GET":
                    _restRequest.Method = Method.GET;
                    break;
                case "POST":
                    _restRequest.Method = Method.POST;
                    break;
                case "PUT":
                    _restRequest.Method = Method.PUT;
                    break;
                default:
                    _restRequest.Method = Method.GET;
                    break;
            }
            return _restRequest;
        }


        public static RestRequest CreateGetRequest(string method)
        {
           var methods =  SetMethod(method.);
            methods.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public static RestRequest CreatePostRequest(string method)
        {
            var userInfo = new userBody();
            userInfo.firstname = "Khalid";
            var resource = "/registred";
            _restRequest = new RestRequest(resource, Method.POST);
            _restRequest.AddBody(userInfo); 
            _restRequest.AddHeader("Accept", "application/json");
            return _restRequest;
        }

        public static IRestResponse GetResponse()
        {
            return _restClient.Execute(_restRequest);
        }

        public HttpStatusCode ReturnStatusCode()
        {
            return _response.StatusCode;
        }

        public ResponseStatus ReturnResponseStatus()
        {
            return _response.ResponseStatus;
        }
    }
}

    */