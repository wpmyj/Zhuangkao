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
        SVVidFormat_RGB = 7, //自动选择与桌面一致的RGB格式
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
	　CAP_FMT_MPEG4,
	　CAP_FMT_XVID
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


//        [DllImport("JYSDK.dll", EntryPoint = "InitDSP")] //初始化视频捕捉卡
//        private extern static int InitDSP(int plCardType, ref int lCard0, ref int lCard1, ref int lCard2, ref int lCard3, ref int lCard4);
//        public int init(int plCardType, ref int lCard0, ref int lCard1, ref int lCard2, ref int lCard3, ref int lCard4)
//        {
//            return InitDSP(plCardType, ref lCard0, ref lCard1, ref lCard2, ref lCard3, ref lCard4);
//        }


//        [DllImport("JYSDK.dll", EntryPoint = "DeInitDSP")] //释放捕捉卡资源
//        private extern static int DeInitDSP();
//        public int Close()
//        {
//            return DeInitDSP();
//        }


//        [DllImport("JYSDK.dll", EntryPoint = "SetMpegMode")] //设置捕捉卡模式
//        private extern static int SetMpegMode(int MpegMode);
//         //压缩模式选择：0-2; 0,最优模式，图像质量最好，cpu占用高；
//         //            1，优化模式，
//         //            2，标准模式，cpu占用低；
//        public int SetMode(int mpegmode)
//        {
//            return SetMpegMode(mpegmode);
//        }


//        [DllImport("JYSDK.dll", EntryPoint = "OpenChannel")] //得到捕捉卡通道
//        private extern static  IntPtr OpenChannel(short ChannelNum);
//        //说明：打开通道，获取相关的通道号
//        //参数：ChannelNum 通道号
//        //返回：返回相关的通道号，否则返回NULL
//        public IntPtr GetChannel(short channelnum)
//        {
//            return OpenChannel(channelnum);
//        }


//        [DllImport("713xapi.dll", EntryPoint = "StartVideoPreview")] //开始预览
//        private extern static int StartVideoPreview(IntPtr hChannelHandle, 
//                                                   IntPtr WndHandle,
//                                                    ref Rect rect,
//                                                    bool bOverlay,
//                                                    SVVidFormat VideoFormat,
//                                                    short FrameRate);
//        //说明：启动视频预览
//        //参数：hChannelHandle 通道句柄
//        //     WndHandle　窗口句柄
//        //     *rect　矩形窗口
//        //     bOverlay  是否支持Overlay
//        //     VideoFormat　视频显示模式（详见数据类型定义1）
//        //     FrameRate　帧率
//        //返回：SVError_OK（详见SDK 错误代号及说明）
//        public int MyStartVideoPreview(IntPtr hChannelHandle,
//                                                    IntPtr WndHandle,
//                                                    ref Rect rect,
//                                                    bool bOverlay,
//                                                    SVVidFormat VideoFormat,
//                                                    short FrameRate)
//        {
//            return StartVideoPreview(hChannelHandle, WndHandle, ref rect, bOverlay, VideoFormat, FrameRate);

//        }


    
//         [DllImport("713xapi.dll", EntryPoint = "StopVideoPreview")] //停止预览
//        private extern static short StopVideoPreview(IntPtr hChannelHandle);
//        //     说明：停止视频预览
//        //参数：ChannelHandle 通道句柄
//        //返回：SVError_OK（详见SDK 错误代号及说明）
//        public short StopPreview(IntPtr hChannelHandle)
//        {
//            return StopVideoPreview(hChannelHandle);
//        }
      



//        [DllImport("713xapi.dll", EntryPoint = "GetVideoSignal")] //检测捕捉卡信号
//        private extern static short GetVideoSignal(IntPtr hChannelHandle);
//        //说明：获取视频信号
//        //参数：hChannelHandle　通道句柄
//        //返回：0－有信号， 1－无信号

 
//         [DllImport("JYSDK.dll", EntryPoint = "GetBoardSN")] //得到捕捉卡通道
//        private extern static  int  GetBoardSN(int lCardNum);
//        //得到视频卡的序列号，卡号(lCardNum) 0-5 ;
//        //每张4路卡1个卡号，8路卡2个卡号，支持24路；
//        public int GetBoarnum(int lCardNum)
//        {
//            return GetBoardSN(lCardNum);
//        }







//        [DllImport("713xapi.dll", EntryPoint = "StartVideoCapture")] //检测捕捉卡信号
//        private extern static short StartVideoCapture(IntPtr hChannelHandle,CaptureFormat CapFmt);
//       //说明：开始录像
//       //参数：hChannelHandle　通道句柄
//       //   CapFmt　录像压缩格式(详见数据类型定义2)
//       //返回：SVError_OK（详见SDK 错误代号及说明）
//        public short MyStrartVideoCapture(IntPtr hChannelHandle)
//        {
//            return StartVideoCapture(hChannelHandle, CaptureFormat.CAP_FMT_XVID);
//        }


//        [DllImport("713xapi.dll", EntryPoint = "StartMotionDetection")] //检测捕捉卡信号
//        private extern static short StartMotionDetection(IntPtr hChannelHandle);
//        public short StartMotion(IntPtr hChannelHandle)
//        {
//            return StartMotionDetection(hChannelHandle);
//        }
//        //说明：开始动态检测
//        //参数：hChannelHandle　通道句柄
//        //返回：SVError_OK（详见SDK 错误代号及说明）



//        [DllImport("713xapi.dll", EntryPoint = "SetOsd")] //检测捕捉卡信号
//        private extern static short SetOsd(IntPtr hChannelHandle,bool Enable);
//        public short MySetOsd(IntPtr hChannelHandle)
//        {
//            return SetOsd(hChannelHandle,false);
//        }
//       //说明：设置OSD
//       //参数：hChannelHandle　通道句柄
//       //   Enable　是否显示OSD
//       //返回：SVError_OK（详见SDK 错误代号及说明）



      
////         SVAPI int WINAPI SetCaptureSize(HANDLE hChannelHandle, CAPSize size)
////说明：设置视频源图像的宽高。仅仅对软卡（M404T）有效。
////参数：hChannelHandle　通道句柄
////   size　图像存取的模式（详见数据类型定义4）　
////返回：所设置的图像尺寸

//        [DllImport("713xapi.dll", EntryPoint = "SetCaptureSize")] //检测捕捉卡信号
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
