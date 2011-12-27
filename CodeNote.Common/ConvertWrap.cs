using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Common
{
    /// <summary>
    /// 数据格式转换类
    /// </summary>
    public class ConvertWrap
    {
        #region toint
        public static int ToInt(object obj)
        {
            return ToInt(obj, 0);
        }
        public static int ToInt(object obj, int def)
        {
            int temp = 0;
            try { temp = Convert.ToInt32(obj); }
            catch { temp = def; }
            return temp;
        }
        #endregion

        #region ToDateStr
        public static string ToDateStr(DateTime? date)
        {
            try
            {
                if (date != null)
                {
                    DateTime newDa = (DateTime)date;
                    return newDa.ToString("yyyy-MM-dd HH:mm");
                }
                return "00-00-00 00:00";
            }
            catch { return "00-00-00 00:00"; }
        }
        public static string ToDateStr(DateTime? date, bool isChain)
        {
            try
            {
                if (date != null)
                {
                    DateTime newDa = (DateTime)date;
                    if (isChain)
                        return newDa.ToString("yyyy年MM月dd日 HH:mm");
                    else
                        return newDa.ToString("yyyy/MM/dd HH:mm");

                }
                return "00/00/00 00:00";
            }
            catch { return "00/00/00 00:00"; }
        }
        public static DateTime ToDate(DateTime? date)
        {
            if (date == null)
            {
                return DateTime.Now;
            }
            return Convert.ToDateTime(date);
        }
        public static DateTime ToDate(string dateStr)
        {
            if (string.IsNullOrEmpty(dateStr))
            {
                return DateTime.Now;
            }
            try
            {
                return Convert.ToDateTime(dateStr);
            }
            catch
            {
                return DateTime.Now;
            }
        }
        #endregion

        public static decimal ToDecimal(object obj, decimal def)
        {
            decimal temp = 0;
            try { temp = Convert.ToDecimal(obj); }
            catch { temp = def; }
            return temp;
        }

        public static string ToPrice(object value, int precision, bool isMark, object def)
        {
            return ToPrice(ToDecimal(value, ToDecimal(def, 0)), precision, isMark, ToDecimal(def, 0));
        }

        public static string ToPrice(decimal value)
        {
            return ToPrice(value, 2, true, 0);
        }

        public static string ToPrice(decimal value, bool isMark)
        {
            return ToPrice(value, 2, isMark, 0);
        }

        public static string ToPrice(decimal value, int precision, bool isMark, decimal def)
        {
            string temp = string.Empty;
            try
            {
                System.Globalization.NumberFormatInfo format = new System.Globalization.NumberFormatInfo();
                format.CurrencyDecimalDigits = precision;//设置小数位数
                format.CurrencyDecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                format.CurrencyGroupSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator;
                format.CurrencyGroupSizes = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSizes;
                if (isMark)
                {
                    format.CurrencySymbol = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                }
                else
                {
                    format.CurrencySymbol = "";//不显示符号
                }
                temp = value.ToString("C", format);
            }
            catch { temp = def.ToString(); }
            return temp;
        }
    }
}
