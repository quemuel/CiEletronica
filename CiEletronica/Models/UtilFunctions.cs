using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiEletronica.Models
{
    public static class UtilFunctions
    {
        public static string GetPrettyBytes(long bytes)
        {
            if (bytes <= 1024f)
            {
                return bytes.ToString() + " Bytes";
            }
            else if (bytes > 1024f && bytes <= (1024f * 1024f))
            {
                var kilobytes = bytes / 1024f;
                return String.Format("{0:0.00}", kilobytes) + " KB";
            }
            else if (bytes > (1024f * 1024f) && bytes <= (1024f * 1024f * 1024f))
            {
                var megabytes = (bytes / 1024f) / 1024f;
                return String.Format("{0:0.00}", megabytes) + " MB";
            }
            else if (bytes > (1024f * 1024f * 1024f) && bytes <= (1024f * 1024f * 1024f * 1024f))
            {
                var gigabytes = ((bytes / 1024f) / 1024f)  / 1024f;
                return String.Format("{0:0.00}", gigabytes) + " GB";
            } else
            {
                var terabytes = (((bytes / 1024f) / 1024f) / 1024f) / 1024f;
                return String.Format("{0:0.00}", terabytes) + " TB";
            }
        }

        public static string GetPrettyDate(DateTime d)
        {
            // 1.
            // Get time span elapsed since the date.
            TimeSpan s = DateTime.Now.Subtract(d);

            // 2.
            // Get total number of days elapsed.
            int dayDiff = (int)s.TotalDays;

            int monthDiff = (int)((double)s.TotalDays / 30);

            // 3.
            // Get total number of seconds elapsed.
            int secDiff = (int)s.TotalSeconds;

            // 5.
            // Handle same-day times.
            if (dayDiff == 0)
            {
                // A.
                // Less than one minute ago.
                if (secDiff < 60)
                {
                    return "agora";
                }
                // B.
                // Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 minuto atrás";
                }
                // C.
                // Less than one hour ago.
                if (secDiff < 3600)
                {
                    return string.Format("{0} minuto atrás", Math.Floor((double)secDiff / 60));
                }
                // D.
                // Less than 2 hours ago.
                if (secDiff < 7200)
                {
                    return "1 horas atrás";
                }
                // E.
                // Less than one day ago.
                if (secDiff < 86400)
                {
                    return string.Format("{0} horas atrás",
                        Math.Floor((double)secDiff / 3600));
                }
            } else if(monthDiff == 0)
            {
                // 6.
                // Handle previous days.
                if (dayDiff == 1)
                {
                    return "ontem";
                }
                if (dayDiff < 7)
                {
                    return string.Format("{0} dias atrás", dayDiff);
                }
                if (dayDiff < 31)
                {
                    return string.Format("{0} semanas atrás",
                        Math.Ceiling((double)dayDiff / 7));
                }
            } else
            {
                if (monthDiff == 1)
                {
                    return "1 mês atrás";
                }
                if (monthDiff < 12)
                {
                    return string.Format("{0} meses atrás",
                        monthDiff);
                }
                if (monthDiff >= 12)
                {
                    return string.Format("{0} anos atrás",
                        Math.Ceiling((double)monthDiff / 12));
                }
            }
            
            return null;
        }
    }
}