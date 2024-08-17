using Allure.Commons;
using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class LicensePageTest:BasePageTest
    {
        [AllureName("Оформление подписки на лицензию через PayPal.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PaymentPayPalMethodSubscription(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            Assert.That(LicensePage.PayPalPaymentSub(), Is.EqualTo("www.paypal.com"));
        }
        [AllureName("Оформление подписки на лицензию через Дебетовую или кредитную карту.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PaymentDebetCardMethodSubscription(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            Assert.That(LicensePage.DebetCardPaymentSub(), Is.EqualTo("www.paypal.com"));
        }
        [AllureName("Оформление разовой покупки на лицензию через PayPal.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PaymentPayPalMethodOneOffPayment(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            LicensePage.ClickOneOffPay();
           Assert.That(LicensePage.PayPalPaymentOneOff(), Is.EqualTo("www.paypal.com"));
        }
        [AllureName("Оформление разовой покупки на лицензию через Дебетовую или кредитную карту.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PaymenDebetCardMethodOneOffPayment(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            LicensePage.ClickOneOffPay();
            Assert.That(LicensePage.DebetCardPaymentOneOff(), Is.EqualTo("www.paypal.com"));
        }
    }
}
