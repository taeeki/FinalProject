using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class LoginPageTest : BasePageTest
    {
        [Test]
        public void TestThatPageNavigationOpen()
        {
            LoginPage.Open();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Успешная авторизация на сайте.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [TestCase("taeeeki", "123456Ana")]
        public void CorrectAuth(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Некорректная авторизация на сайте.")]
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
        [AllureOwner("Терентьева Анна")]
        [AllureName("Авторизация с незаполненными полями логина и пароля.")]
        [TestCase("", "")]
        public void AllParamIsNullLogin(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            if (LoginPage.GetMandatoryErrorLogin() == "Mandatory field" && LoginPage.GetMandatoryErrorPassword() == "Mandatory field")
                Assert.IsTrue(true);
         }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Авторизация с незаполненными полем пароля.")]
        [TestCase("gfbhfgthn", "")]
        public void PassIsNullLoginIsNotNull(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.That(LoginPage.GetMandatoryErrorPassword(), Is.EqualTo("Mandatory field"));
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Авторизация с незаполненными полем пароля.")]
        [TestCase("", "арнош")]
        public void LoginIsNullPassIsNotNull(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.That(LoginPage.GetMandatoryErrorLogin(), Is.EqualTo("Mandatory field"));
        }
    }
}
