using Dip.Factories;
using Microsoft.Graph.Models;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace Dip.Page
{
    internal class LicensePage : BasePage
    {
        private static string title = "//h1[contains(text(), \"License\")]";
        private static string SubscriptionButtonXPath = "//button[@class=\"btn btn-primary license__btn\"]";
        private static string OneOffPaymentButtonXPath = "//button[@class=\"btn btn-default license__btn\"]";
        private static string PayPalButtonXPath = "//div[@role=\"link\" and @aria-label=\"PayPal\"]";
        private static string DebetCardButtonXPath = "//div[@role=\"link\"and @aria-label=\"Дебетовая или кредитная карта\"]";

        public LicensePage(WebDriver driver) : base(driver) { }
        public static bool IsPageOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(title))).Displayed;
        }
        public static string PayPalPayment()
        {
            Driver.GetDriver().SwitchTo().Frame(Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//iframe[@class=\"component-frame visible\"]"))));
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(PayPalButtonXPath))).Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            Thread.Sleep(5000);
            string url = new Uri(Driver.GetDriver().Url).Host;
            Driver.GetDriver().SwitchTo().DefaultContent();
            return url;
        }
        public static string DebetCardPayment()
        {
            Driver.GetDriver().SwitchTo().Frame(Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//iframe[@class=\"component-frame visible\"]"))));
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(DebetCardButtonXPath))).Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            Thread.Sleep(5000);
            string url = new Uri(Driver.GetDriver().Url).Host;
            return url;
        }
        public static void ClickOneOffPay()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(OneOffPaymentButtonXPath))).Click();
        }
    }
}