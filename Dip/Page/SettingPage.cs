using Dip.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Dip.Page
{
    internal class SettingPage : DiaryPage
    {
        //language
        private static string switchLanguageXPAth = "//li[@class=\"active\"]//a[@href=\"#/settings/locale\"]";
        private static string selectLangXPath = "//select[@name=\"selectLocale\"]";
        private static string messageXPath = "//div[@class=\"alert alert-success\"]";
        private static string clickOKXPath = "//button[@class=\"btn btn-default\"]";
        //emails
        private static string switchemailXPAth = "//a[@href=\"#/settings/email\"]";
        private static string errorMessageXPAth = "//div[@class=\"help-block ng-binding\"]";
        private static string emailsXPAth = "//*[@id=\"email\"]";
        private static string messageSuccessPAth = "//div[@class=\"alert alert-success\"]";  

        private static string backXpath = "//*[@id=\"back-to-overview\"]";

        private static string switchPasswordXPAth = "//li[@class=\"active\"]//a[@href=\"#/settings/locale\"]";

        //loginalias
        private static string switchLoginAliasXPAth = "//a[@href = \"#/settings/login\"]";
        private static string chechLoginAliasXPath = "//*[@id=\"use-alias\"]";
        private static string LoginAliasXPath = "//*[@id=\"alias\"]";

        private static string switchEditorXPAth = "//li[@class=\"active\"]//a[@href=\"#/settings/locale\"]";
        private static string switchExportXPAth = "//li[@class=\"active\"]//a[@href=\"#/settings/locale\"]";
        private static string switchLicenseXPAth = "//li[@class=\"active\"]//a[@href=\"#/settings/locale\"]";

        public SettingPage(IWebDriver driver) : base(driver) { }
        public static bool IsPageOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"settings-content\"]"))).Displayed;
        }

        public static void EditLanguage(string lang)
        {
            IWebElement element_name = Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(selectLangXPath)));

            SelectElement Language = new SelectElement(element_name);
            Language.SelectByText(lang);
        }
        public static void ClickOk()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(clickOKXPath))).Click();
        }
        public static string MessageLanguage(string text)
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(messageXPath))).Text;
        }
        public static void ClickEmail()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(switchemailXPAth))).Click();
        }
        public static void ChangeEmail(string email)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(emailsXPAth))).Clear();
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(emailsXPAth))).SendKeys(email);
        }
        public static string GetEmailValue()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(emailsXPAth))).Text;
        }
        public static string GetErrorMessageSuccess()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(messageSuccessPAth))).Text;
        }
        public static string isGetErrorInvalidEmails()
        {
            Thread.Sleep(3000);
            if (Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(errorMessageXPAth))).Displayed)
                return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(errorMessageXPAth))).Text;
            else return "Undisplayed";
        }
        public static string GetMandatoryError()
        {
            Thread.Sleep(3000);
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(errorMessageXPAth))).Text;
        }

        public static void ClickLogin()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(switchLoginAliasXPAth))).Click();
        }
        public static void ClickUsedAlias()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(chechLoginAliasXPath))).Click();
        }
        public static bool UsedLoginAlias()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginAliasXPath))).Enabled;

        }
        public static void InsertLoginValue(string alias)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(LoginAliasXPath))).SendKeys(alias);
        }
        public static string ALiasMessage()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class=\"alert alert-danger\"]"))).Text;

        }
        public static void BackHome() =>
        Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(backXpath))).Click();
    }

}
