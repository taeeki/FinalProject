using Dip.Factories;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Dip.Page
{
    internal class RegisterPage:BasePage
    {
        private const string label = "//h1[contains(text(), 'Registration')]";
        private const string registerEmailXPath = "//*[@id=\"registration_email\"]";
        private const string registerPassXPath = "//*[@id=\"registration_password\"]";
        private const string registerPassDoubleXPath = "//*[@id=\"registration_password_confirmation\"]";
        private const string hindXpath = "//*[@id=\"registration_password_hint\"]";
        private const string PrivacyPolicyXPath = "//a[@href=\"/en/privacy-policy\" and @target=\"_blank\"]";
        private const string PrivacyPolicyTextXPath = "//h1[contains(text(), \"Privacy policy\")]";
        private const string TermsOfUseXPath = "//a[@href=\"/en/terms-of-use\" and @target=\"_blank\"]";
        private const string TermsOfUseTextXPath = "//h1[contains(text(), \"Terms of use\")]";
        private const string TermsOfUseCheckXPath = "//*[@id=\"registration_terms_of_use\"]";
        private const string AgreeSecondCheckXPath = "//*[@id=\"registration_lost_password_warning_registered\"]";
        private const string buttonRegisterXPath = "//button[@class=\"btn btn-primary\"]";
        private const string messageErrorXPath = "//div[@class=\"alert alert-danger\"]";
        private const string RegisterMessageXPath = "//h1[contains(text(), \"User registered\")]";
        public static void Open() {
            Driver.GetDriver().Navigate().GoToUrl("https://monkkee.com/account/registration");
        }
        public static bool IsPageOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(label))).Displayed;
        }

        public RegisterPage(WebDriver driver): base(driver) { }
        public static void SendEmail(string email)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(registerEmailXPath))).SendKeys(email);
        }
        public static void SendPassword(string email)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(registerPassXPath))).SendKeys(email);
        }
        public static void SendPasswordDouble(string email)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(registerPassDoubleXPath))).SendKeys(email);
        }
        public static void ClickTerm()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(TermsOfUseCheckXPath))).Click();
        }
        public static void ClickTermSecond()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(AgreeSecondCheckXPath))).Click();
        }
        public static void ClickButtonOk()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(buttonRegisterXPath))).Click();
        }
        public static string GetMessage()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(messageErrorXPath))).Text;
        }
        public static string GetRegisteredMessage()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(RegisterMessageXPath))).Text;
        }
        public static void OpenPrivacyPolicy() 
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(PrivacyPolicyXPath))).Click();
        }
        public static void OpenTermOfUse()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(TermsOfUseXPath))).Click();
        }
        public static string PrivacyPolicy()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://monkkee.com/en/privacy-policy");
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(PrivacyPolicyTextXPath))).Text;
        }
        public static string TermOfUse()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://monkkee.com/en/terms-of-use");
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(TermsOfUseTextXPath))).Text;
        }
    }
}
