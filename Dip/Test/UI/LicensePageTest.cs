using Dip.Page;

namespace Dip.Test.UI
{
    internal class LicensePageTest:BasePageTest
    {
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PaymentPayPalMethodSubscription(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            Assert.That(LicensePage.PayPalPayment(), Is.EqualTo("www.paypal.com"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PaymentDebetCardMethodSubscription(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            Assert.That(LicensePage.DebetCardPayment(), Is.EqualTo("www.paypal.com"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PaymentPayPalMethodOneOffPayment(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            LicensePage.ClickOneOffPay();
            Assert.That(LicensePage.PayPalPayment(), Is.EqualTo("www.paypal.com"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void PaymenDebetCardMethodOneOffPayment(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            LicensePage.ClickOneOffPay();
            Assert.That(LicensePage.DebetCardPayment(), Is.EqualTo("www.paypal.com"));

        }

    }
}
