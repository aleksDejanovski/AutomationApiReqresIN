using HttpApiTest.GetEndpoint;
using HttpApiTest.MODEL;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpApiTest
{
    [TestFixture]
    public class Class1
    {
        private string getUrl = "https://reqres.in/api/users?page=2";
        private string getUrl2 = "https://reqres.in/api/users/2";
        private string getUr2Uknown = "https://reqres.in/api/unknown/2";
        private string getUrlUknown = "https://reqres.in/api/unknown";
        
        private string uknown = "https://reqres.in/api/unknown";

        [Test]
        public void GetEndpoint()
        {
            // step 1 create http client
            HttpClient httpClient = new HttpClient();

            httpClient.GetAsync(getUrl);

            //dispose
            httpClient.Dispose();

        }

        [Test]
        public void TestGetAllEndpointURI()
        {
            // step 1 create http client
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            //Console.WriteLine(httpResponseMessage.ToString());
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            String data2 = responseData.Result;
            Console.WriteLine(data2.ToString());
            Assert.IsTrue(responseData.Result.Contains("2"));



            //httpClient.GetAsync(getUri);

            httpClient.Dispose();


        }
        [Test]
        public void TestGetSingleUser()
        {
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl2);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            httpClient.Dispose();


        }
        [Test]
        public void GetUknownUser()
        {

            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUr2Uknown);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            String data1 = responseData.Result;
            Console.WriteLine(data1.ToString());

            httpClient.Dispose();


        }
        [Test]
        public void GetAnotherUser()
        {

            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrlUknown);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            //Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            String data = responseData.Result;
            Restresponse restResponse = new Restresponse((int)statusCode, responseData.Result);
            Console.WriteLine(restResponse.ToString());

            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            httpClient.Dispose();


        }
        [Test]
        public void GetCoutries()
        {

            //HttpClient httpClient = new HttpClient();
            //Uri getUri = new Uri(countries);
            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ii1LSTNROW5OUjdiUm9meG1lWm9YcWJIWkdldyIsImtpZCI6Ii1LSTNROW5OUjdiUm9meG1lWm9YcWJIWkdldyJ9.eyJhdWQiOiI1M2MyMzljNS1kMWRiLTRjYzQtYTg5Zi0wYWZhMWU1OGJkOWYiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC84MWVjMjJkZS05OGM0LTQyZDctODExOS1lYmIzMTIyMWQyNjgvIiwiaWF0IjoxNjg0MzMyMDkyLCJuYmYiOjE2ODQzMzIwOTIsImV4cCI6MTY4NDMzNzYyMywiYWNyIjoiMSIsImFpbyI6IkFUUUF5LzhUQUFBQUdaYmhmMHY0bXowN1R6UmNuL09nblJycDdtK2sxNzhiTTVVc0xqUWFqUCtIZVdtRENDRmFBT1UwbDlQUEl1bVMiLCJhbXIiOlsicHdkIiwicnNhIl0sImFwcGlkIjoiNDMwNmViYWQtMzEyMy00MDA5LTk4OTQtZDJiZGE2NDZiM2ZiIiwiYXBwaWRhY3IiOiIwIiwiZGV2aWNlaWQiOiI1YWY1OTZkYy01NDAxLTQ2YmQtODliNC1kNzU3OTdlNWRkNWMiLCJmYW1pbHlfbmFtZSI6IkRlamFub3Zza2kiLCJnaXZlbl9uYW1lIjoiQWxla3NhbmRhciIsImlwYWRkciI6Ijk1LjE4MC4xNTMuNTMiLCJuYW1lIjoiRGVqYW5vdnNraSwgQWxla3NhbmRhciIsIm9pZCI6IjU0ZTBjMTNkLTAyZmQtNGU2OS1iMzI0LTM2MTYyNDA4YzMxNiIsIm9ucHJlbV9zaWQiOiJTLTEtNS0yMS0xNjEwOTQ2MDgtNDA3MDc4NDE1OS0xMDEzNTg3MjkzLTExMzg3NyIsInJoIjoiMC5BUXdBM2lMc2djU1kxMEtCR2V1ekVpSFNhTVU1d2xQYjBjUk1xSjhLLWg1WXZaLVdBRjAuIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoid25ZX3dDR2kxamtocTgzZk50YjR0UDVLdEltMV9wSGpiWFRyZjJBcGxEdyIsInRpZCI6IjgxZWMyMmRlLTk4YzQtNDJkNy04MTE5LWViYjMxMjIxZDI2OCIsInVuaXF1ZV9uYW1lIjoiYWxla3NhbmRhci5kZWphbm92c2tpQGthdG9lbm5hdGllLmNvbSIsInVwbiI6ImFsZWtzYW5kYXIuZGVqYW5vdnNraUBrYXRvZW5uYXRpZS5jb20iLCJ1dGkiOiJiallDUllwRFgwdUxWbFBQN2w4R0FBIiwidmVyIjoiMS4wIn0.f2Jz_rYOutMVBo45XqiOo0RzOvcwCMmqgvxsxeZN9K_hpOnYa71EG2gCSjqEZX8BH9Xpgz2C9rtXvnD8ybeTAF5ciiH8O29 - MKRoi5mFNXVloktWZZpDebA - 5KzuUNHehccUDk - bHS - vz2GKxcNh9l2XxNNYcJA0shEfiYwnc3J - 6HjWiFH29N5EpxsCIwBkIPlQeYI7b0GijRgwJPC - 1CiwUK6AUbiKMGjORjq379DHLnKFWIO68f_lKgEy20TXEPOKOFuDTII2OGT1ecfbCZKLyj9tO49ZW_6xAPomaFA_U8iB0Y6AJGbU1YMkSBwEhIM4ti1Ot_mjEf9keQJjWg");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ii1LSTNROW5OUjdiUm9meG1lWm9YcWJIWkdldyIsImtpZCI6Ii1LSTNROW5OUjdiUm9meG1lWm9YcWJIWkdldyJ9.eyJhdWQiOiI1M2MyMzljNS1kMWRiLTRjYzQtYTg5Zi0wYWZhMWU1OGJkOWYiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC84MWVjMjJkZS05OGM0LTQyZDctODExOS1lYmIzMTIyMWQyNjgvIiwiaWF0IjoxNjg0MzMyMDkyLCJuYmYiOjE2ODQzMzIwOTIsImV4cCI6MTY4NDMzNzYyMywiYWNyIjoiMSIsImFpbyI6IkFUUUF5LzhUQUFBQUdaYmhmMHY0bXowN1R6UmNuL09nblJycDdtK2sxNzhiTTVVc0xqUWFqUCtIZVdtRENDRmFBT1UwbDlQUEl1bVMiLCJhbXIiOlsicHdkIiwicnNhIl0sImFwcGlkIjoiNDMwNmViYWQtMzEyMy00MDA5LTk4OTQtZDJiZGE2NDZiM2ZiIiwiYXBwaWRhY3IiOiIwIiwiZGV2aWNlaWQiOiI1YWY1OTZkYy01NDAxLTQ2YmQtODliNC1kNzU3OTdlNWRkNWMiLCJmYW1pbHlfbmFtZSI6IkRlamFub3Zza2kiLCJnaXZlbl9uYW1lIjoiQWxla3NhbmRhciIsImlwYWRkciI6Ijk1LjE4MC4xNTMuNTMiLCJuYW1lIjoiRGVqYW5vdnNraSwgQWxla3NhbmRhciIsIm9pZCI6IjU0ZTBjMTNkLTAyZmQtNGU2OS1iMzI0LTM2MTYyNDA4YzMxNiIsIm9ucHJlbV9zaWQiOiJTLTEtNS0yMS0xNjEwOTQ2MDgtNDA3MDc4NDE1OS0xMDEzNTg3MjkzLTExMzg3NyIsInJoIjoiMC5BUXdBM2lMc2djU1kxMEtCR2V1ekVpSFNhTVU1d2xQYjBjUk1xSjhLLWg1WXZaLVdBRjAuIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoid25ZX3dDR2kxamtocTgzZk50YjR0UDVLdEltMV9wSGpiWFRyZjJBcGxEdyIsInRpZCI6IjgxZWMyMmRlLTk4YzQtNDJkNy04MTE5LWViYjMxMjIxZDI2OCIsInVuaXF1ZV9uYW1lIjoiYWxla3NhbmRhci5kZWphbm92c2tpQGthdG9lbm5hdGllLmNvbSIsInVwbiI6ImFsZWtzYW5kYXIuZGVqYW5vdnNraUBrYXRvZW5uYXRpZS5jb20iLCJ1dGkiOiJiallDUllwRFgwdUxWbFBQN2w4R0FBIiwidmVyIjoiMS4wIn0.f2Jz_rYOutMVBo45XqiOo0RzOvcwCMmqgvxsxeZN9K_hpOnYa71EG2gCSjqEZX8BH9Xpgz2C9rtXvnD8ybeTAF5ciiH8O29 - MKRoi5mFNXVloktWZZpDebA - 5KzuUNHehccUDk - bHS - vz2GKxcNh9l2XxNNYcJA0shEfiYwnc3J - 6HjWiFH29N5EpxsCIwBkIPlQeYI7b0GijRgwJPC - 1CiwUK6AUbiKMGjORjq379DHLnKFWIO68f_lKgEy20TXEPOKOFuDTII2OGT1ecfbCZKLyj9tO49ZW_6xAPomaFA_U8iB0Y6AJGbU1YMkSBwEhIM4ti1Ot_mjEf9keQJjWg");

            //Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            //HttpResponseMessage httpResponseMessage = httpResponse.Result;
            //HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            //Console.WriteLine(statusCode);
            //HttpContent responseContent = httpResponseMessage.Content;
            //Task<string> responseData = responseContent.ReadAsStringAsync();
            //String data = responseData.Result;

            //Console.WriteLine(data.ToString());
            //httpClient.Dispose();


        }
        [Test]
        public void sample1()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(uknown);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            //Task<string> response2 = responseContent.ReadAsStringAsync();
            String data2 = responseData.Result;
            Console.WriteLine(data2.ToString());
        }
        [Test]
        public void GetAnotherUserDeserilized()
        {

            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrlUknown);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            //Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            String data = responseData.Result;
            Restresponse restResponse = new Restresponse((int)statusCode, responseData.Result);
            Console.WriteLine(restResponse.ToString());
            //JsonRootObject jsonRootObject = JsonConvert.DeserializeObject<JsonRootObject>(restResponse.ResponseContent);

            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            httpClient.Dispose();

        }
    }
}

