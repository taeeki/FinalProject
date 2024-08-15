using Dip.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Security.Cryptography;
namespace Dip.Page
{
    internal class EditPage:BasePage
    {
        private const string blockWriteXPath = "//*[@class=\"cke_top\"]";
        private const string textEditorXPath = "//*[@id=\"editable\"]";
        private const string backXpath = "//*[@id=\"back-to-overview\"]";
        private const string deleteButtonXPath = "//*[@id=\"delete-entry\"]";
        private const string findTabXPath = "//*[@id=\"appendedInputButton\"]";
        //поиск по дневнику
        private static string resultTextResearchXPath = "//*[@class='entry']/*[@class=' body' and contains(text(),'%s')]";
        //tags 
        private const string addNewTagsXPath = "//*[@id=\"new-tag\"]";
        private const string buttonNewTagXPath = "//*[@id=\"assign-new-tag\"]";
        private const string assigTagXPath = "//*[@class=\"assigned-tags clearfix\"]";
        //работа с редактором текста 
        private const string link_iconXPath = "//*[@id=\"cke_31\"]";
        private const string unlink_iconXPath = "//*[@id=\"cke_33\"]";
        private const string link_modalXPath = "//input[@class='cke_dialog_ui_input_text' and @id='cke_450_textInput']";
        private const string link_OKXPath = "//*[@id=\"cke_429_uiElement\"]";
        //
        private const string expandToolBarXPath  = "//*[@id=\"cke_1376\" and @title = \"Expand toolbar\"]";
        private const string reduceToolBarXPath  = "//*[@id=\"cke_1376\" and @title = \"Reduce toolbar\"]";
        //save
        private const string SaveXPath = "//a[@href=\"#\" and @class=\"cke_button cke_button__savetoggle cke_button_off cke_button_disabled\"]";
        //картинки
        private const string imageIconXPath = "//a[@title=\"Image\"]";
        private const string imageIconModalXPath = "//a[@title=\"OK\"]"; 
        private const string imageIconTextXPath = "//*[@id=\"cke_70_textInput\"]";
        private const string uploadImageXPath = "//input[@type=\"file\" and @name = \"txtUpload\"]";
        private const string modalWindowXPath = "//iframe[@class=\"cke_dialog_ui_input_file\"]";
        //calendar
        public EditPage(IWebDriver driver):base(driver) { }
        //проверка, что кнопка есть на странице
        public static bool IsPageOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(blockWriteXPath))).Displayed;
        }
        //редактирование записи
        public static void EditNotes(string note) => Driver.GetDriver().FindElement((By.XPath(textEditorXPath))).SendKeys(note);
        //возврат на страницу заметок
        public static void BackHome() => 
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(backXpath))).Click();
        //удалить запись
        public static void DeleteNotes()
        {
            Driver.GetDriver().FindElement(By.XPath(deleteButtonXPath)).Click();

            IAlert alert = Driver.GetDriver().SwitchTo().Alert();
            Assert.AreEqual("Do you really want to delete the entry?", alert.Text);
            alert.Accept();
        }  
        //добавление новой строки
        public static void AddNewLine() =>  
            Driver.GetDriver().FindElement(By.XPath(textEditorXPath)).SendKeys(Keys.Enter);
        public static void AddTag(string tagName)
        {
            Driver.GetDriver().FindElement(By.XPath(addNewTagsXPath)).SendKeys(tagName);
            Driver.GetDriver().FindElement(By.XPath(buttonNewTagXPath)).Click();
        }
        //находим тег по имени
        public static void SelectByName(string tagName)
        { 
            new SelectElement(Driver.GetDriver().FindElement(By.XPath("//*[@id=\"select-tag\"]"))).SelectByText(tagName);
        }
        public static void ClickFindTag()=>
            Driver.GetDriver().FindElement(By.XPath("//*[@id=\"assign-existing-tag\"]")).Click();
        public static string AssignedTags()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(assigTagXPath))).Text;
        }
      //  Получение найденных записей
        public int GetSearchedEntries(string textToSearch)
        {
            By searchByTextResult = By.XPath(string.Format(resultTextResearchXPath, textToSearch));
            return Driver.GetDriver().FindElements(searchByTextResult).Count;
        }
        //если ничего не найдено, поиск сообщения

        //работа с текстом
        public static void GetPictureFileDesktop(string File)
        {
            string HashFile = Base64SHA256(File);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(imageIconXPath))).Click();
            Driver.GetDriver().SwitchTo().Frame(Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(modalWindowXPath))));
            if (Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(uploadImageXPath))).Displayed)
            {
                Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(uploadImageXPath))).SendKeys(File);
                Driver.GetDriver().SwitchTo().DefaultContent();
                Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(imageIconModalXPath))).Click();
            }
            else Console.WriteLine("4tto ne tak");
        }

        public static void GetPictureFileURL(string url)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(imageIconXPath))).Click();
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(imageIconTextXPath)))
                 .SendKeys(url);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(imageIconModalXPath))).Click();         
        }
        public static void Save()
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(SaveXPath))).Click(); 
        }
        public static void AddLink(string url)
        {
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementToBeClickable(By.XPath(link_iconXPath))).Click();
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(link_modalXPath))).SendKeys(url);
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementToBeClickable(By.XPath(link_OKXPath))).Click();
        }

       public static void Calendar()
        {

        }
        static string Base64SHA256(string filePath)
        {
            var hasher = SHA256.Create();
            byte[] hashValue;
            using (Stream s = File.OpenRead(filePath))
            {
                hashValue = hasher.ComputeHash(s);
            }
            return Convert.ToBase64String(hashValue);
        }


    }
}
