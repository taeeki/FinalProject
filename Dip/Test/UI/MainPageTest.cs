using Dip.Page;

namespace Dip.Test.UI
{
    internal class MainPageTest : BasePageTest
    {
        [Test]
        public void CheckedMainMenu()
        {
            BasePage.OpenPage();
            Assert.IsTrue(MainPage.AboutIsDisplayed());
            Assert.IsTrue(MainPage.PriceIsDisplayed());
            Assert.IsTrue(MainPage.FeaturesIsDisplayed());
            Assert.IsTrue(MainPage.SecurityIsDisplayed());
        }
        [Test]
        public void ClickLogIn()
        {
            MainPage.OpenPage();
            MainPage.ClickToLogin();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
        [Test]
        public void ClickLicense()
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            Assert.IsTrue(LoginPage.IsPageOpen());

        }
        [Test]
        public void ClickRegister()
        {
            MainPage.OpenPage();
            MainPage.ClickToRegistred();
            Assert.IsTrue(RegisterPage.IsPageOpen());

        }

    }
}