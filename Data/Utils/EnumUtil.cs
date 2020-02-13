using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    public class EnumUtil 
    {
        //public static T ToEnum<T>( string value, T defaultValue) where T : Enum
        //{
        //    //if (string.IsNullOrEmpty(value))
        //    //{
        //    //    return defaultValue;
        //    //}

        //    //if (Enum.TryParse<T>(value, out T result))
        //    //{
        //    //    return result;
        //    //}
        //    //else
        //    //{
        //    //    return defaultValue;
        //    //}
        //}
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
