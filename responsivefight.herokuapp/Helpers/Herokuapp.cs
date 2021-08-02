using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using responsivefight.PageObjects;

namespace responsivefight.Helpers
{
    public static class Herokuapp
    {
        /// <summary>
        /// Get MainPage object instantiation
        /// </summary>
        public static MainPage MainPageObject
        {
            get { return new MainPage(); }
        }

        /// <summary>
        /// Get OfficePage object instantiation
        /// </summary>
        public static OfficePage OfficePageObject
        {
            get { return new OfficePage(); }
        }

        /// <summary>
        /// Get BusPage object instantiation
        /// </summary>
        public static BusPage BusPageObject
        {
            get { return new BusPage(); }
        }

        /// <summary>
        /// Get CovidPage object instantiation
        /// </summary>
        public static CovidPage CovidPageObject
        {
            get { return new CovidPage(); }
        }

        /// <summary>
        /// Get LeaderBoardPage object instantiation
        /// </summary>
        public static LeaderBoardPage LeaderBoardPageObject
        {
            get { return new LeaderBoardPage(); }
        }

        /// <summary>
        /// Get RestaurantPage object instantiation
        /// </summary>
        public static RestaurantPage RestaurantPageObject
        {
            get { return new RestaurantPage(); }
        }

        /// <summary>
        /// Get NewsPage object instantiation
        /// </summary>
        public static NewsPage NewsPageObject
        {
            get { return new NewsPage(); }
        }
    }
}
