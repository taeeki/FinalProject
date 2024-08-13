using Dip.Factories;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
namespace Dip.Page
{
    internal class LoginPage:BasePage
    {
        private static string errorMessageXPath = "//div[@class = 'alert alert-danger']";
        private static string mandatoryLoginTextXPath = "//div[contains(text(), 'Mandatory field')]";
        private static string mandatoryPassTextXPath = "//div[contains(text(), 'Mandatory field')]";
        private static string clickRegisterXPath = "//a[@href=\"/account/registration\"]";
        public LoginPage(IWebDriver driver):base(driver) { }
        public static void Open()
        {
            Driver.GetDriver().Navigate().GoToUrl(base_url + "app/#");
        }
        public static bool IsPageOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//form//button[@type='submit']"))).Displayed;
        }
        public static void ClickRegistreted() 
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(clickRegisterXPath))).Click();

        }
        public static void Login(string user, string password)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"login\"]"))).SendKeys(user);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"password\"]"))).SendKeys(password);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//form//button[@type='submit']"))).Click();
        }
        public static string GetErrorMessage() => Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(errorMessageXPath))).Text;
        public static string GetMandatoryErrorLogin() => Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(mandatoryLoginTextXPath))).Text;
        public static string GetMandatoryErrorPassword() => Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(mandatoryPassTextXPath))).Text;
      

    }
}
