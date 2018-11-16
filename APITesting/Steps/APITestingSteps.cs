using System;
using TechTalk.SpecFlow;
using APITesting.Helpers;
using Ninject;
using NUnit.Framework;
using Ninject.Modules;
using APITesting.Assertions;
using System.Linq;
using Shouldly;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace APITesting.Steps
{
    [Binding]
    public class APITestingSteps
    {
        private PostcodeAssertion postcodeAssertion;
        private PostCodeResponse postCodeResponse;
        public string postcodes;

        [Given(@"I have a postcode to lookup(.*)")]
        public void GivenIHaveAPostcodeToLookup(string postcode)
        {
            RestAPIHelper.SetUrl(postcode);
           postcodes = postcode;
        }

        [When(@"I call the get method")]
        public void WhenICallTheGetMethod()
        {
            RestAPIHelper.CreateGetRequest();
        }


        [Then(@"i should get back information of my chosen postcode")]
        public void ThenIShouldGetBackInformationOfMyChosenPostcode()
        {
            var apiResponse = RestAPIHelper.GetResponse();
            postCodeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<PostCodeResponse>(apiResponse.Content);
            string postCode = postCodeResponse.result.postcode;
            string res = Regex.Replace(postcodes, ".{4}", "$0 ");
            var spacePostCode = Regex.Replace(postCode, ".{4}", " $0");
            Assert.That(postCodeResponse.status, Is.EqualTo(200), "Test Status Not 200");
            Assert.That(spacePostCode, Is.EqualTo(res));
            
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
            var apiResponse = RestAPIHelper.GetResponse();
        }
    }
}
