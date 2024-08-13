using Dip.Factories;
using Microsoft.Graph.Models;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
namespace Dip.Page
{
    internal class MainPage:BasePage
    {
        public MainPage(IWebDriver driver) : base(driver) { }
        private static IWebElement about = Driver.GetDriver().FindElement(By.XPath("//a[@href = \"/en#about\"]"));
        private static IWebElement features = Driver.GetDriver().FindElement(By.XPath("//a[@href = \"/en#features\"]"));
        private static IWebElement security = Driver.GetDriver().FindElement(By.XPath("//a[@href = \"/en#security\"]"));
        private static IWebElement prices = Driver.GetDriver().FindElement(By.XPath("//a[@href = \"/en#prices\"]"));
        private static string RegistrButtonClickXPath = "//a[@class=\"btn btn-primary home__register-btn\"]";
        private static string LoginClickXPath = "//a[@class=\"btn btn-primary\" and @href=\"/app/\"]";
        private static string LicenseClickXPath = "//a[@class=\"btn btn-primary home__bye-license-btn\" and @href=\"/app/#/settings/license\"]";
        public static bool AboutIsDisplayed()
        {
            return about.Displayed;
        }
        public static bool FeaturesIsDisplayed()
        {
            return features.Displayed;
        }
        public static bool SecurityIsDisplayed()
        {
            return security.Displayed;
        }
        public static bool PriceIsDisplayed()
        {
            return prices.Displayed;
        }
        public static void ClickToRegistred()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(RegistrButtonClickXPath))).Click();
        }
        public static void ClickToLogin()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginClickXPath))).Click();
        }
        public static void ClickByLicense()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(LicenseClickXPath))).Click();
        }

    }
}
