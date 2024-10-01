using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using static DAL.Contanst;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebApp.Exceptions;
using System.Text.RegularExpressions;

namespace DAL
{
    public class Helper
    {
        public static string FirtDayOfYear()
        {

            return string.Format("01/01/{0}", DateTime.Now.Year);
        }
        public static string FirtDayOfMonth()
        {
            int monthNow = DateTime.Now.Month;
            string month = monthNow.ToString().Length == 1 ? "0" + monthNow : monthNow.ToString();
            return string.Format("01/{0}/{1}", month, DateTime.Now.Year.ToString());
        }
        public static string _ChangeFormatDate(string oldformant)
        {
            if (!string.IsNullOrEmpty(oldformant) && oldformant.IndexOf("/") > 0)
            {
                string[] arr = oldformant.Split('/');
                string newformat = arr[2] + "-" + arr[1] + "-" + arr[0];
                return newformat;
            }
            else
            {
                return "";
            }

        }
        public static int CheckIntNull(object readerValue)
        {
            if ((readerValue == DBNull.Value) || (readerValue == null))
            {
                //return -1;
                return 0;
            }
            else
            {
                return Convert.ToInt32(readerValue);
            }
        }
        public static decimal CheckDecimalNull(object readerValue)
        {
            if ((readerValue == DBNull.Value) || (readerValue == null))
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(readerValue);
            }
        }
        /// <summary>
        /// Convert phone to VN (bắt đầu = 84)
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string ConvertPhoneToFormatVN(string phone)
        {
            Regex regex = new Regex(@"^(0[2|3|5|7|8|9])\d{8}$");
            
            if (regex.IsMatch(phone))
            {
                //chuyển sang đầu 84
                var phoneVN = $"84{phone.Substring(1)}";
                return phoneVN;
            }
            return phone;
        }

        public static string GenMaDon(Int64 orderId)
        {
            int standerLen = 7;
            int refixLength = orderId.ToString().Length;
            string temp = "";
            for (int i = refixLength; i < standerLen; i++)
            {
                temp = temp + "0";
            }
            string madon = temp + orderId.ToString();
            return madon;
        }



       



    }
}
