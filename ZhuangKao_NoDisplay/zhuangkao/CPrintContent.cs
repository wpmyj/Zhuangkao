using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GenCode128;

namespace zhuangkao
{
    public class CPrintContent
    { 
        private CTextPrintObjSet ksxmtxt;
        private CTextPrintObjSet ksddtxt;
        private CTextPrintObjSet kscjtxt;
        private CTextPrintObjSet ksrqtxt;
        private CTextPrintObjSet ksyxmtxt;
        private CImagePrintObjSet tiaomaimg;
        private System.Drawing.Printing.PrintDocument printDocument1;
        ModuleSettings settings;

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
            set 
            { 
                kscjtxt.Printtext = value;
                tiaomaimg.InImage = Code128Rendering.MakeBarcodeImage(ksxmstr + kscjstr.ToString() , 1, true);
            }
            get { return kscjtxt.Printtext; }
        }

        public string ksyxmstr
        {
            set { ksyxmtxt.Printtext = value; }
            get { return ksyxmtxt.Printtext; }
        }

        public CPrintContent()
        {
            settings = ModuleConfig.GetSettings();

            ksddtxt = new CTextPrintObjSet();
            ksddtxt.Printtext = "";
            ksddtxt.mmX = settings.Ksdd_x;
            ksddtxt.mmY = settings.Ksdd_y;
          

            ksxmtxt = new CTextPrintObjSet();
            ksxmtxt.Printtext = "";
            ksxmtxt.mmX = settings.Ksxm_x;
            ksxmtxt.mmY = settings.Ksxm_y;
  

            kscjtxt = new CTextPrintObjSet();
            kscjtxt.Printtext = "";
            kscjtxt.mmX = settings.Kscj_x;
            kscjtxt.mmY = settings.Kscj_y;
        

            ksrqtxt = new CTextPrintObjSet();
            ksrqtxt.Printtext = "";
            ksrqtxt.mmX = settings.Ksrq_x;
            ksrqtxt.mmY = settings.Ksrq_y;
           

            ksyxmtxt = new CTextPrintObjSet();
            ksyxmtxt.Printtext = "";
            ksyxmtxt.mmX = settings.Ksyxm_x;
            ksyxmtxt.mmY = settings.Ksyxm_y;

            tiaomaimg = new CImagePrintObjSet();
            tiaomaimg.mmX = settings.Tiaomaimg_x;
            tiaomaimg.mmY = settings.Tiaomaimg_y;

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
             tiaomaimg.PrintObj(g);

        }

    }
}
