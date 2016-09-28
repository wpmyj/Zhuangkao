using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace zkcenter
{
    class DisplayStrings
    {
        private static Hashtable stringBuffer = new Hashtable();

        public static void AddString(string key, string value)
        {
            try
            {
                stringBuffer.Add(key, value);
            }
            catch (Exception ex)
            {
            }
        }

        public static void UpdateString(string key, string value)
        {
            try
            {
                stringBuffer[key] = value;
            }
            catch (Exception ex)
            {
            }
        }

        public static string GetValue(string key)
        {
            return (string)stringBuffer[key];
        }

        public static void DeleteString(string key)
        {
            stringBuffer.Remove(key);
        }

        public static string GetWholeString(string key)
        {
            return key + (string)stringBuffer[key];
        }

        public static string GetAllStrings()
        {
            StringBuilder tmpKSStringBuilder = new StringBuilder();
            StringBuilder tmpZBStringBuilder = new StringBuilder();
            foreach (string key in stringBuffer.Keys)
            {
                if (((string)stringBuffer[key]).Equals("øº ‘"))
                {
                    tmpKSStringBuilder.Append(key);
                    tmpKSStringBuilder.Append((string)stringBuffer[key]);
                    tmpKSStringBuilder.Append(Environment.NewLine);
                }
                else
                {
                    tmpZBStringBuilder.Append(key);
                    tmpZBStringBuilder.Append((string)stringBuffer[key]);
                    tmpZBStringBuilder.Append(Environment.NewLine);
                }
            }
            return tmpKSStringBuilder.ToString() + tmpZBStringBuilder;
        }
    }
}
