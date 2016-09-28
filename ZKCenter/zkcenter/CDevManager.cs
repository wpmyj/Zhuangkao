//*****************************************
//  设备列表管理，存放的是学生列表的集合
//*****************************************

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace zkcenter
{
    public class CDevManager
    {
        public Hashtable DevList;

        public CDevManager()
        {
            DevList = new Hashtable();
        }

        public void Add(CStuDevlist dev)
        {
            DevList.Add(dev.DevNum, dev);
        }

        public void Remove(CStuDevlist dev)
        {
            DevList.Remove(dev.DevNum);
        }

        public void ClearStudent(int devnum)
        {
            ((CStuDevlist)DevList[devnum]).ClearStudent();
        }

        public CStudent  GetStudent(int devnum)
        {
            if (((CStuDevlist)DevList[devnum]).StudentList.Count <= 0)
            {
                return null;
            }
            return (CStudent)(((CStuDevlist)DevList[devnum]).StudentList[0]);
        }

        //返回指定设备的第stuindex位考生
        public CStudent GetStudent(int devnum, int stuindex)
        {
            if (((CStuDevlist)DevList[devnum]).StudentList.Count <= stuindex)
            {
                return null;
            }
            return (CStudent)(((CStuDevlist)DevList[devnum]).StudentList[stuindex]);
        }

        public CStudent GetStudent(int devnum, string zkzhm)
        {
            if (((CStuDevlist)DevList[devnum]).StudentList.Count <= 0)
            {
                return null;
            }
            return (CStudent)(((CStuDevlist)DevList[devnum]).GetStudent(zkzhm));
        }

        public bool DeleteStudent(int devnum, string zkzhm)
        {
           return ((CStuDevlist)DevList[devnum]).RemoveStudent_asZKZ(zkzhm);
        }

        //删除设备列表中第一个考试（在考试完成事件中应用）
        public void DeleteFirstStudent(int devnum)
        {
            ((CStuDevlist)DevList[devnum]).StudentList.RemoveAt(0);
        }

        //在所有设备中查找考生，返回设备号
        public int FindStudent(string zkzhm)
        {
            foreach (DictionaryEntry tmplist in DevList)
            {
                if (((CStuDevlist)tmplist.Value).FindStudent(zkzhm))
                {
                    return ((CStuDevlist)tmplist.Value).DevNum;
                }

            }
            return 0;
        }

        public int GetMinnum()//得到最少人数的设备,返回设备号
        {
            int devnum = 0;
            int minnum = int.MaxValue;
            foreach (DictionaryEntry tmplist in DevList)
            {
                if (minnum >=((CStuDevlist)tmplist.Value).Stumum)
                {
                    devnum = ((CStuDevlist)tmplist.Value).DevNum;
                    minnum = ((CStuDevlist)tmplist.Value).Stumum;
                }
            }
            return devnum;
        }

    }
}
