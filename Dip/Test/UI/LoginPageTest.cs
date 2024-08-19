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
        [AllureOwner("Терентьева Анна")]
        public void TestThatPageNavigationOpen()
        {
            LoginPage.Open();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [TestCase("taeeeki", "123456Ana")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Успешная авторизация на сайте.")]
        public void CorrectAuth(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
        }
  
        [TestCase("frgjjgnt", "fbf")]
        [TestCase("terenteva1999@open.ru", "1125")]
        [TestCase("terenteva1999@yandex.ru", "576789")]
        [AllureName("Некорректная авторизация на сайте.")]
        [AllureOwner("Терентьева Анна")]
        public void UnCorrectLogin(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            var textresult = LoginPage.GetErrorMessage();
            Assert.That(textresult, Is.EqualTo("Login failed"));
        }

        [TestCase("", "")]
        [AllureName("Авторизация с незаполненными полями логина и пароля.")]
        [AllureOwner("Терентьева Анна")]
        public void AllParamIsNullLogin(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            if (LoginPage.GetMandatoryErrorLogin() == "Mandatory field" && LoginPage.GetMandatoryErrorPassword() == "Mandatory field")
                Assert.IsTrue(true);
         }
      
        [TestCase("gfbhfgthn", "")]
        [AllureName("Авторизация с незаполненными полем пароля.")]
        [AllureOwner("Терентьева Анна")]
        public void PassIsNullLoginIsNotNull(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.That(LoginPage.GetMandatoryErrorPassword(), Is.EqualTo("Mandatory field"));
        }
    
        [TestCase("", "арнош")]
        [AllureName("Авторизация с незаполненными полем пароля.")]
        [AllureOwner("Терентьева Анна")]
        public void LoginIsNullPassIsNotNull(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            Assert.That(LoginPage.GetMandatoryErrorLogin(), Is.EqualTo("Mandatory field"));
        }
    }
}
