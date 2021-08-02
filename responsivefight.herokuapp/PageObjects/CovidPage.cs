// This page contains the propertied & methods of the News Page

using OpenQA.Selenium;
using responsivefight.Helpers;

namespace responsivefight.PageObjects
{
    public class CovidPage
    {
        /// <summary>
        /// Get AreyouGame link web element
        /// </summary>
        public IWebElement AreYouGameLnk
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.newsId);
            }
        }

        /// <summary>
        /// Get GoToOfficeLnk link web element
        /// </summary>
        public IWebElement GoToOfficeLnk
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.officeId);
            }
        }

        /// <summary>
        /// Get TakeBusLnk link web element
        /// </summary>
        public IWebElement TakeBusLnk
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.busId);
            }
        }

        /// <summary>
        /// Get PublicPlaceLnk link web element
        /// </summary>
        public IWebElement PublicPlaceLnk
        {
            get
            {
                return Utilities.GetWebElement("id", Helpers.Identifiers.restuarantId);
            }
        }

        /// <summary>
        /// This method will check the four options
        /// </summary>
        /// <returns>Returns true if exists else false</returns>
       public bool CheckAllBattlesExistence()
        {
            if ((AreYouGameLnk != null) && (GoToOfficeLnk != null) && (TakeBusLnk != null) && (AreYouGameLnk != null))

                return true;
            else
                return false;

        }
    }
}
