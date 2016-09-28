using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GenCode128;
using Util;

namespace Modules.PrintModule
{
    public class CPrintContent
    { 
        public CTextPrintObjSet ksxmtxt;
        public CTextPrintObjSet ksddtxt;
        public CTextPrintObjSet kscjtxt;
        public CTextPrintObjSet ksrqtxt;
        public CTextPrintObjSet ksyxmtxt;
        public CTextPrintObjSet kscxtxt;
        //private CImagePrintObjSet tiaomaimg;
        public System.Drawing.Printing.PrintDocument printDocument1;
        PrintSettings settings;

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
                //tiaomaimg.InImage = Code128Rendering.MakeBarcodeImage(ksxmstr + kscjstr.ToString(), 1, true);
            }
            get { return kscjtxt.Printtext; }
        }

        public string kscxstr
        {
            set { kscxtxt.Printtext = value; }
            get { return kscxtxt.Printtext; }
        }
        public string ksyxmstr
        {
            set { ksyxmtxt.Printtext = value; }
            get { return ksyxmtxt.Printtext; }
        }

        public CPrintContent(PrintSettings prtSet)
        {
            settings = prtSet;

            ksddtxt = new CTextPrintObjSet();
            ksddtxt.Printtext = "";
            ksddtxt.mmX = settings.Ksdd_x;
            ksddtxt.mmY = settings.Ksdd_y;
            ksddtxt.Fn = new Font("宋体", settings.FontSize);

            ksxmtxt = new CTextPrintObjSet();
            ksxmtxt.Printtext = "";
            ksxmtxt.mmX = settings.Ksxm_x;
            ksxmtxt.mmY = settings.Ksxm_y;
            ksxmtxt.Fn = new Font("宋体", settings.FontSize);

            kscjtxt = new CTextPrintObjSet();
            kscjtxt.Printtext = "";
            kscjtxt.mmX = settings.Kscj_x;
            kscjtxt.mmY = settings.Kscj_y;
            kscjtxt.Fn = new Font("宋体", settings.FontSize);

            kscxtxt = new CTextPrintObjSet();
            kscxtxt.Printtext = "";
            kscxtxt.mmX = settings.Kscx_x;
            kscxtxt.mmY = settings.Kscx_y;
            kscxtxt.Fn = new Font("宋体", settings.FontSize);

            ksrqtxt = new CTextPrintObjSet();
            ksrqtxt.Printtext = "";
            ksrqtxt.mmX = settings.Ksrq_x;
            ksrqtxt.mmY = settings.Ksrq_y;
            ksrqtxt.Fn = new Font("宋体", settings.FontSize);

            ksyxmtxt = new CTextPrintObjSet();
            ksyxmtxt.Printtext = "";
            ksyxmtxt.mmX = settings.Ksyxm_x;
            ksyxmtxt.mmY = settings.Ksyxm_y;
            ksyxmtxt.Fn = new Font("宋体", settings.FontSize);

            //tiaomaimg = new CImagePrintObjSet();
            //tiaomaimg.mmX = settings.Tiaomaimg_x;
            //tiaomaimg.mmY = settings.Tiaomaimg_y;

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
             kscxtxt.PrintObj(g);
             ksrqtxt.PrintObj(g);
             ksyxmtxt.PrintObj(g);
             //tiaomaimg.PrintObj(g);

        }

    }
}
