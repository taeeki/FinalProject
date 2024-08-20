using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    public class LicensePageTest : BasePageTest
    {
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Оформление подписки на лицензию через PayPal.")]
        [AllureOwner("Terentyeva Ann")]
        public void PaymentPayPalMethodSubscription(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            Assert.That(LicensePage.PayPalPaymentSub(), Is.EqualTo("www.paypal.com"));
        }

        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Оформление подписки на лицензию через Дебетовую или кредитную карту.")]
        [AllureOwner("Terentyeva Ann")]
        public void PaymentDebetCardMethodSubscription(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            Assert.That(LicensePage.DebetCardPaymentSub(), Is.EqualTo("www.paypal.com"));
        }

        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Оформление разовой покупки на лицензию через PayPal.")]
        [AllureOwner("Terentyeva Ann")]
        public void PaymentPayPalMethodOneOffPayment(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            LicensePage.ClickOneOffPay();
            Assert.That(LicensePage.PayPalPaymentOneOff(), Is.EqualTo("www.paypal.com"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Оформление разовой покупки на лицензию через Дебетовую или кредитную карту.")]
        [AllureOwner("Terentyeva Ann")]
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
