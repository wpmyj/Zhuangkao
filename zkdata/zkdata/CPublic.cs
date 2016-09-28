using System;
using System.Collections.Generic;
using System.Text;

namespace zkdata
{
    static class CPublic
    {
        static string downsqlstr_all = "select count(*) from drv_admin.drv_preasign where (ZT ='0'or ZT='2') and (KSKM='2')";
        static string downsqlstr = "select count(*) from drv_admin.drv_preasign where (ZT ='0'or ZT='2') and (KSKM='2')";
        static string sendsqlstr = "";
    }
}

            