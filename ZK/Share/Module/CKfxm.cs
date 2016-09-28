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
                case "·��":
                    return "B101";
                 case "�н�":
                    return "B101";
                case "����":
                    return "B102";
                case "ѹ��":
                    return "B103";
                case "�ƿ�":
                    return "B104";
                case "����":
                    return "";
                default:
                    return "B103";
            }

        }
    }
}
