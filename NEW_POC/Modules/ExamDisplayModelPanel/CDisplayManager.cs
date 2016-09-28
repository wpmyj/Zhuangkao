using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace Modules.ExamDisplayModelPanel
{
    public class CDisplayManager
    {
        private ArrayList displayobj;

        public CDisplayManager()
        {
            displayobj = new ArrayList();
        }
        
        public void RegDisplay(IFairy obj)
        {
            displayobj.Add(obj);
        }

        public void UnRegDisplay(IFairy obj)
        {
            displayobj.Remove(obj);
        }

        public void DisplayAll(Graphics g)
        {
            for (int i = 0; i < displayobj.Count; i++)
            {
                IFairy tmp = (IFairy)displayobj[i];
                tmp.Display(g);
            }
        }
    }
}
