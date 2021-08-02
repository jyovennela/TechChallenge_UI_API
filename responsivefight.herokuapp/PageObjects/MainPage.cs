// This page contains the propertied & methods of the Main Page

using OpenQA.Selenium;
using responsivefight.Helpers;
using System.Threading;

namespace responsivefight.PageObjects
{
    public class MainPage
    {
        /// <summary>
        /// Get UserName web element
        /// </summary>
        public IWebElement UserName
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.userNameId);
            }
        }

        /// <summary>
        /// Get CreateWarriorBtn button web element
        /// </summary>
        public IWebElement CreateWarriorBtn
        {
            get
            {

                return Utilities.GetWebElement("id", Helpers.Identifiers.createWarriorBtnid);

            }
        }

        /// <summary>
        /// Get StartYourJiourneyLink button web element
        /// </summary>
        public IWebElement StartYourJiourneyLink
        {
            get
            {

                return Utilities.GetWebElement("id", Helpers.Identifiers.startJourneyId);

            }
        }

        /// <summary>
        /// This method is to launch the page
        /// </summary>
        public void LauchPage()
        {
            Utilities.CreateInstance();
            Utilities.Driver.Navigate().GoToUrl("https://responsivefight.herokuapp.com/");
            Thread.Sleep(7000);

         }

        /// <summary>
        /// This method is to created warrior
        /// </summary>
        /// <param name="name"></param>
        public void CreateWarrior(string name)
        {
            UserName.SendKeys(name);
                        
        }

        /// <summary>
        /// This method is to click
        /// </summary>
        public void ClickCreateWarrior()
        {
            CreateWarriorBtn.Click();
            Thread.Sleep(3000);
        }

        /// <summary>
        /// This method is to verify the journey text
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool VerifyJourneyText(string name)
        {
            return StartYourJiourneyLink.Text.Contains(name);
        
        }

        public void CloseBrowser()
        {
            if (Utilities.Driver !=null)
           Utilities.Driver.Quit();
        }
    }
}
