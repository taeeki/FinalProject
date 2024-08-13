using Dip.Page;
namespace Dip.Test.UI
{
    internal class LoginPageTest : BasePageTest
    {
        [Test]
        public void TestThatPageNavigationOpen()
        {
            LoginPage.Open();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [TestCase("taeeeki", "123456Ana")]
        public void CorrectAuth(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
        }
        [TestCase("frgjjgnt", "fbf")]
        [TestCase("terenteva1999@open.ru", "1125")]
        [TestCase("terenteva1999@yandex.ru", "576789")]
        public void UnCorrectLogin(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            var textresult = LoginPage.GetErrorMessage();
            Assert.That(textresult, Is.EqualTo("Login failed"));
        }
        [TestCase("", "")]
        public void AllParamIsNullLogin(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            if (LoginPage.GetMandatoryErrorLogin() == "Mandatory field" && LoginPage.GetMandatoryErrorPassword() == "Mandatory field")
                Assert.IsTrue(true);
         }
           
        [TestCase("gfbhfgthn", "")]
        public void PassIsNullLoginIsNotNull(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.That(LoginPage.GetMandatoryErrorPassword(), Is.EqualTo("Mandatory field"));
        }
        [TestCase("", "")]
        public void LoginIsNullPassIsNotNull(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.That(LoginPage.GetMandatoryErrorLogin(), Is.EqualTo("Mandatory field"));
        }
    }
}
