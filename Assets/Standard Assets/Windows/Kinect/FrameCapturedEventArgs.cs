using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.KinectV2
{
    //
    // Windows.Kinect.FrameCapturedEventArgs
    //
    public sealed partial class FrameCapturedEventArgs : RootSystem.EventArgs, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal FrameCapturedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_FrameCapturedEventArgs_AddRefObject(ref _pNative);
        }

        ~FrameCapturedEventArgs()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_FrameCapturedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_FrameCapturedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<FrameCapturedEventArgs>(_pNative);
                Windows_Kinect_FrameCapturedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.FrameCapturedStatus Windows_Kinect_FrameCapturedEventArgs_get_FrameStatus(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.FrameCapturedStatus FrameStatus
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");
                }

                return Windows_Kinect_FrameCapturedEventArgs_get_FrameStatus(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.FrameSourceTypes Windows_Kinect_FrameCapturedEventArgs_get_FrameType(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.FrameSourceTypes FrameType
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");
                }

                return Windows_Kinect_FrameCapturedEventArgs_get_FrameType(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_FrameCapturedEventArgs_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_FrameCapturedEventArgs_get_RelativeTime(_pNative));
            }
        }

        private void __EventCleanup()
        {
        }
    }

}
