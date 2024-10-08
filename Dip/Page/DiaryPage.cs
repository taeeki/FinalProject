﻿using Dip.Factories;
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
            try
            {
                IWebElement button = Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(buttonLogoutXPAth)));
                button.Click();
            }
            catch (StaleElementReferenceException ex)
            {
                IWebElement button = Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(buttonLogoutXPAth)));
                button.Click();
            }
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
   
        public static void ResetDateSearch()=>
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id=\"reset-search\"]"))).Click();

        public static bool EnabledDeleteButton()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class=\"btn btn-default icon-btn\" and @title=\"Delete selected entries\"]"))).Enabled;
        }
        public static void ClickDeleteAllNotes()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class=\"btn btn-default icon-btn\" and @title=\"Delete selected entries\"]"))).Click();
            Thread.Sleep(2000);
            IAlert alert = Driver.GetDriver().SwitchTo().Alert();
            Assert.AreEqual("Do you really want to delete the selected entries?", alert.Text);
            alert.Accept();
        }
        public static void CLickChecbox()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class=\"ng-pristine ng-valid\" and @title =\"Select all\"]"))).Click();
        }
        public static bool EnabledPrinter() => 
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(" //a[@class=\"btn btn-default icon-btn\" and @title=\"Print selected entries\"]"))).Enabled;
        public static string PrinterAllNotes()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(" //a[@class=\"btn btn-default icon-btn\" and @title=\"Print selected entries\"]"))).Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            return (string)Driver.GetDriver().Url;
        }
        public static string PrinterOneNotes()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class=\"checkbox-wrapper\"]//input[@type=\"checkbox\"]"))).Click();
            Thread.Sleep(1000);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class=\"btn btn-default icon-btn\" and @title=\"Print selected entries\"]"))).Click();
            Driver.GetDriver().SwitchTo().Window(Driver.GetDriver().WindowHandles.Last());
            return (string)Driver.GetDriver().Url;
        }


    }
}
