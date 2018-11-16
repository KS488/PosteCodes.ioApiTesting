using System;
using System.Globalization;
using System.Linq;
using Shouldly;
using APITesting.Helpers;
using RestSharp;

namespace APITesting.Assertions
{
   public class PostcodeAssertion
    {

        private readonly PostCodeResponse postCodeResponse;
        public PostcodeAssertion(PostCodeResponse postCodeResponse)
        {
            this.postCodeResponse = postCodeResponse;
        }

        public virtual PostcodeAssertion postCodetheSame(PostCodeResponse newPostcoderesponse,string postcode)
        {
            newPostcoderesponse.result.outcode.ShouldBeSameAs(postcode);
            return this;
        }
       
    }
}
