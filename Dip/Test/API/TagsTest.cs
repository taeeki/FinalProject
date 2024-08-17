using Dip.Helper;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System.Net.Http.Json;
namespace Dip.Test.API
{
    [TestFixture]
    [AllureNUnit]
    internal class TagsTest
    {
        const string baseurl = "https://monkkee.com/";

        [AllureOwner("Терентьева Анна")]
        [AllureName("Отправка данных о новом теге методом Post.")]
        [AllureSuite("Тестирование запросов авторизации в API.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public async Task PostTagsDiary(string user, string pass)
        {
            HttpClient client = new HttpClient();
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, pass);
            // определяем данные запроса        
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{baseurl}api/tags"))
            {
                requestMessage.Headers.Add("Cookie", headersInfo.cookie);
                requestMessage.Headers.Add("x-csrf-token", headersInfo.crft_token);
                requestMessage.Headers.Add("Auth-Token", headersInfo.auth_token);
                requestMessage.Content = JsonContent.Create(new
                {
                    id = 33,
                    name = "U2FsdGVkX18Dbg2dVHm7k8qzK6C/26mZXc7EsYNknQ="
                }); ;
                // Отправляем запрос
                var response = client.SendAsync(requestMessage).Result;
                Assert.That((int)response.StatusCode, Is.EqualTo(201));
            }
        }

        [AllureOwner("Терентьева Анна")]
        [AllureName("Попытка удаления тега, который уже был удален.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public async Task DeleteTagsDiaryIsAlredyDelete404(string user, string pass)
        {
            HttpClient client = new HttpClient();
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, pass);
            // определяем данные запроса        
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{baseurl}api/tags/329908"))
            {
                requestMessage.Headers.Add("Cookie", headersInfo.cookie);
                requestMessage.Headers.Add("x-csrf-token", headersInfo.crft_token);
                requestMessage.Headers.Add("Auth-Token", headersInfo.auth_token);

                // Отправляем запрос
                var response = client.SendAsync(requestMessage).Result;
                Assert.That((int)response.StatusCode, Is.EqualTo(404));
            }
        }

        [AllureOwner("Терентьева Анна")]
        [AllureName("Отправка запроса без токена авторизации.")]
        [TestCase("", "")]
        [TestCase("terenteva@open.ru", "11111")]
        public async Task NotAuthDataPost(string user, string pass)
        {
            HttpClient client = new HttpClient();
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, pass);
            // определяем данные запроса        
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{baseurl}api/tags"))
            {
                requestMessage.Headers.Add("Cookie", headersInfo.cookie);
                requestMessage.Headers.Add("x-csrf-token", headersInfo.crft_token);
                requestMessage.Headers.Add("Auth-Token", headersInfo.auth_token);
                requestMessage.Content = JsonContent.Create(new
                {
                    id = 33,
                    name = "U2FsdGVkX18Dbg2dVHm7k8qzK6C/026mZXc7EsYNknQ="
                }); ;
                // Отправляем запрос
                var response = client.SendAsync(requestMessage).Result;
                Assert.That((int)response.StatusCode, Is.EqualTo(401));
            }
        }
    }
}
