//********************************************************************************
//ÿһ��׮���豸����һ��CStuDevlist�࣬������������ڴ�׮���ǿ��Լ��ȴ����Ե�ѧ��
//      2008��8��14��
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
        public int Stumum//�Ŷ�����
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

        //���豸�в��ҿ���
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

        public bool RemoveStudent_asZKZ(string zkzhm)//����׼��֤������Ӧ�Ŀ���ɾ��
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
