using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.KinectV2
{
    //
    // Windows.Kinect.BodyIndexFrameSource
    //
    public sealed partial class BodyIndexFrameSource : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal BodyIndexFrameSource(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_BodyIndexFrameSource_AddRefObject(ref _pNative);
        }

        ~BodyIndexFrameSource()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyIndexFrameSource_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyIndexFrameSource_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<BodyIndexFrameSource>(_pNative);
                Windows_Kinect_BodyIndexFrameSource_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameSource_get_FrameDescription(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.FrameDescription FrameDescription
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyIndexFrameSource");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameSource_get_FrameDescription(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.FrameDescription>(objectPointer, n => new Windows.KinectV2.FrameDescription(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern bool Windows_Kinect_BodyIndexFrameSource_get_IsActive(RootSystem.IntPtr pNative);
        public  bool IsActive
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyIndexFrameSource");
                }

                return Windows_Kinect_BodyIndexFrameSource_get_IsActive(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameSource_get_KinectSensor(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.KinectSensor KinectSensor
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyIndexFrameSource");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameSource_get_KinectSensor(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.KinectSensor>(objectPointer, n => new Windows.KinectV2.KinectSensor(n));
            }
        }


        // Events
        private static RootSystem.Runtime.InteropServices.GCHandle _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle;
        [RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args, RootSystem.IntPtr pNative);
        private static Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.KinectV2.FrameCapturedEventArgs>>> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.KinectV2.FrameCapturedEventArgs>>>();
        [AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
        private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<Windows.KinectV2.FrameCapturedEventArgs>> callbackList = null;
            Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock(callbackList)
            {
                var objThis = Helper.NativeObjectCache.GetObject<BodyIndexFrameSource>(pNative);
                var args = new Windows.KinectV2.FrameCapturedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyIndexFrameSource_add_FrameCaptured(RootSystem.IntPtr pNative, _Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
        public  event RootSystem.EventHandler<Windows.KinectV2.FrameCapturedEventArgs> FrameCaptured
        {
            add
            {
                Helper.EventPump.EnsureInitialized();

                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if(callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler);
                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle = RootSystem.Runtime.InteropServices.GCHandle.Alloc(del);
                        Windows_Kinect_BodyIndexFrameSource_add_FrameCaptured(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    return;
                }

                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if(callbackList.Count == 0)
                    {
                        Windows_Kinect_BodyIndexFrameSource_add_FrameCaptured(_pNative, Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle.Free();
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
                var objThis = Helper.NativeObjectCache.GetObject<BodyIndexFrameSource>(pNative);
                var args = new Windows.Data.PropertyChangedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyIndexFrameSource_add_PropertyChanged(RootSystem.IntPtr pNative, _Windows_Data_PropertyChangedEventArgs_Delegate eventCallback, bool unsubscribe);
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
                        Windows_Kinect_BodyIndexFrameSource_add_PropertyChanged(_pNative, del, false);
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
                        Windows_Kinect_BodyIndexFrameSource_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameSource_OpenReader(RootSystem.IntPtr pNative);
        public Windows.KinectV2.BodyIndexFrameReader OpenReader()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("BodyIndexFrameSource");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_BodyIndexFrameSource_OpenReader(_pNative);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.KinectV2.BodyIndexFrameReader>(objectPointer, n => new Windows.KinectV2.BodyIndexFrameReader(n));
        }

        private void __EventCleanup()
        {
            {
                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                        {
                            Windows_Kinect_BodyIndexFrameSource_add_FrameCaptured(_pNative, Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle.Free();
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
                            Windows_Kinect_BodyIndexFrameSource_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }
    }

}
