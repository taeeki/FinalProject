using Dip.Helper;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.API
{
    [TestFixture]
    [AllureNUnit]
    internal class LoginTest
    {
        [AllureOwner("Терентьева Анна")]
        [AllureName("Отправка данных юзера на сервер, чтобы получить токен авторизации.")]
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
    }
}
