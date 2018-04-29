using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YLibs
    {
    public class ClassConverter
    {
        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if ((dt.Month != System.DateTime.Now.Month) || (dt.Day < 1 && dt.Day > 31) || dt.Year != System.DateTime.Now.Year)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public static DateTime NulltoDate(object x)
        {
            DateTime d = Convert.ToDateTime("1900-01-01");
            if (IsDate(x))
            {
                d = Convert.ToDateTime(x);
            }
            return d;
        }
        public static int NullToInt32(Object val)
        {
            int r = -1;
            try
            {
                r= Convert.ToInt32(val);
            }
            catch (Exception)
            {            }
            return r;
        }
        public static long NullToLong(Object val)
        {
            long r = -1;
            try
            {
                r = Convert.ToInt64(val);
            }
            catch (Exception)
            { }
            return r;
        }
        public static double NullToDbl(Object val)
        {
            double r = 0.0;
            try
            {
                r = Convert.ToDouble(val);
            }
            catch (Exception)
            { }
            return r;
        }
        public static Boolean NullToBool(Object val)
        {
            bool r = false;
            try
            {
                r = Convert.ToBoolean(val);
            }
            catch (Exception)
            { }
            return r;
        }

        public string FixApostropi(object obj)
        {
            string x = "";
            try
            {
                x = obj.ToString().Replace("'", "''");
            }
            catch (Exception )
            {
                x = "";
            }

            return x;
        }
        
        //string x1 = 1 == 1 ? "true" : "false";

        public string FixKoma(object obj)
        {            
            string x = "";
            try
            {
                x = obj.ToString().Replace(",", ".");
            }
            catch (Exception )
            {
                x = "";
            }

            return x;
        }

    }
}
