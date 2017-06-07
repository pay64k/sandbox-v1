using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.KinectV2
{
    //
    // Windows.Kinect.KinectSensor
    //
    public sealed partial class KinectSensor : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal KinectSensor(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_KinectSensor_AddRefObject(ref _pNative);
        }

        ~KinectSensor()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_KinectSensor_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_KinectSensor_AddRefObject(ref RootSystem.IntPtr pNative);

        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_AudioSource(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.AudioSource AudioSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_AudioSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.AudioSource>(objectPointer, n => new Windows.KinectV2.AudioSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_BodyFrameSource(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.BodyFrameSource BodyFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_BodyFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.BodyFrameSource>(objectPointer, n => new Windows.KinectV2.BodyFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_BodyIndexFrameSource(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.BodyIndexFrameSource BodyIndexFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_BodyIndexFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.BodyIndexFrameSource>(objectPointer, n => new Windows.KinectV2.BodyIndexFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_ColorFrameSource(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.ColorFrameSource ColorFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_ColorFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.ColorFrameSource>(objectPointer, n => new Windows.KinectV2.ColorFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_CoordinateMapper(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.CoordinateMapper CoordinateMapper
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_CoordinateMapper(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.CoordinateMapper>(objectPointer, n => new Windows.KinectV2.CoordinateMapper(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_DepthFrameSource(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.DepthFrameSource DepthFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_DepthFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.DepthFrameSource>(objectPointer, n => new Windows.KinectV2.DepthFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_InfraredFrameSource(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.InfraredFrameSource InfraredFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_InfraredFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.InfraredFrameSource>(objectPointer, n => new Windows.KinectV2.InfraredFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern bool Windows_Kinect_KinectSensor_get_IsAvailable(RootSystem.IntPtr pNative);
        public  bool IsAvailable
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                return Windows_Kinect_KinectSensor_get_IsAvailable(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern bool Windows_Kinect_KinectSensor_get_IsOpen(RootSystem.IntPtr pNative);
        public  bool IsOpen
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                return Windows_Kinect_KinectSensor_get_IsOpen(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.KinectCapabilities Windows_Kinect_KinectSensor_get_KinectCapabilities(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.KinectCapabilities KinectCapabilities
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                return Windows_Kinect_KinectSensor_get_KinectCapabilities(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_LongExposureInfraredFrameSource(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.LongExposureInfraredFrameSource LongExposureInfraredFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_LongExposureInfraredFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.LongExposureInfraredFrameSource>(objectPointer, n => new Windows.KinectV2.LongExposureInfraredFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_get_UniqueKinectId(RootSystem.IntPtr pNative);
        public  string UniqueKinectId
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectSensor");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_get_UniqueKinectId(_pNative);
                Helper.ExceptionHelper.CheckLastError();

                var managedString = RootSystem.Runtime.InteropServices.Marshal.PtrToStringUni(objectPointer);
                RootSystem.Runtime.InteropServices.Marshal.FreeCoTaskMem(objectPointer);
                return managedString;
            }
        }


        // Events
        private static RootSystem.Runtime.InteropServices.GCHandle _Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handle;
        [RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_IsAvailableChangedEventArgs_Delegate(RootSystem.IntPtr args, RootSystem.IntPtr pNative);
        private static Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.KinectV2.IsAvailableChangedEventArgs>>> Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks = new Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.KinectV2.IsAvailableChangedEventArgs>>>();
        [AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_IsAvailableChangedEventArgs_Delegate))]
        private static void Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handler(RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<Windows.KinectV2.IsAvailableChangedEventArgs>> callbackList = null;
            Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock(callbackList)
            {
                var objThis = Helper.NativeObjectCache.GetObject<KinectSensor>(pNative);
                var args = new Windows.KinectV2.IsAvailableChangedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_KinectSensor_add_IsAvailableChanged(RootSystem.IntPtr pNative, _Windows_Kinect_IsAvailableChangedEventArgs_Delegate eventCallback, bool unsubscribe);
        public  event RootSystem.EventHandler<Windows.KinectV2.IsAvailableChangedEventArgs> IsAvailableChanged
        {
            add
            {
                Helper.EventPump.EnsureInitialized();

                Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if(callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_IsAvailableChangedEventArgs_Delegate(Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handler);
                        _Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handle = RootSystem.Runtime.InteropServices.GCHandle.Alloc(del);
                        Windows_Kinect_KinectSensor_add_IsAvailableChanged(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    return;
                }

                Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if(callbackList.Count == 0)
                    {
                        Windows_Kinect_KinectSensor_add_IsAvailableChanged(_pNative, Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }

        private static RootSystem.Runtime.InteropServices.GCHandle _Windows_Data_PropertyChangedEventArgs_Delegate_Handle;
        [RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private delegate void _Windows_Data_PropertyChangedEventArgs_Delegate(RootSystem.IntPtr args, RootSystem.IntPtr pNative);
        private static Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Data.PropertyChangedEventArgs>>> Windows_Data_PropertyChangedEventArgs_Delegate_callbacks = new Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Data.PropertyChangedEventArgs>>>();
        [AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Data_PropertyChangedEventArgs_Delegate))]
        private static void Windows_Data_PropertyChangedEventArgs_Delegate_Handler(RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<Windows.Data.PropertyChangedEventArgs>> callbackList = null;
            Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock(callbackList)
            {
                var objThis = Helper.NativeObjectCache.GetObject<KinectSensor>(pNative);
                var args = new Windows.Data.PropertyChangedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_KinectSensor_add_PropertyChanged(RootSystem.IntPtr pNative, _Windows_Data_PropertyChangedEventArgs_Delegate eventCallback, bool unsubscribe);
        public  event RootSystem.EventHandler<Windows.Data.PropertyChangedEventArgs> PropertyChanged
        {
            add
            {
                Helper.EventPump.EnsureInitialized();

                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if(callbackList.Count == 1)
                    {
                        var del = new _Windows_Data_PropertyChangedEventArgs_Delegate(Windows_Data_PropertyChangedEventArgs_Delegate_Handler);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle = RootSystem.Runtime.InteropServices.GCHandle.Alloc(del);
                        Windows_Kinect_KinectSensor_add_PropertyChanged(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    return;
                }

                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if(callbackList.Count == 0)
                    {
                        Windows_Kinect_KinectSensor_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Static Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_GetDefault();
        public static Windows.KinectV2.KinectSensor GetDefault()
        {
            RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_GetDefault();
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.KinectSensor>(objectPointer, n => new Windows.KinectV2.KinectSensor(n));
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_KinectSensor_Open(RootSystem.IntPtr pNative);
        public void Open()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("KinectSensor");
            }

            Windows_Kinect_KinectSensor_Open(_pNative);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_KinectSensor_Close(RootSystem.IntPtr pNative);
        public void Close()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("KinectSensor");
            }

            Windows_Kinect_KinectSensor_Close(_pNative);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_KinectSensor_OpenMultiSourceFrameReader(RootSystem.IntPtr pNative, Windows.KinectV2.FrameSourceTypes enabledFrameSourceTypes);
        public Windows.KinectV2.MultiSourceFrameReader OpenMultiSourceFrameReader(Windows.KinectV2.FrameSourceTypes enabledFrameSourceTypes)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("KinectSensor");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_KinectSensor_OpenMultiSourceFrameReader(_pNative, enabledFrameSourceTypes);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.MultiSourceFrameReader>(objectPointer, n => new Windows.KinectV2.MultiSourceFrameReader(n));
        }

        private void __EventCleanup()
        {
            {
                Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_IsAvailableChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                        {
                            Windows_Kinect_KinectSensor_add_IsAvailableChanged(_pNative, Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Kinect_IsAvailableChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
            {
                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                        {
                            Windows_Kinect_KinectSensor_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }
    }

}
