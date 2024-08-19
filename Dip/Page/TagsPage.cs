using OpenQA.Selenium;
using Dip.Factories;
using SeleniumExtras.WaitHelpers;

namespace Dip.Page
{
    internal class TagsPage: BasePage
    {
        private static string titleXPath = "//h1[contains(text(), 'Tags')]";
        private static string buttonDeleteTags = "//a[@ng-click = \"deleteTag(tag)\"]"; 
        private static string countTags = " //*[contains(@class,'tag')]"; 

        public TagsPage(IWebDriver driver):base(driver) { }
        public static bool IsOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(titleXPath))).Displayed;
        }
        public static void DeleteTags(string nameTage)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(buttonDeleteTags))).Click();
            IAlert alert = Driver.GetDriver().SwitchTo().Alert();
            alert.Accept();
        }

        public static int CountingTags()
        {        
            int recordsCount = Driver.GetDriver().FindElement(By.XPath(countTags)).FindElements(By.XPath(countTags)).Count;
            return recordsCount;
        }
        public static void EditTags(string nameTage)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(buttonDeleteTags))).Click();
           
        }
    }
}
