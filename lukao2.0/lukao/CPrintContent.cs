using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace lukao
{
    public class CPrintContent
    {
        private CTextPrintObjSet ksxmtxt;
        private CTextPrintObjSet ksddtxt;
        private CTextPrintObjSet kscjtxt;
        private CTextPrintObjSet ksrqtxt;
        private CTextPrintObjSet ksyxmtxt;
        private System.Drawing.Printing.PrintDocument printDocument1;


        public string ksxmstr
        {
            set { ksxmtxt.Printtext = value; }
            get { return ksxmtxt.Printtext; }
        }

        public string ksddstr
        {
            set { ksddtxt.Printtext = value; }
            get { return ksddtxt.Printtext; }
        }

        public string ksrqstr
        {
            set { ksrqtxt.Printtext = value; }
            get { return ksrqtxt.Printtext; }
        }

        public string kscjstr
        {
            set { kscjtxt.Printtext = value; }
            get { return kscjtxt.Printtext; }
        }

        public string ksyxmstr
        {
            set { ksyxmtxt.Printtext = value; }
            get { return ksyxmtxt.Printtext; }
        }



        CModel model;


        public CPrintContent(CModel model)
        {
            this.model = model;

            ksddtxt = new CTextPrintObjSet();
            ksddtxt.Printtext = "";
            ksddtxt.mmX = model.settings.Ksdd_x;
            ksddtxt.mmY = model.settings.Ksdd_y;
          

            ksxmtxt = new CTextPrintObjSet();
            ksxmtxt.Printtext = "";
            ksxmtxt.mmX = model.settings.Ksxm_x;
            ksxmtxt.mmY = model.settings.Ksxm_y;
  

            kscjtxt = new CTextPrintObjSet();
            kscjtxt.Printtext = "";
            kscjtxt.mmX = model.settings.Kscj_x;
            kscjtxt.mmY = model.settings.Kscj_y;
        

            ksrqtxt = new CTextPrintObjSet();
            ksrqtxt.Printtext = "";
            ksrqtxt.mmX = model.settings.Ksrq_x;
            ksrqtxt.mmY = model.settings.Ksrq_y;
           

            ksyxmtxt = new CTextPrintObjSet();
            ksyxmtxt.Printtext = "";
            ksyxmtxt.mmX = model.settings.Ksyxm_x;
            ksyxmtxt.mmY = model.settings.Ksyxm_y;
       

            printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
        }


        public void Print()
        {
            printDocument1.Print(); 
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
             ksddtxt.PrintObj(g);
             ksxmtxt.PrintObj(g);
             kscjtxt.PrintObj(g);
             ksrqtxt.PrintObj(g);
             ksyxmtxt.PrintObj(g);

        }

    }
}
