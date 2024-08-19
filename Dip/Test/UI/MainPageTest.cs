using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class MainPageTest : BasePageTest
    {
       
        [Test]
        [AllureName("Переход на страницу авторизации.")]
        [AllureOwner("Терентьева Анна")]
        public void ClickLogIn()
        {
            MainPage.OpenPage();
            MainPage.ClickToLogin();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
       
        [Test]
        [AllureName("Проверка перехода на страницу с покупкой лицензии.")]
        [AllureOwner("Терентьева Анна")]
        public void ClickLicense()
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
      
        [Test]
        [AllureName("Переход на страницу регистрации на сайте.")]
        [AllureOwner("Терентьева Анна")]
        public void ClickRegister()
        {
            MainPage.OpenPage();
            MainPage.ClickToRegistred();
            Assert.IsTrue(RegisterPage.IsPageOpen());
        }
    }
}