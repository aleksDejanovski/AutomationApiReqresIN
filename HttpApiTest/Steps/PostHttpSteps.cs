using HttpApiTest.PostEndpoint;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace HttpApiTest.Steps
{
    [Binding]
    public class PostHttpSteps
    {
        HttpClient httpClient;
        HttpResponseMessage response;
        string responsebody;
        private readonly ISpecFlowOutputHelper outputHelper;

        public PostHttpSteps(ISpecFlowOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
            httpClient = new HttpClient();
        }


        [Given(@"The user sends a post request to a url ""([^""]*)""")]
        public async Task GivenTheUserSendsAPostRequestToAUrl(string uri)
        {
            PostData postData = new PostData()
            {
                
                name = "ace",
                job = "teacher"
            };
            string data = JsonConvert.SerializeObject(postData);
            var contentdata = new StringContent(data);

          response = await  httpClient.PostAsync(uri, contentdata);
            responsebody = await response.Content.ReadAsStringAsync();
            outputHelper.WriteLine("response body is" + responsebody);

        }

        [Then(@"user should get a success response")]
        public void ThenUserShouldGetASuccessResponse()
        {
            Assert.True(response.IsSuccessStatusCode);
        }

        [Given(@"The user sends a get request to a url ""([^""]*)""")]
        public void GivenTheUserSendsAGetRequestToAUrl(string uri)
        {
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(uri);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
        }

        [Then(@"user should get a success get response")]
        public void ThenUserShouldGetASuccessGetResponse()
        {
           // Assert.True(httpResponse);
        }


    }
}
