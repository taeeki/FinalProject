using Dip.Factories;
using OpenQA.Selenium;
namespace Dip.Page
{
    public abstract class BasePage
    {
        public const string base_url = "https://monkkee.com/";
        protected IWebDriver _driver;
       // protected WebDriverWait _wait;

        public static void OpenPage()
        {
            Driver.GetDriver().Navigate().GoToUrl(base_url + "/en");
            Driver.GetDriver().Manage().Window.Maximize();
        }
        public BasePage(IWebDriver driver) 
        { 
            this._driver = driver;
        }
    }
}
