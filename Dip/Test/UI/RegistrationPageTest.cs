using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class RegistrationPageTest : BasePageTest
    {
        [AllureOwner("Терентьева Анна")]
        [AllureName("Успешная регистрация на сайте.")]
        [TestCase("terenteva1999@yandex.ru", "123456Anaaaa", "123456Anaaaa")]
        public void RegistrationSucces(string mail, string pass, string pass2)
        {
            LoginPage.Open();
            LoginPage.ClickRegistreted();
            Assert.IsTrue(RegisterPage.IsPageOpen());
            RegisterPage.SendEmail(mail);
            RegisterPage.SendPassword(pass);
            RegisterPage.SendPasswordDouble(pass2);
            RegisterPage.ClickTerm();
            RegisterPage.ClickTermSecond();
            RegisterPage.ClickButtonOk();
            Assert.That(RegisterPage.GetRegisteredMessage(), Is.EqualTo("User registered"));
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Некорректная регистрация на сайте.")]
        [TestCase("a@l.a", "123456Anaaaa", "123456Anaaaa")]
        public void RegistrationUnSucces(string mail, string pass, string pass2)
        {
            LoginPage.Open();
            LoginPage.ClickRegistreted();
            Assert.IsTrue(RegisterPage.IsPageOpen());
            RegisterPage.SendEmail(mail);
            RegisterPage.SendPassword(pass);
            RegisterPage.SendPasswordDouble(pass2);
            RegisterPage.ClickTerm();
            RegisterPage.ClickTermSecond();
            RegisterPage.ClickButtonOk();
            Assert.That(RegisterPage.GetMessage(), Is.EqualTo("Registration not successful"));
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Переход на страницу Term of Use.")]
        [Test]
        public void ClickTermOfUse()
        {
            LoginPage.Open();
            LoginPage.ClickRegistreted();
            Assert.IsTrue(RegisterPage.IsPageOpen());
            RegisterPage.OpenTermOfUse();
            Assert.That(RegisterPage.TermOfUse(), Is.EqualTo("Terms of use"));
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Переход на страницу Privacy policy.")]
        [Test]
        public void ClickPrivacyPolicy()
        {
            LoginPage.Open();
            LoginPage.ClickRegistreted();
            Assert.IsTrue(RegisterPage.IsPageOpen());
            RegisterPage.OpenPrivacyPolicy();
            Assert.That(RegisterPage.PrivacyPolicy(), Is.EqualTo("Privacy policy"));
        }
    }
}

