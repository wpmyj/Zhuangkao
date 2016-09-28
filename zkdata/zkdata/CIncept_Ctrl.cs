using System;
using System.Collections.Generic;
using System.Text;

namespace zkdata
{
    public class CIncept_Ctrl
    {
        Incept_Form inceptform;
        CIncept_Model inceptmodel;

        public CIncept_Ctrl(Incept_Form inceptform, CIncept_Model inceptmodel)
        {
            this.inceptform = inceptform;
            this.inceptmodel = inceptmodel;
            inceptmodel.Event_SQLLink += new CIncept_Model.D_SQLlink(OnEvent_SQLLink);
            inceptmodel.Event_ORACLELink += new CIncept_Model.D_ORACLElink(OnEvent_OraLink);
            inceptmodel.LocalDBlink(); //连接本地SQL数据库 
            inceptmodel.RemoteDBlink();//连接远程Oracle数据库
            inceptmodel.Event_DOWNLOAD +=new CIncept_Model.D_Download(inceptmodel_Event_DOWNLOAD);
            inceptmodel.Event_DOWNLOADErr+=new CIncept_Model.D_DownloadErr(inceptmodel_Event_DOWNLOADErr);
        }

        public void OnEvent_SQLLink(bool islink) //收到Sql数据库连接事件的处理
        {
            inceptform.LocallinkState(islink);
            inceptform.locallinkButtonEnable(!islink);
            inceptform.UpdateLocalnum(inceptmodel.Localdbnum);
        }

        public void OnEvent_OraLink(bool islink)
        {
            inceptform.RemotelinkState(islink);
            inceptform.RemotelinkButtonEnable(!islink);
            inceptform.UpdateRemotenum(inceptmodel.Remotedbnum);
            inceptform.SetprogressBar_Max(inceptmodel.Remotedbnum);
        }

        public void inceptmodel_Event_DOWNLOAD(int downloadnum)
        {
            inceptform.UpdateDownloadnum(downloadnum);
            inceptform.progressBar_Step();
        }

        public void inceptmodel_Event_DOWNLOADErr(int errdownloadnum)
        {
            inceptform.UpdateErrDownloadnum(errdownloadnum);
        }


        public bool LocalDBlink()
        {
            return inceptmodel.LocalDBlink(); 
        }

        public void DownloadData()
        {
            inceptform.progressBar_Reset();
            inceptform.SetprogressBar_Show(true);
            inceptmodel.DownloadData();
            inceptform.Updatetimelabel(inceptmodel.SavedownloadTime());//更新下载时间和保存最新下载时间
            inceptform.SetprogressBar_Show(false);
            inceptform.SwButtonState();
            inceptform.UpdateLocalnum(inceptmodel.Localdbnum);
        }


        public int ClearLocalData()
        {
           int tmp=  inceptmodel.ClearLocalData();
           inceptform.UpdateLocalnum(inceptmodel.Localdbnum);
           return tmp;
        }

        public void StopDownloadData()
        {
            inceptmodel.Isstopdownload = true;
            inceptform.SwButtonState();
        }
    }
}
