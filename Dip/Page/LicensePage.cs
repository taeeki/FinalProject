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
        private static string OneOffPaymentButtonXPath = "//button[@ng-click=\"selectPaymentType('once')\"]";
        private static string PayPalButtonXPath = "//div[@role=\"link\" and @aria-label=\"PayPal\"]";
        private static string DebetCardButtonXPath = "//div[@role=\"link\"and @aria-label=\"Дебетовая или кредитная карта\"]";
        private static string iframe = "//div[@ng-show=\"'once' == paymentType\"]//iframe";
        private static string iframe2 = "//div[@ng-show=\"'regularly' == paymentType\"]//iframe";
     
        public LicensePage(WebDriver driver) : base(driver) { }
        public static bool IsPageOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(title))).Displayed;
        }
        public static string PayPalPaymentSub()
        {
            Driver.GetDriver().SwitchTo().Frame(Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(iframe2))));
            Thread.Sleep(1000);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(PayPalButtonXPath))).Click();
            Thread.Sleep(1000);
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            Thread.Sleep(5000);
            string url = new Uri(Driver.GetDriver().Url).Host;
            return url;
        }
        public static string DebetCardPaymentSub()
        {
            Thread.Sleep(1000);
            Driver.GetDriver().SwitchTo().Frame(Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(iframe2))));
            Thread.Sleep(1000);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(DebetCardButtonXPath))).Click();
            Thread.Sleep(1000);
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            Thread.Sleep(5000);
            string url = new Uri(Driver.GetDriver().Url).Host;
            return url;
        }
        public static string PayPalPaymentOneOff()
        {
            Thread.Sleep(1000);
            Driver.GetDriver().SwitchTo().Frame(Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(iframe))));
            Thread.Sleep(1000);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(PayPalButtonXPath))).Click();
            Thread.Sleep(1000);
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            Thread.Sleep(10000);
            string url = new Uri(Driver.GetDriver().Url).Host;
            return url;
        }
        public static string DebetCardPaymentOneOff()
        {
            Thread.Sleep(1000);
            Driver.GetDriver().SwitchTo().Frame(Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(iframe)))); 
            Thread.Sleep(1000);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(DebetCardButtonXPath))).Click();
            Thread.Sleep(1000);
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            Thread.Sleep(10000);
            string url = new Uri(Driver.GetDriver().Url).Host;
            return url;
        }
        public static void ClickOneOffPay()
        {
            
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(OneOffPaymentButtonXPath))).Click();
        }
    }
}