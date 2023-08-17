using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Musala.BDD.Tests.Utilities
{
    public class DateUtil
    {
        public static string GetMonthName(int mm)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mm);
        }

        public static int GetMonthNumber(string mm)
        {
            return DateTime.ParseExact(mm, "MMMM", CultureInfo.CurrentCulture).Month;
        }
        /// <summary>
        /// this method for getting random dates
        /// </summary>
        /// <param name="dateFormat">the date formate to return</param>
        /// <param name="most">number of days after or beforetoday 
        /// to get random future daate paass positive value 
        /// to get random past date pass negative value</param>
        /// <returns>date in string format</returns>
        public static string GetRandomDate(string dateFormat, int most)
        {
            return DateTime.Now.AddDays(most).ToString(dateFormat);
        }

        public static string GetRandomDate(string dateFormat)
        {
            return GetRandomDate(dateFormat,0);
        }        
    }
}
