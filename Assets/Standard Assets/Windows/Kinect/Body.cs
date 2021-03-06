using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.KinectV2
{
    //
    // Windows.Kinect.Body
    //
    public sealed partial class Body : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal Body(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_Body_AddRefObject(ref _pNative);
        }

        ~Body()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_Body_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_Body_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<Body>(_pNative);
                Windows_Kinect_Body_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_Activities(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.Activity[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.DetectionResult[] outValues, int outCollectionSize);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_Activities_Length(RootSystem.IntPtr pNative);
        public  RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.Activity, Windows.KinectV2.DetectionResult> Activities
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                int outCollectionSize = Windows_Kinect_Body_get_Activities_Length(_pNative);
                var outKeys = new Windows.KinectV2.Activity[outCollectionSize];
                var outValues = new Windows.KinectV2.DetectionResult[outCollectionSize];
                var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.Activity, Windows.KinectV2.DetectionResult>();

                outCollectionSize = Windows_Kinect_Body_get_Activities(_pNative, outKeys, outValues, outCollectionSize);
                Helper.ExceptionHelper.CheckLastError();
                for(int i=0;i<outCollectionSize;i++)
                {
                    managedDictionary.Add(outKeys[i], outValues[i]);
                }
                return managedDictionary;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_Appearance(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.Appearance[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.DetectionResult[] outValues, int outCollectionSize);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_Appearance_Length(RootSystem.IntPtr pNative);
        public  RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.Appearance, Windows.KinectV2.DetectionResult> Appearance
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                int outCollectionSize = Windows_Kinect_Body_get_Appearance_Length(_pNative);
                var outKeys = new Windows.KinectV2.Appearance[outCollectionSize];
                var outValues = new Windows.KinectV2.DetectionResult[outCollectionSize];
                var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.Appearance, Windows.KinectV2.DetectionResult>();

                outCollectionSize = Windows_Kinect_Body_get_Appearance(_pNative, outKeys, outValues, outCollectionSize);
                Helper.ExceptionHelper.CheckLastError();
                for(int i=0;i<outCollectionSize;i++)
                {
                    managedDictionary.Add(outKeys[i], outValues[i]);
                }
                return managedDictionary;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.FrameEdges Windows_Kinect_Body_get_ClippedEdges(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.FrameEdges ClippedEdges
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_ClippedEdges(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.DetectionResult Windows_Kinect_Body_get_Engaged(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.DetectionResult Engaged
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_Engaged(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_Expressions(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.Expression[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.DetectionResult[] outValues, int outCollectionSize);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_Expressions_Length(RootSystem.IntPtr pNative);
        public  RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.Expression, Windows.KinectV2.DetectionResult> Expressions
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                int outCollectionSize = Windows_Kinect_Body_get_Expressions_Length(_pNative);
                var outKeys = new Windows.KinectV2.Expression[outCollectionSize];
                var outValues = new Windows.KinectV2.DetectionResult[outCollectionSize];
                var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.Expression, Windows.KinectV2.DetectionResult>();

                outCollectionSize = Windows_Kinect_Body_get_Expressions(_pNative, outKeys, outValues, outCollectionSize);
                Helper.ExceptionHelper.CheckLastError();
                for(int i=0;i<outCollectionSize;i++)
                {
                    managedDictionary.Add(outKeys[i], outValues[i]);
                }
                return managedDictionary;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.TrackingConfidence Windows_Kinect_Body_get_HandLeftConfidence(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.TrackingConfidence HandLeftConfidence
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_HandLeftConfidence(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.HandState Windows_Kinect_Body_get_HandLeftState(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.HandState HandLeftState
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_HandLeftState(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.TrackingConfidence Windows_Kinect_Body_get_HandRightConfidence(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.TrackingConfidence HandRightConfidence
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_HandRightConfidence(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.HandState Windows_Kinect_Body_get_HandRightState(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.HandState HandRightState
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_HandRightState(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern bool Windows_Kinect_Body_get_IsRestricted(RootSystem.IntPtr pNative);
        public  bool IsRestricted
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_IsRestricted(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern bool Windows_Kinect_Body_get_IsTracked(RootSystem.IntPtr pNative);
        public  bool IsTracked
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_IsTracked(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_JointOrientations(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.JointType[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.JointOrientation[] outValues, int outCollectionSize);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_JointOrientations_Length(RootSystem.IntPtr pNative);
        public  RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.JointType, Windows.KinectV2.JointOrientation> JointOrientations
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                int outCollectionSize = Windows_Kinect_Body_get_JointOrientations_Length(_pNative);
                var outKeys = new Windows.KinectV2.JointType[outCollectionSize];
                var outValues = new Windows.KinectV2.JointOrientation[outCollectionSize];
                var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.JointType, Windows.KinectV2.JointOrientation>();

                outCollectionSize = Windows_Kinect_Body_get_JointOrientations(_pNative, outKeys, outValues, outCollectionSize);
                Helper.ExceptionHelper.CheckLastError();
                for(int i=0;i<outCollectionSize;i++)
                {
                    managedDictionary.Add(outKeys[i], outValues[i]);
                }
                return managedDictionary;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_Joints(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.JointType[] outKeys, [RootSystem.Runtime.InteropServices.Out] Windows.KinectV2.Joint[] outValues, int outCollectionSize);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_Joints_Length(RootSystem.IntPtr pNative);
        public  RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.JointType, Windows.KinectV2.Joint> Joints
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                int outCollectionSize = Windows_Kinect_Body_get_Joints_Length(_pNative);
                var outKeys = new Windows.KinectV2.JointType[outCollectionSize];
                var outValues = new Windows.KinectV2.Joint[outCollectionSize];
                var managedDictionary = new RootSystem.Collections.Generic.Dictionary<Windows.KinectV2.JointType, Windows.KinectV2.Joint>();

                outCollectionSize = Windows_Kinect_Body_get_Joints(_pNative, outKeys, outValues, outCollectionSize);
                Helper.ExceptionHelper.CheckLastError();
                for(int i=0;i<outCollectionSize;i++)
                {
                    managedDictionary.Add(outKeys[i], outValues[i]);
                }
                return managedDictionary;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.KinectV2.TrackingState Windows_Kinect_Body_get_LeanTrackingState(RootSystem.IntPtr pNative);
        public  Windows.KinectV2.TrackingState LeanTrackingState
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_LeanTrackingState(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern ulong Windows_Kinect_Body_get_TrackingId(RootSystem.IntPtr pNative);
        public  ulong TrackingId
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("Body");
                }

                return Windows_Kinect_Body_get_TrackingId(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_Body_get_JointCount();
        public static int JointCount
        {
            get
            {
                return Windows_Kinect_Body_get_JointCount();
            }
        }


        // Public Methods
        private void __EventCleanup()
        {
        }
    }

}
