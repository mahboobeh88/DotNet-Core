using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesterV01.Common
{
    public static  class DateUtilitis
    {
        public static DateTime ParseDate(string date)
        {
            var pc = new PersianCalendar();
            string[] arrDate = date.Split("/");

            return pc.ToDateTime(Int32.Parse(arrDate[0]), Int32.Parse(arrDate[1]),
               Int32.Parse(arrDate[2]), 0, 0, 0, 0);
        }

        public static bool ComparePersianDate(this string firstDate,  string secondDate)
        {
            var first = ParseDate(firstDate);
            var second = ParseDate(secondDate);
            return first <= second;
        }

        public static string? ToShamsi(this DateTime date)
        {
            
            var pc = new PersianCalendar();
            var year = pc.GetYear(date);
            var month = pc.GetMonth(date).ToString().PadLeft(2, '0');
            var day = pc.GetDayOfMonth(date).ToString().PadLeft(2, '0');

            return $"{year}/{month}/{day}";
        }
        public static DateTime? ToMiladi(this string date)
        {
            if (!date.Contains("/") || date.Length != 10 )
                return null;
            var year = Convert.ToInt32( date.Substring(0, 4));
            var month = Convert.ToInt32(date.Substring(5, 2));
            var day = Convert.ToInt32(date.Substring(8,2));
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime dt = new DateTime(year, month, day, pc);
            return dt;
        }
       
    }
}
