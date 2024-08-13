using Dip.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Test.API
{
    internal class TagsTest
    {
        const string baseurl = "https://monkkee.com/";

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

        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public async Task DeleteTagsDiary(string user, string pass)
        {
            HttpClient client = new HttpClient();
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, pass);
            // определяем данные запроса        
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{baseurl}api/tags/329906"))
            {
                requestMessage.Headers.Add("Cookie", headersInfo.cookie);
                requestMessage.Headers.Add("x-csrf-token", headersInfo.crft_token);
                requestMessage.Headers.Add("Auth-Token", headersInfo.auth_token);               
                // Отправляем запрос
                var response = client.SendAsync(requestMessage).Result;
                Assert.That((int)response.StatusCode, Is.EqualTo(200));
            }
        }
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

        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public async Task GetTagsDiary(string user, string pass)
        {
            HttpClient client = new HttpClient();
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, pass);
            // определяем данные запроса        
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{baseurl}api/tags/329904"))
            {
                requestMessage.Headers.Add("Cookie", headersInfo.cookie);
                requestMessage.Headers.Add("x-csrf-token", headersInfo.crft_token);
                requestMessage.Headers.Add("Auth-Token", headersInfo.auth_token);
                requestMessage.Content = JsonContent.Create(new
                {
                    id = 329904
                }); 
                // Отправляем запрос
                var response = client.SendAsync(requestMessage).Result;
                Assert.That((int)response.StatusCode, Is.EqualTo(200));
            }
        }

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
