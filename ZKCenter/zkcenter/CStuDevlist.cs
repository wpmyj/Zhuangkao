//********************************************************************************
//每一个桩考设备包含一个CStuDevlist类，里面包含所有在此桩考仪考试及等待考试的学生
//      2008年8月14日
//********************************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace zkcenter
{
    public class CStuDevlist
    {
        public int DevNum;
        public ArrayList StudentList;
        public int Stumum//排队人数
        {
            get { return StudentList.Count; }
        }

        public CStuDevlist()
        {
            StudentList = new ArrayList();
        }

        public void AddStudent(CStudent student)
        {
            StudentList.Add(student);
        }

        public void RemoveStudent(CStudent student)
        {
            StudentList.Remove(student);
        }

        public void ClearStudent()
        {
            StudentList.Clear();
        }

        public CStudent GetStudent(string zkzhm)
        {
            foreach (object stu in StudentList)
            {
                if (((CStudent)stu).zkzmbh == zkzhm)
                {
                    return  (CStudent)stu;
                }
            }
            return null;
        }

        //在设备中查找考生
        public bool FindStudent(string zkzhm)
        {
            foreach (object stu in StudentList)
            {
                if (((CStudent)stu).zkzmbh == zkzhm)
                {
                    return true;
                }
            }
            return false;
        }

        public bool RemoveStudent_asZKZ(string zkzhm)//查找准考证号码相应的考生删除
        {
            List<CStudent> delstudentlist = new List<CStudent>();
            foreach (object stu in StudentList)
            {
                if (((CStudent)stu).zkzmbh == zkzhm)
                {
                    delstudentlist.Add((CStudent)stu);
                }
            }
            if(delstudentlist.Count>0)
            {
                for(int i=0;i<delstudentlist.Count;i++)
                {
                    RemoveStudent(delstudentlist[i]);
                }
                return true;

            }else
            {
                return false ;
            }

            
        }

    }
}
