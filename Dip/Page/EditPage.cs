using Dip.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace Dip.Page
{
    internal class EditPage:BasePage
    {
        private const string blockWriteXPath = "//*[@class=\"cke_top\"]";
        private const string textEditorXPath = "//*[@id=\"editable\"]";
        private const string backXpath = "//*[@id=\"back-to-overview\"]";
        private const string deleteButtonXPath = "//*[@id=\"delete-entry\"]";
        //поиск по дневнику
        private static string resultTextResearchXPath = "//*[@class='entry']/*[@class=' body' and contains(text(),'%s')]";
        //tags 
        private const string addNewTagsXPath = "//*[@id=\"new-tag\"]";
        private const string buttonNewTagXPath = "//*[@id=\"assign-new-tag\"]";
        private const string assigTagXPath = "//*[@class=\"tag-wrapper ng-scope\"]";
        private const string SaveXPath = "//a[@href=\"#\" and @class=\"cke_button cke_button__savetoggle cke_button_off cke_button_disabled\"]";
        //картинки
        private const string imageIconXPath = "//a[@title=\"Image\"]";
        private const string imageIconModalXPath = "//a[@title=\"OK\"]"; 
        private const string imageIconTextXPath = "//*[@id=\"cke_70_textInput\"]";
        private const string uploadImageXPath = "//input[@type=\"file\" and @name = \"txtUpload\"]";
        private const string modalWindowXPath = "//iframe[@class=\"cke_dialog_ui_input_file\"]";
        //editsection
        private const string BoldtxtXPath= "//a[@title=\"Bold (Ctrl+B)\"]";
        private const string ItalictxtXPath= "//a[@title=\"Italic (Ctrl+I)\"]";
        private const string UnderlinetxtXPath= "//a[@title=\"Underline (Ctrl+U)\"]";
        private const string NumberedListtxtXPath= "//a[@title=\"Insert/Remove Numbered List\"]";
        
        public EditPage(IWebDriver driver):base(driver) { }
        //проверка, что кнопка есть на странице
        public static bool IsPageOpen()
        {
            return Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(blockWriteXPath))).Displayed;
        }
        //редактирование записи
        public static void EditNotes(string note) => 
            Driver.GetDriver().FindElement((By.XPath(textEditorXPath))).SendKeys(note);
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
        
        //работа с текстом
        public static void GetPictureFileDesktop(string File)
        {
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
        public static void Save()=>
          Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(SaveXPath))).Click();  
       public static void Calendar()
        {

        }
        public static void ClickBold()=>       
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(BoldtxtXPath))).Click();
        
        public static void ClickItalic()=>     
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(ItalictxtXPath))).Click();
        
        public static void ClickUnderline()=>
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(UnderlinetxtXPath))).Click();
        
        public static void ClickNumberList()=>        
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath(NumberedListtxtXPath))).Click();
        
        public static void ClickBulletList()=>
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@title=\"Insert/Remove Bulleted List\"]"))).Click();
        
        public static void ClickDecreaseList()=>        
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@title=\"Decrease Indent\"]"))).Click();
        
        public static void ClickInsertSpecialEmodji() =>
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@title=\"Insert Special Character\"]"))).Click();

        public static void InsertEmodji()=>
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@class=\"cke_dark_background cke_centered\"]"))).Click();

        public static void ExpandClick() =>
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@title=\"Expand toolbar\"]"))).Click();

        public static void SmileyOpen() =>
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@title = \"Smiley\"]"))).Click();

        public static void ExitEdit() => 
            Driver.GetWait(Driver.GetDriver()).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@title=\"Exit edit mode\"]"))).Click();
    }

}
