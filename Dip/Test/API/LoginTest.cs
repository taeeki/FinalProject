using Dip.Helper;
namespace Dip.Test.API
{
    internal class LoginTest
    {
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PostUserCorrect(string user, string password)
        {
            var headersInfo = HelperAuthToken.HeadersDataRequestAdd(user, password);
            Assert.IsNotEmpty(headersInfo.auth_token);
        }

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
