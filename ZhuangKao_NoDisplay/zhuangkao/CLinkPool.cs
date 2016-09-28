using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace zhuangkao
{
    public class CLinkPool
    {
        private ArrayList _linkarray;
        public int LinkCount
        {
            get { return _linkarray.Count; }
        }
        public CLinkPool()
        {
            _linkarray = new ArrayList();
        }

        public void RegDbLink(CLink link)
        {
            _linkarray.Add(link);
        }

        public int OpenLink() //����ֵΪ��ǰ�ǵڼ������ӣ���0��ʼ����-1Ϊû�гɹ�������
        {
            for (int i = 0; i < _linkarray.Count; i++)
            {
                ((CLink)_linkarray[i]).OpenConnect();
            }
            for (int i = 0; i < _linkarray.Count; i++)
            {
                if (((CLink)_linkarray[i]).Useable)
                {
                    return i;
                }
            }
            return -1;
        }

        public CLink GetLink(int linkorder)
        {
            return (CLink)_linkarray[linkorder];
        }

    }
}
