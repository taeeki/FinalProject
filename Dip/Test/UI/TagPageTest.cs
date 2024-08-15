using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class TagPageTest:BasePageTest
    {
        [AllureOwner("Терентьева Анна")]
        [AllureName("Переход на страницу Term of Use.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "English")]
        public void DeleteTags(string name, string pass, string language)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.ClickToGoManageTags();
            Assert.IsTrue(TagsPage.IsOpen());
            TagsPage.DeleteTags("tags");
        }
    }
}
