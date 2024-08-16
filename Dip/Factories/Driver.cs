using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
namespace Dip.Factories
{
    internal class Driver
    {
        public static IWebDriver? _driver;
        public static WebDriverWait? _wait;

        public static IWebDriver GetDriver() => _driver ??= SetupDriver();

        public static WebDriverWait GetWait(IWebDriver driver, double waitTime = 30) => _wait ??= new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));

        public static void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
             _wait = null;
        }
        private static IWebDriver SetupDriver() => _driver ??= new ChromeDriver();
        public static void Open()
        {
            _driver.Navigate().GoToUrl("");
        }
    }
}
