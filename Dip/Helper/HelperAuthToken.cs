using Dip.Models.Request;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Dip.Models.Response;
namespace Dip.Helper
{
    internal class HelperAuthToken
    {
        private const string baseurl = "https://monkkee.com/";
        public static HeaderInfo HeadersDataRequestAdd(string user, string password)
        {
            var client = new HttpClient();
            var response1 = client.GetAsync($"{baseurl}app/#/").Result;
            var responseContent1 = response1.Content.ReadAsStringAsync().Result;
            //вычленяем серт из html-страницы, поскольку без него не отправить запросы в апи 
            var csrfToken = Regex.Match(responseContent1, "<meta\\s+name=\"csrf-token\"\\s+content=\"([^\"]*)\"").Groups[1].Value;

            response1.Headers.TryGetValues("Set-Cookie", out var cookies);
            //получаем все кукки страницы
            var cookiesresult = string.Join(";", cookies.Select(cookie => cookie.Split(";")[0]));
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{baseurl}api/authentication"))
            {
                // Добавляем заголовок Cookie
                requestMessage.Headers.Add("Cookie", cookiesresult);
                requestMessage.Headers.Add("x-csrf-token", csrfToken);
                requestMessage.Content = JsonContent.Create(new
                {
                    login = user,
                    password = HashPassword(password)
                }); ;
                // Отправляем запрос
                var response2 = client.SendAsync(requestMessage).Result;

                // Читаем и выводим содержимое ответа
                var responseContent = response2.Content.ReadFromJsonAsync<AuthToken>().Result;
                Console.WriteLine(responseContent);
                HeaderInfo headersInfo = new HeaderInfo()
                {
                    auth_token = responseContent.auth_token,
                    crft_token = csrfToken,
                    cookie = cookiesresult
                };
                return headersInfo;
            }
        }
        public static string HashPassword(string password)
        {
            string saltString = "7c1dffr7M/Se+xR4JM+HKqL6H/V/q35thu/7W0wK8HZw==b0b25f39cfa371af65c4df2df7df438ec0joo/wlV2dg5ZqrBpGPfUAw==0425c0b9293386bedb55d5ca";
            int iterations = 1600;
            int hashLength = 20; 

            // Конвертация 
            byte[] salt = Encoding.UTF8.GetBytes(saltString);

            // генерируем хэш
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA1))
            {
                byte[] hash = pbkdf2.GetBytes(hashLength);
                string hashHex = BitConverter.ToString(hash).Replace("-", "").ToLower();
                Console.WriteLine($"Derived key (hex): {hashHex}");
                return hashHex;
            }
        }

    }
}
