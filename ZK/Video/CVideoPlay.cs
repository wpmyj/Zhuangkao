using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Cn.Youdundianzi.Share.Module.Video
{
    class CVideoPlay
    {


        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_OpenFile")]
        private extern static bool PlayM4_OpenFile(Int32 nPort, string sFileName);
        public bool VideoOpenFile(Int32 nPort, string sFileName)
        {
            return PlayM4_OpenFile(nPort,sFileName);
        }


        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_CloseFile")]
        private extern static bool PlayM4_CloseFile(Int32 nPort);
        public bool VideoCloseFile(Int32 nPort)
        {
            return PlayM4_CloseFile(nPort);
        }

        //SVAPI BOOL PlayM4_Play(LONG nPort, HWND hWnd)
        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_Play")]
        private extern static bool PlayM4_Play(Int32 nPort,IntPtr hWnd);
        public bool VideoPlay(Int32 nPort, IntPtr hWnd)
        {
            return PlayM4_Play(nPort, hWnd);
        }


//        .8  SVAPI BOOL PlayM4_SetPlayPos(LONG nPort,float fRelativePos)
//说明：设置文件播放指针的相对位置（百分比）。 
//参数：nPort　端口
//      fRelativePos 范围0-100%
//返回值：TRUE－成功，FALSE－失败

        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_SetPlayPos")]
        private extern static bool PlayM4_SetPlayPos(Int32 nPort, float fRelativePos);
        public bool VideoSetPlayPos(Int32 nPort, float fRelativePos)
        {
            return PlayM4_SetPlayPos(nPort, fRelativePos);
        }


//        1.5  SVAPI BOOL PlayM4_Pause(LONG nPort,DWORD nPause)
//说明：播放暂停/恢复。 
//参数：nPort　端口
//nPause=TRUE暂停；否则恢复.
//   返回值：TRUE－成功，FALSE－失败

        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_Pause")]
        private extern static bool PlayM4_Pause(Int32 nPort, bool nPause);
        public bool VideoPause(Int32 nPort, bool nPause)
        {
            return PlayM4_Pause(nPort,nPause);
        }

//        .9 SVAPI float PlayM4_GetPlayPos(LONG nPort)
//说明：获得文件播放指针的相对位置。
//参数：nPort　端口
//    返回：范围0-100% 
        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_GetPlayPos")]
        private extern static uint PlayM4_GetPlayPos(Int32 nPort);
        public uint VideoGetPlayPos(Int32 nPort)
        {
            return PlayM4_GetPlayPos(nPort);
        }

//        SVAPI BOOL PlayM4_SetPlayedTimeEx(LONG nPort,DWORD nTime)
//说明：根据时间设置文件播放位置，此接口比PlayM4_SetPlayPos(详见函数说明1.8)费时，但如果用时间来控制播放进度条（与PlayM4_GetPlayedTime(Ex)配合使用），那么可以使进度条平滑滚动。 
//参数：nPort　端口
//         nTime 设置文件播放位置到指定时间，单位毫秒。
//返回值：TRUE－成功，FALSE－失败
        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_SetPlayedTimeEx")]
        private extern static bool PlayM4_SetPlayedTimeEx(Int32 nPort,int nTime);
        public bool VideoSetPlayedTimeEx(Int32 nPort,int nTime)
        {
            return PlayM4_SetPlayedTimeEx(nPort, nTime);
        }

//8 SVAPI DWORD PlayM4_GetPlayedTimeEx(LONG nPort)
//    说明：得到文件当前播放的时间，单位毫秒。 
//参数：nPort　端口
//    返回值：文件当前播放的时间。

        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_GetPlayedTime")]
        private extern static int PlayM4_GetPlayedTime(Int32 nPort);
        public int VideoGetPlayedTime(Int32 nPort)
        {
            return PlayM4_GetPlayedTime(nPort);
        }

        //SVAPI BOOL PlayM4_SetRefValue(LONG nPort,BYTE *pBuffer, DWORD nSize)
         [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_SetRefValue")]
         private extern static bool PlayM4_SetRefValue(Int32 nPort, ref byte[] pBuffer,int nSize);
        public bool VideoSetRefValue(Int32 nPort, ref byte[] pBuffer, int nSize)
        {
            return PlayM4_SetRefValue(nPort, ref pBuffer,nSize);
        }

        public delegate void pfnFileRefDone(Int32 nPort,int nUser);

        //SVAPI BOOL PlayM4_SetFileRefCallBack(LONG nPort, pfnFileRefDone SetFileRefCallBack, DWORD nUser)
         [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_SetFileRefCallBack")]
        private extern static bool PlayM4_SetFileRefCallBack(Int32 nPort, pfnFileRefDone SetFileRefCallBack, int nUser);
        public bool VideoSetFileRefCallBack(Int32 nPort, pfnFileRefDone  SetFileRefCallBack, int nUser)
        {
            return PlayM4_SetFileRefCallBack(nPort, SetFileRefCallBack, nUser);
        }

       // SVAPI BOOL PlayM4_GetRefValue(LONG nPort,BYTE *pBuffer, DWORD *pSize)
         [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_GetRefValue")]
        private extern static bool PlayM4_GetRefValue(Int32 nPort, byte[] pBuffer, ref int nSize);
        public bool VideoGetRefValue(Int32 nPort, byte[] pBuffer, ref int nSize)
        {
            return PlayM4_GetRefValue(nPort, pBuffer, ref nSize);
        }


        /// <summary>
        /// SVAPI DWORD PlayM4_GetFileTime(LONG nPort)
        /// 得到文件总的播放时间
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
         [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_GetFileTime")]
        private extern static int PlayM4_GetFileTime(Int32 nPort);
        public int VideoGetFileTime(Int32 nPort)
        {
            return PlayM4_GetFileTime(nPort);
        }


        //SVAPI DWORD PlayM4_GetFileTotalFrames(LONG nPort)
            [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_GetFileTotalFrames")]
        private extern static int PlayM4_GetFileTotalFrames(Int32 nPort);
        public int VideoGetFileTotalFrames(Int32 nPort)
        {
            return PlayM4_GetFileTotalFrames(nPort);
        }


        //BOOL PlayM4_SetStreamOpenMode(LONG nPort,DWORD nMode)
        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_SetStreamOpenMode")]
        private extern static bool PlayM4_SetStreamOpenMode(Int32 nPort, int nMode);
        public bool VideoSetOpenMode(Int32 nPort, int nMode)
        {
            return PlayM4_SetStreamOpenMode(nPort, nMode);
        }

        // SVAPI DWORD PlayM4_GetCurrentFrameRate(LONG nPort)
        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_GetCurrentFrameRate")]
        private extern static int PlayM4_GetCurrentFrameRate(Int32 nPort);
        public int VideoGetCurrentFrameRate(Int32 nPort)
        {
            return PlayM4_GetCurrentFrameRate(nPort);
        }


        //SVAPI DWORD PlayM4_GetCurrentFrameNum(LONG nPort)
        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_GetCurrentFrameNum")]
        private extern static int PlayM4_GetCurrentFrameNum(Int32 nPort);
        public int VideoGetCurrentFrameNum(Int32 nPort)
        {
            return PlayM4_GetCurrentFrameNum(nPort);
        }

        //SVAPI BOOL PlayM4_SetCurrentFrameNum(LONG nPort,DWORD nFrameNum)
        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_SetCurrentFrameNum")]
        private extern static bool PlayM4_SetCurrentFrameNum(Int32 nPort,int nFrameNum);
        public bool VideoSetCurrentFrameNum(Int32 nPort, int nFrameNum)
        {
            return PlayM4_SetCurrentFrameNum(nPort,nFrameNum);
        }

        //SVAPI BOOL PlayM4_SetFileEndMsg(LONG nPort,HWND hWnd,UINT nMsg)
        [DllImport("m4playerApi.dll", EntryPoint = "PlayM4_SetFileEndMsg")]
        private extern static bool PlayM4_SetFileEndMsg(Int32 nPort, IntPtr HWND,uint mMsg);
        public bool VideoSetFileEndMsg(Int32 nPort, IntPtr HWND, uint mMsg)
        {
            return PlayM4_SetFileEndMsg(nPort, HWND, mMsg);
        }


        //SVAPI DWORD PlayM4_GetPlayedTime(LONG nPort)
    }
}
