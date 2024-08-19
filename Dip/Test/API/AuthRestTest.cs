using Dip.Helper;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using RestSharp;

namespace Dip.Test.API
{
    [TestFixture]
    [AllureNUnit]
    internal class AuthRestTest
    {
        private const string BaseUrl = "https://monkkee.com/api";
      
        [AllureOwner("Терентьева Анна")]
        [AllureName("Отправка запроса на авторизацию без токенов.")]
        [Test]
        public void PostUserWithoutTokens()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("/authentication", Method.Post);
            var response = client.Execute(request);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.That(response.Content, Is.EqualTo("{\"status\":422,\"error\":\"Unprocessable Entity\"}"));
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Добавление нового тега в дневник.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void TagsAddNew(string email, string password)
        {
            var client = new RestClient(BaseUrl); 
            var request = new RestRequest("/tags", Method.Post);
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(email, password);
            request.AddHeader("Cookie", headersInfo.cookie);
            request.AddHeader("X-Csrf-Token", headersInfo.crft_token);
            request.AddHeader("Auth-Token", headersInfo.auth_token);
            request.AddJsonBody(new
            {
                id = 33,
                name = "U2FsdGVkX18Dbg2dVHm7k8qzK6C/26mZXc7EsYNknQ="
            }); ;
            var response = client.Execute(request);
            var jsonResponse = JObject.Parse(response.Content);
         
            Assert.That((int)response.StatusCode, Is.EqualTo(201));
        }
    }
}
