//************************************************
//      版面管理
//************************************************
using System;
using System.Collections.Generic;
using System.Text;
//*****************************************
// 设备视图列表管理，存放的是视图列表的集合
//*****************************************

using System.Collections;
using System.Windows.Forms;

namespace zkcenter
{
    public class CViewManage
    {
        ArrayList ControlList;
        Control bkConsole;//背景容器

        public CViewManage(Control bkConsole)
        {
            this.bkConsole = bkConsole;
            ControlList = new ArrayList();
        }

        public void AddControl(CDevListview con)
        {
            ControlList.Add(con);
           
        }

        public void RemoveControl(CDevListview con)
        {
            ControlList.Remove(con);
        }


        public bool ChangeDevStatus(int devnum, DevStatus status)
        {
            foreach (CDevListview tmp in ControlList)
            {
                if (tmp.IntDevnum == devnum)
                {
                    tmp.Status = status;
                    return true;
                }
            }
            return false;
        }

        public void UpdateStudentlist(int devnum, CStuDevlist stulist)
        {
            foreach (CDevListview tmp in ControlList)
            {
                if (tmp.IntDevnum == devnum)
                {
                    tmp.UpdateStudent(stulist);
                    return;
                }
            }
        }

        public void UpdateStuColor(int devnum)
        {
            foreach (CDevListview tmp in ControlList)
            {
                if (tmp.IntDevnum == devnum)
                {
                    tmp.UpdateStuColor();
                    return;
                }
            }
        }

        public void ReUpdateStuColor(int devnum)
        {
            foreach (CDevListview tmp in ControlList)
            {
                if (tmp.IntDevnum == devnum)
                {
                    tmp.ReUpdateStuColor();
                    return;
                }
            }
        }

        public void AutoMove()
        {
            int useleft=3;
            int useheight=5;

            if (ControlList.Count > 0)
            {
                for(int i=0;i<ControlList.Count;i++)
                {
                    ((CDevListview)ControlList[i]).Left = useleft;
                    ((CDevListview)ControlList[i]).Top = useheight;
                    useleft = useleft + ((CDevListview)ControlList[i]).Width + 3;
                    if ((i + 1) < ControlList.Count)
                    {
                        if ((((CDevListview)ControlList[i + 1]).Width  + useleft) > bkConsole.Width)
                        {
                            useleft = 3;
                            useheight = useheight+((CDevListview)ControlList[i + 1]).Height + 5;
                        }
                    }
                    
                }
            }
        }




        
            
    }
}
