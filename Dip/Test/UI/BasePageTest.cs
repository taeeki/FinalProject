using Allure.NUnit;
using Dip.Factories;
using Dip.Page;
namespace Dip.Test.UI

{
    //    [NonParallelizable]
    [AllureNUnit]
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
