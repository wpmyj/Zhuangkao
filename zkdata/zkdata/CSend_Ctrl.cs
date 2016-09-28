using System;
using System.Collections.Generic;
using System.Text;

namespace zkdata
{
    public class CSend_Ctrl
    {
        Send_Form send_form;
        CSend_Model send_model;
        
        public CSend_Ctrl(Send_Form send_form, CSend_Model send_model)
        {
            this.send_form = send_form;
            this.send_model = send_model;
            send_model.Event_SQLLink += new CSend_Model.D_SQLlink(OnEvent_SQLLink);
            send_model.Event_ORACLELink += new CSend_Model.D_ORACLElink(OnEvent_OraLink);
            send_model.LocalDBlink();
            send_model.RemoteDBlink();
            send_model.Event_Send+=new CSend_Model.D_Send(send_model_Event_Send);

        }

        public void OnEvent_SQLLink(bool islink) //�յ�Sql���ݿ������¼��Ĵ���
        {
            send_form.LocallinkState(islink);
            send_form.UpdateDfsjnum(send_model.Localdbnum);//���´��������ݱ�ǩ 
            send_form.locallinkButtonEnable(!islink);
            send_form.SetprogressBar_Max(send_model.Localdbnum);
        }

        public void OnEvent_OraLink(bool islink)
        {
            send_form.RemotelinkButtonEnable(!islink);
            send_form.RemotelinkState(islink);
        }

        public void send_model_Event_Send(int sendnum)
        {
            send_form.Updatefssjnum(sendnum);
            send_form.progressBar_Step();
        }


        public void SendData()
        {
            send_form.progressBar_Reset();
            send_form.SetprogressBar_Show(true);
            send_form.SwButtonState();
            send_model.SendData();
            send_form.Updatetimelabel(send_model.SaveSendTime());//��������ʱ��ͱ�����������ʱ��
            send_form.SetprogressBar_Show(false);
            send_form.SwButtonState();
           // send_form.UpdateDfsjnum(send_model.Localdbnum);
        }

    }
}
