using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Share.Module
{
    static public class CKfxm
    {
        static public string GetKfxm(string sm)
        {
            string sm1 = string.Empty;
            sm1 = sm.Substring(0,2);
            switch (sm1)
            {
                case "路线":
                    return "B101";
                 case "行进":
                    return "B101";
                case "碰杆":
                    return "B102";
                case "压线":
                    return "B103";
                case "移库":
                    return "B104";
                case "考试":
                    return "";
                default:
                    return "B103";
            }

        }
    }
}
