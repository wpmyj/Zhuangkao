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

        public string  Status; //״̬,"δ֪"��"����","������","����"

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
            Status = "δ֪";
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

        public int commcount = 0; //��¼ͨѶ����
        public int resetcount = 0; //��λ��������������Ʒ���ʲô������и�λͬ��

    }
}
