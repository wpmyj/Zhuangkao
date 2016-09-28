using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Cn.Youdundianzi.Share.Module.Video
{
    enum SVVidFormat
    {
        UNKNOW = -1,
        SVVidFormat_YUY2 = 0,
        SVVidFormat_UYVY = 1,
        SVVidFormat_YV12 = 2,
        SVVidFormat_RGB15 = 3,
        SVVidFormat_RGB16 = 4,
        SVVidFormat_RGB24 = 5,
        SVVidFormat_RGB32 = 6,
        SVVidFormat_RGB = 7, //�Զ�ѡ��������һ�µ�RGB��ʽ
    }

     enum SVError
    {
        SVError_OK = 0,
        SVError_OneInstanceRunning = 1,
        SVError_OutOfMemory = 2,
        SVError_CanntFoundDevice = 3,
        SVError_InvalidPointer = 4,
        SVError_InvalidHandle = 5,
        SVError_InvalidParam = 6,
        SVError_CreateDDrawFail = 7,
        SVError_CreateOverlayFail = 8,
        SVError_OperationIsDenied = 9,
        SVError_DeviceIoControlFail = 10,
        SVError_CanntCreateFile = 11,
        SVError_CanntOpenFile = 12,
        SVError_CreateEncoderFail = 13,
        SVError_FIFOISEMPTY = 14,
        SVError_UnknowBoard = 15,
        SVError_Unsupport = 16,
        SVError_FAIL = -1,
    }

     enum FrameType_t
    {
        PktError = 0,
        PktIFrames = 0x0001,
        PktPFrames = 0x0002,
        PktBBPFrames = 0x0004,
        PktAudioFrames = 0x0008,
        PktMotionDetection = 0x00010,
        PktSysHeader = 0x00080,
        PktMotionDetectionOff = 0x00300
    }


    [StructLayout(LayoutKind.Sequential)]
     struct Point
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Explicit)]
     struct Rect
    {
        [FieldOffset(0)]
        public int left;
        [FieldOffset(4)]
        public int top;
        [FieldOffset(8)]
        public int right;
        [FieldOffset(12)]
        public int bottom;
    }

    enum CaptureFormat
    {
	��CAP_FMT_MPEG4,
	��CAP_FMT_XVID
    }

    enum CAPSize
    {
        CAP_CIF,
        CAP_QCIF
    }


     class CMyVideo
    {

       // HWND  CreateVideoDlg(HWND parent,int left,int top,int right,int bottom)

        [DllImport("test_video2.dll", EntryPoint = "CreateVideoDlg")]
        public  extern static int CreateVideoDlg(IntPtr parent, int left, int top, int right, int bottom);

        [DllImport("test_video2.dll", EntryPoint = "SelectChannel")]
        public extern static void SelectChannel(int selchannel);


        // void  SetVideoDlgRect(int left,int top,int right,int bottom);
       //void  MoveVideoDlg();
        [DllImport("test_video2.dll", EntryPoint = "MoveVideoDlg")]
        public extern static void MoveVideoDlg();

        [DllImport("test_video2.dll", EntryPoint = "SetVideoDlgRect")]
        public extern static void SetVideoDlgRect(int left, int top, int right, int bottom);


        [DllImport("test_video2.dll", EntryPoint = "WCaptureImage")]
        public extern static void WCaptureImage(int channel, string filename);


        [DllImport("test_video2.dll", EntryPoint = "Close")]
        public extern static void Close();


        [DllImport("test_video2.dll", EntryPoint = "WStartVideoCapture")]
        public extern static void WStartVideoCapture(int channel, string filename);


        [DllImport("test_video2.dll", EntryPoint = "WStopVideoCapture")]
        public extern static void WStopVideoCapture(int channel);


        [DllImport("test_video2.dll", EntryPoint = "WRegisterMessageNotifyHandle")]
        public extern static int WRegisterMessageNotifyHandle(IntPtr hWnd, uint MessageId);


        [DllImport("test_video2.dll", EntryPoint = "WReadStreamData")]
        public extern static int WReadStreamData(int channelnum,  byte[] DataBuf,  ref int Length, ref short FrameType);


//        [DllImport("JYSDK.dll", EntryPoint = "InitDSP")] //��ʼ����Ƶ��׽��
//        private extern static int InitDSP(int plCardType, ref int lCard0, ref int lCard1, ref int lCard2, ref int lCard3, ref int lCard4);
//        public int init(int plCardType, ref int lCard0, ref int lCard1, ref int lCard2, ref int lCard3, ref int lCard4)
//        {
//            return InitDSP(plCardType, ref lCard0, ref lCard1, ref lCard2, ref lCard3, ref lCard4);
//        }


//        [DllImport("JYSDK.dll", EntryPoint = "DeInitDSP")] //�ͷŲ�׽����Դ
//        private extern static int DeInitDSP();
//        public int Close()
//        {
//            return DeInitDSP();
//        }


//        [DllImport("JYSDK.dll", EntryPoint = "SetMpegMode")] //���ò�׽��ģʽ
//        private extern static int SetMpegMode(int MpegMode);
//         //ѹ��ģʽѡ��0-2; 0,����ģʽ��ͼ��������ã�cpuռ�øߣ�
//         //            1���Ż�ģʽ��
//         //            2����׼ģʽ��cpuռ�õͣ�
//        public int SetMode(int mpegmode)
//        {
//            return SetMpegMode(mpegmode);
//        }


//        [DllImport("JYSDK.dll", EntryPoint = "OpenChannel")] //�õ���׽��ͨ��
//        private extern static  IntPtr OpenChannel(short ChannelNum);
//        //˵������ͨ������ȡ��ص�ͨ����
//        //������ChannelNum ͨ����
//        //���أ�������ص�ͨ���ţ����򷵻�NULL
//        public IntPtr GetChannel(short channelnum)
//        {
//            return OpenChannel(channelnum);
//        }


//        [DllImport("713xapi.dll", EntryPoint = "StartVideoPreview")] //��ʼԤ��
//        private extern static int StartVideoPreview(IntPtr hChannelHandle, 
//                                                   IntPtr WndHandle,
//                                                    ref Rect rect,
//                                                    bool bOverlay,
//                                                    SVVidFormat VideoFormat,
//                                                    short FrameRate);
//        //˵����������ƵԤ��
//        //������hChannelHandle ͨ�����
//        //     WndHandle�����ھ��
//        //     *rect�����δ���
//        //     bOverlay  �Ƿ�֧��Overlay
//        //     VideoFormat����Ƶ��ʾģʽ������������Ͷ���1��
//        //     FrameRate��֡��
//        //���أ�SVError_OK�����SDK ������ż�˵����
//        public int MyStartVideoPreview(IntPtr hChannelHandle,
//                                                    IntPtr WndHandle,
//                                                    ref Rect rect,
//                                                    bool bOverlay,
//                                                    SVVidFormat VideoFormat,
//                                                    short FrameRate)
//        {
//            return StartVideoPreview(hChannelHandle, WndHandle, ref rect, bOverlay, VideoFormat, FrameRate);

//        }


    
//         [DllImport("713xapi.dll", EntryPoint = "StopVideoPreview")] //ֹͣԤ��
//        private extern static short StopVideoPreview(IntPtr hChannelHandle);
//        //     ˵����ֹͣ��ƵԤ��
//        //������ChannelHandle ͨ�����
//        //���أ�SVError_OK�����SDK ������ż�˵����
//        public short StopPreview(IntPtr hChannelHandle)
//        {
//            return StopVideoPreview(hChannelHandle);
//        }
      



//        [DllImport("713xapi.dll", EntryPoint = "GetVideoSignal")] //��Ⲷ׽���ź�
//        private extern static short GetVideoSignal(IntPtr hChannelHandle);
//        //˵������ȡ��Ƶ�ź�
//        //������hChannelHandle��ͨ�����
//        //���أ�0�����źţ� 1�����ź�

 
//         [DllImport("JYSDK.dll", EntryPoint = "GetBoardSN")] //�õ���׽��ͨ��
//        private extern static  int  GetBoardSN(int lCardNum);
//        //�õ���Ƶ�������кţ�����(lCardNum) 0-5 ;
//        //ÿ��4·��1�����ţ�8·��2�����ţ�֧��24·��
//        public int GetBoarnum(int lCardNum)
//        {
//            return GetBoardSN(lCardNum);
//        }







//        [DllImport("713xapi.dll", EntryPoint = "StartVideoCapture")] //��Ⲷ׽���ź�
//        private extern static short StartVideoCapture(IntPtr hChannelHandle,CaptureFormat CapFmt);
//       //˵������ʼ¼��
//       //������hChannelHandle��ͨ�����
//       //   CapFmt��¼��ѹ����ʽ(����������Ͷ���2)
//       //���أ�SVError_OK�����SDK ������ż�˵����
//        public short MyStrartVideoCapture(IntPtr hChannelHandle)
//        {
//            return StartVideoCapture(hChannelHandle, CaptureFormat.CAP_FMT_XVID);
//        }


//        [DllImport("713xapi.dll", EntryPoint = "StartMotionDetection")] //��Ⲷ׽���ź�
//        private extern static short StartMotionDetection(IntPtr hChannelHandle);
//        public short StartMotion(IntPtr hChannelHandle)
//        {
//            return StartMotionDetection(hChannelHandle);
//        }
//        //˵������ʼ��̬���
//        //������hChannelHandle��ͨ�����
//        //���أ�SVError_OK�����SDK ������ż�˵����



//        [DllImport("713xapi.dll", EntryPoint = "SetOsd")] //��Ⲷ׽���ź�
//        private extern static short SetOsd(IntPtr hChannelHandle,bool Enable);
//        public short MySetOsd(IntPtr hChannelHandle)
//        {
//            return SetOsd(hChannelHandle,false);
//        }
//       //˵��������OSD
//       //������hChannelHandle��ͨ�����
//       //   Enable���Ƿ���ʾOSD
//       //���أ�SVError_OK�����SDK ������ż�˵����



      
////         SVAPI int WINAPI SetCaptureSize(HANDLE hChannelHandle, CAPSize size)
////˵����������ƵԴͼ��Ŀ�ߡ�����������M404T����Ч��
////������hChannelHandle��ͨ�����
////   size��ͼ���ȡ��ģʽ������������Ͷ���4����
////���أ������õ�ͼ��ߴ�

//        [DllImport("713xapi.dll", EntryPoint = "SetCaptureSize")] //��Ⲷ׽���ź�
//        private extern static short SetCaptureSize(IntPtr hChannelHandle, CAPSize size);
//        public short MySetCaptureSize(IntPtr hChannelHandle)
//        {
//            return SetCaptureSize(hChannelHandle, CAPSize.CAP_CIF);
//        }

        

//        public short MyGetVideoSignal(IntPtr  hChannelHandle)
//        {
//            return GetVideoSignal(hChannelHandle);
//        }


    }
}
