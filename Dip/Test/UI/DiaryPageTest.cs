using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [AllureNUnit] 
    internal class DiaryPageTest : BasePageTest
    {
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Выход из аккаунта.")]
        [AllureOwner("Терентьева Анна")]
        public void ClickLogOut(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            DiaryPage.Open();
            DiaryPage.ClickLogOutButton();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Переход в настройки.")]
        [AllureOwner("Терентьева Анна")]
        public void ClickSetting(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            DiaryPage.Open();
            DiaryPage.ClickSettingButton();
            Assert.IsTrue(SettingPage.IsPageOpen());
        }
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "utyryr")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "World")]
        [AllureName("Поиск информации по сайту с заданным критерием.")]
        [AllureOwner("Терентьева Анна")]
        public void SearchTextFromDiary(string name, string pass, string text)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
            DiaryPage.searchByText(text);
            if (DiaryPage.FindNoEntriesMessage())
                Assert.IsTrue(true, "Поиск произведен, по такому поиску нет записей.");
            else
                Assert.IsFalse(false, "Поиск произведен, по такому поиску есть записи.");
            DiaryPage.ResetSearch();
        }
   
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Настройки тегов в дневнике.")]
        [AllureOwner("Терентьева Анна")]
        public void GoToPageTags(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
            DiaryPage.ClickToGoManageTags();
            Assert.IsTrue(TagsPage.IsOpen());
        }
 
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Установка даты в дневнике.")]
        [AllureOwner("Терентьева Анна")]
        public void SetDate(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
            DiaryPage.CalendarClick();
            Assert.IsTrue(DiaryPage.IsPageOpen());
            //DiaryPage.SetDateValue("August 2024");
            //DiaryPage.ResetSearch();
            //Assert.IsTrue(DiaryPage.IsPageOpen());
        }
    }
}
