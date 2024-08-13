
using Dip.Page;

namespace Dip.Test.UI
{
    internal class SettingPageTest : BasePageTest
    {
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "Deutsch")]

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
        public void SwitchLanguageEn(string name, string pass, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "terenteva1999@yandex.ru", "English")]
        public void EmailChangedThisEmails(string name, string pass, string email, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
            SettingPage.ClickEmail();
            SettingPage.ChangeEmail(email);
            SettingPage.ClickOk();
            Assert.That(SettingPage.isGetErrorInvalidEmails(), Is.EqualTo("The new email address is identical to the old one"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "sopovaanya@icloud.com", "English")]
        public void EmailChangedNewEmails(string name, string pass, string email, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
            SettingPage.ClickEmail();
            SettingPage.ChangeEmail(email);
            SettingPage.ClickOk();
            Assert.That(SettingPage.GetErrorMessageSuccess(), Is.EqualTo("Email changed. You will receive an email with a confirmation link. Please follow the instructions in this email. Please also check your Spam folder!"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "t@icloud", "English")]
        public void EmailInvalidChange(string name, string pass, string email, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
            SettingPage.ClickEmail();
            SettingPage.ChangeEmail(email);
            SettingPage.ClickOk();
            Assert.That(SettingPage.isGetErrorInvalidEmails(), Is.EqualTo("Not a valid email address"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "tff", "English")]
        public void EmailUncorrectDataWithoutSobak(string name, string pass, string email, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
            SettingPage.ClickEmail();
            SettingPage.ChangeEmail(email);
            SettingPage.ClickOk();
            Assert.That(SettingPage.GetMandatoryError(), Is.EqualTo("Not a valid email address"));
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "taeeeki", "English")]

        public void LoginALiasIsTrue(string name, string pass, string login, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
            SettingPage.ClickLogin();
            SettingPage.ClickUsedAlias();
            Assert.IsTrue(SettingPage.UsedLoginAlias());
            SettingPage.InsertLoginValue(login);
            SettingPage.ClickOk();
            Assert.That(SettingPage.GetErrorMessageSuccess(), Is.EqualTo("Your settings have been saved successfully"));
        } 
    
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "taeeeki", "English")]
        public void LoginALiasIsFalse(string name, string pass, string login, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();        
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
            SettingPage.ClickLogin();
            SettingPage.ClickUsedAlias();
            Assert.IsTrue(!SettingPage.UsedLoginAlias());
            SettingPage.ClickOk();
            Assert.That(SettingPage.GetErrorMessageSuccess(), Is.EqualTo("Your settings have been saved successfully"));
        }

        [TestCase("terenteva1999@yandex.ru", "123456Ana", "", "English")]
        public void LoginAliasLessFourSymbol(string name, string pass, string login, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickSettingButton();
            SettingPage.EditLanguage(language);
            SettingPage.ClickOk();
            Assert.That(SettingPage.MessageLanguage(language), Is.EqualTo("Your language has been changed successfully"));
            SettingPage.ClickLogin();
            SettingPage.ClickUsedAlias();
            Assert.IsTrue(SettingPage.UsedLoginAlias());
            SettingPage.InsertLoginValue(login);
            SettingPage.ClickOk();
            Assert.That(SettingPage.ALiasMessage(), Is.EqualTo("The alias must have at least 4 characters."));
        }
    }
}
