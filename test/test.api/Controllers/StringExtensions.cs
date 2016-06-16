using System;
using System.ComponentModel;
using System.IO;
using System.Security.Policy;
using Newtonsoft.Json;

namespace HpaUtility.Extensions
{
    public static class StringExtensions
    {
        public static TEnum TryPaseEnum<TEnum>(this string stringValue)
            where TEnum : struct 
        {
            return (TEnum)Enum.Parse(typeof(TEnum), stringValue);
        }

        public static TEnum TryPaseEnum<TEnum>(this string stringValue, TEnum defaultEnum)
            where TEnum : struct
        {
            return string.IsNullOrWhiteSpace(stringValue) ? defaultEnum : TryPaseEnum<TEnum>(stringValue);
        }

        public static int TryParseInt(this string stringValue, int defaultVal = 0)
        {
            if (string.IsNullOrEmpty(stringValue))
                return defaultVal;

            int result;
            return int.TryParse(stringValue, out result) ? result : defaultVal;
        }

        public static int? TryParseNullableInt(this string stringValue, int? defaultVal = null)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultVal;
            }
            try
            {
                return int.Parse(stringValue);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }

        public static decimal? TryParseDecimal(this string decimalString)
        {
            if (string.IsNullOrEmpty(decimalString))
                return null;

            decimal result;
            if (decimal.TryParse(decimalString, out result))
                return result;
            return null;
        }

        public static double? TryParseDouble(this string decimalString)
        {
            if (string.IsNullOrEmpty(decimalString))
                return null;

            double returnValue;
            if (double.TryParse(decimalString, out returnValue))
                return returnValue;
            return null;
        }

        public static byte[] ToByteArray(this string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }



        public static void WriteToFile(this string str, string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            if (fileInfo.Directory == null)
                throw new Exception($"File {fileName} directory invalidate.");

            if(fileInfo.Directory != null && !fileInfo.Directory.Exists)
                fileInfo.Directory.Create();
            if(fileInfo.Exists)
                fileInfo.Delete();

            using (var stream = File.Create(fileName))
            {
                var bytes = str.ToByteArray();
                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
