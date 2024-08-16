using Dip.Factories;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Dip.Page
{
    internal class DiaryPage:BasePage
    {
        private static string buttonSettingXPath = "//a[@href = '#/settings/locale']";
        private static string buttonLogoutXPAth = "//button[@ng-click='logout($event)']";
        private static string buttonCreateNotes = "//*[@id=\"Icon_awesome-pen-nib\"]]";
        //notes
        private static string notesCreatedXPath = "//*[@id=\"create-entry\"]"; 
        private static string notesDeletedXPath = "//*[@id=\"delete-entries\"]";
        private static string printSelectedNotesXPath = "//a[@ng-click=\"printEntries()\"]";
        //поиск по дневнику
        private static string searchTextXPath = "//input[@type='search']";
        private static string buttonSearchTextXPath = "//*[@title = 'Search']";
        private static string resetSearchXPath = "//*[@id=\"reset-search\"]";
        private static string countEntires = "//div[@class=\"pagination__num-of-entries ng-binding\"]";
        private static string noEntriesFoundXPath = "//*[contains(text(),'No entries found')]";
        //Управление тэгами
        private static string goToManageTagsXPath = "//a[@href=\"#/tags\"]";
        private static string listNotesDataXPath = "//div[@class=\" body\" and @ng-bind-html=\"entry.body\"]";
        //календарь
        private const string calendarXPath = "//input[@id=\"datepicker\"]";


        public DiaryPage(IWebDriver driver):base(driver) { }

        public static bool IsPageOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(buttonLogoutXPAth))).Displayed;
        }
        public static void ClickLogOutButton()
        {
            IWebElement buton = Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(buttonLogoutXPAth)));
            buton.Click();
        }
        public static void Open()
        {
            Driver.GetDriver().Navigate().GoToUrl(base_url + "app/#/entries");
        }
        public static void ClickSettingButton()
        {
            IWebElement buton = Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(buttonSettingXPath)));
            buton.Click();
        }
        public static EditPage NewNotesFromDiaryClick()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(notesCreatedXPath))).Click();
            return new EditPage(Driver.GetDriver());
        }
        public static void OpenPage()
        {
            Driver.GetDriver().Navigate().GoToUrl(base_url + "app/#");
        }
        //поиск
        public static void searchByText(String textToSearch)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(searchTextXPath))).SendKeys(textToSearch);
            Driver.GetDriver().FindElement(By.XPath(buttonSearchTextXPath)).Click();
        }

       // очистка поиска
        public static void ResetSearch()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(resetSearchXPath)));
            Driver.GetDriver().FindElement(By.XPath(resetSearchXPath)).Click();
        }
        public static void ClickToGoManageTags()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(goToManageTagsXPath))).Click();
        }
        public static bool FindNoEntriesMessage()
        {
            string mess = Driver.GetDriver().FindElements(By.XPath(noEntriesFoundXPath)).ToString();
            if (mess == "No entries found")
                return true;
            else
                return false;
        }
      
       
        public static void CalendarClick()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(calendarXPath))).Click();
        }
        public static void SetDateValue()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(calendarXPath))).Click();
        }
    }
}
