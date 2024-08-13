using Dip.Page;

namespace Dip.Test.UI
{
    internal class DiaryPageTest : BasePageTest
    {
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void ClickLogOut(string user, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(user, pass);
            DiaryPage.Open();
            DiaryPage.ClickLogOutButton();
            Assert.IsTrue(LoginPage.IsPageOpen());
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
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
        public void GoToPageTags(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
            DiaryPage.ClickToGoManageTags();
            Assert.IsTrue(TagsPage.IsOpen());
        }


        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void Checked(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());          
            Assert.IsTrue(DiaryPage.searchChecked());
        }
    }
}
