using Dip.Helper;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.API
{
    [TestFixture]
    [AllureNUnit]
    internal class LoginTest
    {    
        [AllureName("Отправка данных юзера на сервер, чтобы получить токен авторизации.")]
        [AllureOwner("Терентьева Анна")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PostUserCorrect(string user, string password)
        {
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, password);
            Assert.IsNotEmpty(headersInfo.auth_token);
        }

        [AllureOwner("Терентьева Анна")]
        [AllureName("Отправка невалидных данных, токен авторизации не должен быть получен.")]
        [TestCase("", "")]
        [TestCase("uncor", "uncor")]
        [TestCase("", "fjnjn")]
        [TestCase("loginn", "")]
        public void PostUserUncor(string user, string pass)
        {
            var headersinfo = HelperAuthToken.HeadersDataRequestAdd(user, pass);
            Assert.IsNull(headersinfo.auth_token);
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Отправка запроса на авторизацию без заголовков запроса.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public async Task PostDataWithoutHeaders(string user, string pass)
        {
            HttpClient client = new HttpClient();
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, pass);
            // определяем данные запроса        
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://monkkee.com/api/authentication"))
            {
                // Отправляем запрос
                var response = client.SendAsync(requestMessage).Result;
                Assert.That((int)response.StatusCode, Is.EqualTo(422));
            }
        }

        [AllureOwner("Терентьева Анна")]
        [AllureName("Отправка запроса на авторизацию без токена авторизации (without Auth_Token).")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public async Task PostDataWithoutTokenAuth(string user, string pass)
        {
            HttpClient client = new HttpClient();
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, pass);
            // определяем данные запроса        
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://monkkee.com/api/authentication"))
            {
                requestMessage.Headers.Add("Cookie", headersInfo.cookie);
                requestMessage.Headers.Add("x-csrf-token", headersInfo.crft_token);
                requestMessage.Headers.Add("auth-token", headersInfo.auth_token);

                // Отправляем запрос
                var response = client.SendAsync(requestMessage).Result;
                Assert.That((int)response.StatusCode, Is.EqualTo(401));
            }
        }

    }
}
