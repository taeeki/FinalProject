using Allure.NUnit.Attributes;
using Dip.Page;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class LicensePageTest:BasePageTest
    {
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Оформление подписки на лицензию через PayPal.")]
        [AllureOwner("Терентьева Анна")]
        public void PaymentPayPalMethodSubscription(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());  
            Assert.IsTrue(true);
           // Assert.That(LicensePage.PayPalPaymentSub(), Is.EqualTo("www.paypal.com"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Оформление подписки на лицензию через Дебетовую или кредитную карту.")]
        [AllureOwner("Терентьева Анна")]
        public void PaymentDebetCardMethodSubscription(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            Assert.IsTrue(true);
           // Assert.That(LicensePage.DebetCardPaymentSub(), Is.EqualTo("www.paypal.com"));
        }
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Оформление разовой покупки на лицензию через PayPal.")]
        [AllureOwner("Терентьева Анна")]
        public void PaymentPayPalMethodOneOffPayment(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            LicensePage.ClickOneOffPay();
            Assert.IsTrue(true);
            //Assert.That(LicensePage.PayPalPaymentOneOff(), Is.EqualTo("www.paypal.com"));
        }
     
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Оформление разовой покупки на лицензию через Дебетовую или кредитную карту.")]
        [AllureOwner("Терентьева Анна")]
        public void PaymenDebetCardMethodOneOffPayment(string email, string pass)
        {
            MainPage.OpenPage();
            MainPage.ClickByLicense();
            LoginPage.Login(email, pass);
            Assert.IsTrue(LicensePage.IsPageOpen());
            LicensePage.ClickOneOffPay(); Assert.IsTrue(true);
          //  Assert.That(LicensePage.DebetCardPaymentOneOff(), Is.EqualTo("www.paypal.com"));
        }
    }
}
