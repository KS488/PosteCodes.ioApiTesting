using TechTalk.SpecFlow;
using APITesting.Helpers;
using NUnit.Framework;
using APITesting.Assertions;
using System.Collections.Generic;
using RestSharp;

namespace APITesting.Steps
{
    [Binding]
    public class APITestingSteps
    {
        private PostCodeResponse postCodeResponse;
        private string inputPostcodes;
        private string responsePostCode;
        private string originalSpacePostcode;
        private string responseSpacePostecode;
        public IRestResponse apiResponse;

     [Given(@"I have a postcode to lookup(.*)")]
        public void GivenIHaveAPostcodeToLookup(string postcode)
        {
            RestAPIHelper.SetUrl(postcode);
            inputPostcodes = postcode;
        }

        [When(@"I call the get method")]
        public void WhenICallTheGetMethod()
        {
            RestAPIHelper.CreateGetRequest();
        }
        
        [Then(@"i should get back information of my chosen postcode")]
        public void ThenIShouldGetBackInformationOfMyChosenPostcode()
        {
            apiResponse = RestAPIHelper.GetResponse();
            postCodeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<PostCodeResponse>(apiResponse.Content);
            responsePostCode = postCodeResponse.result.postcode;
            originalSpacePostcode =  GenericHelper.stringSpaceConveter(inputPostcodes);
            responseSpacePostecode = GenericHelper.responseSpaceConverter(responsePostCode);
            //--ToDo Move Assertions to the Assertions Folder --//
            Assert.That(postCodeResponse.status, Is.EqualTo(200), "Test StatusCode Not 200");
            Assert.That(responseSpacePostecode, Is.EqualTo(originalSpacePostcode));
            
        }
        [Given(@"I called the base url")]
        public void GivenICalledTheBaseUrl()
        {
            RestAPIHelper.BaseUrl();
        }

        [When(@"I call the post method with the bulk")]
        public void WhenICallThePostMethodWithTheBulk()
        {
            
            List<string> postCode = new List<string>() { "W12 0LQ", "UB5 6AP", "W6 0TR" };
            string[] myArray = postCode.ToArray();  
            RestAPIHelper.CreatePostcodePostRequest(myArray);
        }

        [Then(@"i should get back information of all postcodes chosen")]
        public void ThenIShouldGetBackInformationOfAllPostcodesChosen()
        {
            /// -- Test Currently failing -- ///
            apiResponse = RestAPIHelper.GetResponse();
            postCodeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<PostCodeResponse>(apiResponse.Content);
            Assert.That(postCodeResponse.status, Is.EqualTo(200), "Test StatusCode Not 200");
        }
    }
}