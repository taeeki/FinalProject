using Dip.Page;

namespace Dip.Test.UI
{
    internal class TagPageTest:BasePageTest
    {
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "English")]
        public void DeleteTags(string name, string pass,string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            LoginPage.Open();
            LoginPage.Login(name, pass);

            DiaryPage.ClickToGoManageTags();
            Assert.IsTrue(TagsPage.IsOpen());
            TagsPage.DeleteTags("tags");
        }

        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void CountTags(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickToGoManageTags();
            Assert.IsTrue(TagsPage.IsOpen());
            Assert.That(TagsPage.CountingTags(), Is.EqualTo(10));
        }

    }
}
