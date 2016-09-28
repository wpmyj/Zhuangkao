using System;
using System.Collections.Generic;
using System.Text;

namespace Cn.Youdundianzi.Share.Module.Login
{
    public enum UserClass
    {
        NONE = 0,   //无权限
        PRACTICE = 10,  //练习权限。尽可练习
        EXAM = 20,  //考试权限。可练习，可考试。不可设置
        ADMIN = 100, //管理员权限。尽可设置
        APPADMIN = 200, //应用程序管理员。尽可设置应用程序的配置文件
        SUPER = 255 //超级用户。拥有除不可设置应用程序的配置文件外其他所有权限
    }
    public static class CMyGlobal
    {
        static public string G_Login_Username = string.Empty;
        static public UserClass G_Login_UserCls = UserClass.NONE;
    }
}
