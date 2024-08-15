using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class MainPageTest : BasePageTest
    {
        [AllureOwner("Терентьева Анна")]
        [AllureName("Переход на страницу авторизации.")]
        [Test]
        public void ClickLogIn()
        {
            MainPage.OpenPage();
            MainPage.ClickToLogin();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Проверка перехода на страницу с покупкой лицензии.")]
        [Test]
        public void ClickLicense()
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
        [AllureOwner("Терентьева Анна")]
        [AllureName("Переход на страницу регистрации на сайте.")]
        [Test]
        public void ClickRegister()
        {
            MainPage.OpenPage();
            MainPage.ClickToRegistred();
            Assert.IsTrue(RegisterPage.IsPageOpen());
        }
    }
}