using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [AllureNUnit] 
    internal class DiaryPageTest : BasePageTest
    {
        [AllureName("Выход из аккаунта.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void ClickLogOut(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            DiaryPage.Open();
            DiaryPage.ClickLogOutButton();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
        [AllureName("Переход в настройки.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void ClickSetting(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            DiaryPage.Open();
            DiaryPage.ClickSettingButton();
            Assert.IsTrue(SettingPage.IsPageOpen());
        }
        [AllureName("Поиск информации по сайту с заданным критерием.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "utyryr")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "World")]
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
        [AllureName("Настройки тегов в дневнике.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void GoToPageTags(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
            DiaryPage.ClickToGoManageTags();
            Assert.IsTrue(TagsPage.IsOpen());
        }
    }
}
