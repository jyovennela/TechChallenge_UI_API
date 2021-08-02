using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace responsivefight.Helpers
{
    public static class Utilities
    {
        static Utilities()
        {

            Driver = driver;

        }

        //public static bool IsApi
        //{
        //    get;
        //    set;
        //}
        private static IWebDriver driver
        {

            get
            {
                //configure path of msedgedriver.exe path

                // System.Environment.SetEnvironmentVariable("webdriver.edge.driver", @"D:\VisualStudio\SuperHerosApp\responsivefight.herokuapp\Drivers\MicrosoftWebDriver.exe");
                string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Drivers");
                //string path = path1 + "Reports\\index.html";
                return new EdgeDriver(path1);
                //return new EdgeDriver(@"D:\VisualStudio\SuperHerosApp\responsivefight.herokuapp\Drivers\");
            }

        }

        //public static bool isAPI;

        public static IWebDriver Driver;

        public static void CreateInstance()
        {

            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();

        }

        public static IWebElement GetWebElement(string locatorType, string locatorText)
        {
            //IWebElement webElement = null;
            try
            {
                switch (locatorType.ToUpper())
                {
                    case "ID":
                        return Driver.FindElement(By.Id(locatorText));
                    case "NAME":
                        return Driver.FindElement(By.Name(locatorText));
                    default: return Driver.FindElement(By.XPath(locatorText));

                }
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public static string TakeScreenshot()
        {
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string path = path1 + "Screenshot\\" + DateTime.Today.ToString("ddMMyyyymmss") + ".png";
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }







    }
}
