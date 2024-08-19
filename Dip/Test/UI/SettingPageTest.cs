using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class SettingPageTest : BasePageTest
    {
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "Deutsch")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Изменение языка дневника на датский язык.")]
        public void SwitchLanguageDe(string name, string pass, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Deine Spracheinstellung wurde erfolgreich geändert"));
        }
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "Français")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Изменение языка дневника на французский язык.")]
        public void SwitchLanguageFr(string name, string pass, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Modifications enregistrées"));
        }
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "Portuguese")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Изменение языка дневника на португальский язык.")]
        public void SwitchLanguagePt(string name, string pass, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Seu idioma foi alterado com sucesso"));
        }
    
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "English")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Изменение языка дневника на английский язык.")]
        public void xSwitchLanguageEn(string name, string pass, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
        }
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "terenteva1999@yandex.ru")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Изменение почтового адреса в дневнике на тот же, что используется и сейчас.")]
        public void EmailChangedThisEmails(string name, string pass, string email)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.ClickEmail();
            SettingPage.ChangeEmail(email);
            SettingPage.ClickOk();
            Assert.That(SettingPage.isGetErrorInvalidEmails(), Is.EqualTo("The new email address is identical to the old one"));
        }
     
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "sopovaanya@icloud.com")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Изменение почтового адреса в дневнике на новый email. Корректный кейс.")]
        public void EmailChangedNewEmails(string name, string pass, string email)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.ClickEmail();
            SettingPage.ChangeEmail(email);
            SettingPage.ClickOk();
            Assert.That(SettingPage.GetErrorMessageSuccess(), Is.EqualTo("Email changed. You will receive an email with a confirmation link. Please follow the instructions in this email. Please also check your Spam folder!"));
        }
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "t@icloud")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Изменение почтового адреса в дневнике на новый email. Некорректно заполнено поле email.")]
        public void EmailInvalidChange(string name, string pass, string email)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.ClickEmail();
            SettingPage.ChangeEmail(email);
            SettingPage.ClickOk();
            Assert.That(SettingPage.isGetErrorInvalidEmails(), Is.EqualTo("Not a valid email address"));
        }
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "taeeeki")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("Добавление логина к аккаунту и возможность входа по нему.")]

        public void LoginALiasIsTrue(string name, string pass, string login)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.ClickLogin();
            SettingPage.ClickUsedAlias();
            Assert.IsTrue(SettingPage.UsedLoginAlias());
            SettingPage.InsertLoginValue(login);
            SettingPage.ClickOk();
            Assert.That(SettingPage.GetErrorMessageSuccess(), Is.EqualTo("Your settings have been saved successfully"));
        }
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "taeeeki")]
        [AllureOwner("Терентьева Анна")]
        [AllureName("отключение входа по логину в аккаунт.")]
        public void LoginALiasIsFalse(string name, string pass, string login)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();        
            SettingPage.ClickLogin();
            SettingPage.ClickUsedAlias();
            Assert.IsTrue(!SettingPage.UsedLoginAlias());
            SettingPage.ClickOk();
            Assert.That(SettingPage.GetErrorMessageSuccess(), Is.EqualTo("Your settings have been saved successfully"));
        }
    }
}
