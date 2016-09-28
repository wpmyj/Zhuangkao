using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace lukao
{
    public class CKsDevModel
    {
        public  ArrayList StudentList;


        private string ksdevname;
        public string Ksdevname
        {
            get { return ksdevname; }
            set { ksdevname = value; }
        }

        private string ksdevorder;
        public string Ksdevorder
        {
            get { return ksdevorder; }
            set { ksdevorder = value; }
        }

        public string  Status; //状态,"未知"，"空闲","考试中","故障"

        public CStudent DqStudent
        {
            get
            {
                if (StudentList.Count > 0)
                {
                    return (CStudent)StudentList[0];
                }
                else
                {
                    return null;
                }
            }
        }

        public CKsDevModel()
        {
            StudentList = new ArrayList();
            Status = "未知";
        }

        public void AddStudent(CStudent student)
        {
            StudentList.Add(student);
        }

        public void RemoveStudent(CStudent student)
        {
            StudentList.Remove(student);
        }

        public void RemoveStudent(int rmindex)
        {
            StudentList.RemoveAt(rmindex);
        }

        public int commcount = 0; //记录通讯次数
        public int resetcount = 0; //复位命令计数器，控制发送什么命令进行复位同步

    }
}
