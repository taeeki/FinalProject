using Allure.Net.Commons;
using Reqnroll;
using Dip.Factories;
using Dip.Page;
namespace Dip.Test.UI

{
    //    [NonParallelizable]
    internal class BasePageTest
    {
        [SetUp]
        public void Setup()
        {
            BasePage.OpenPage();
        }
        [TearDown]
        public void TearDown() => Driver.QuitDriver();
    }
}
