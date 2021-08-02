// This page contains the propertied & methods of the News Page

using OpenQA.Selenium;
using responsivefight.Helpers;
using System;
using System.Threading;

namespace responsivefight.PageObjects
{
    public class NewsPage
    {
        /// <summary>
        /// Get Start button web element
        /// </summary>
        public IWebElement StartBtn
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.startId);
            }
        }

        /// <summary>
        /// Get Correct Answer web element
        /// </summary>
        public IWebElement AnswerId
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.newsAnswer1Id);
                
            }
        }

        /// <summary>
        /// Get Wrong Answer web element
        /// </summary>
        public IWebElement WrongAnswerId
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.newsAnswer2Id);
                
            }
        }

        /// <summary>
        /// Get Continue Button Web element
        /// </summary>
        public IWebElement ContinueBtn
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.newsContinueBtnId);
            }
        }

        /// <summary>
        /// Get TryAgain button web element
        /// </summary>
        public IWebElement TryAgainBtn
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.tryAgainId);
            }
        }

        /// <summary>
        /// Method to take a battle
        /// </summary>
        /// <param name="IsSuccess">Default parameter</param>
        /// <returns>bool</returns>
        public int TakeBattle(bool IsSuccess = true)
        {
            int cnt = 0;
            try
            {
                
                    Thread.Sleep(3000);
                    StartBtn.Click();
                if (IsSuccess)
                {
                    Thread.Sleep(1000);
                    while (AnswerId != null)
                    {
                        Thread.Sleep(2000);
                        AnswerId.Click();

                        Thread.Sleep(2000);
                        ContinueBtn.Click();
                        cnt += 100;
                    }
                    return cnt;
                }
                else
                {
                    WrongAnswerId.Click();

                    Thread.Sleep(2000);
                    TryAgainBtn.Click();
                    return cnt;
                     }
            }
            catch(Exception ex)
            {
                return 0;
            }

        }

        /// <summary>
        /// Verify the Home Page
        /// </summary>
        /// <returns></returns>
        public bool VerifyHomePage()
        {
            if (Herokuapp.MainPageObject.CreateWarriorBtn != null)
                return true;
            else return false;

        }

    }
}
