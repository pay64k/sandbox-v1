using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.KinectV2;

public class DepthSource : MonoBehaviour {

    private Windows.KinectV2.KinectSensor _Sensor;

    private DepthFrameReader _Reader;

    private ushort[] _Data;

    // Use this for initialization
    void Start () {
        _Sensor = Windows.KinectV2.KinectSensor.GetDefault();
        if (!_Sensor.IsOpen)
        {
            _Sensor.Open();
            _Reader = _Sensor.DepthFrameSource.OpenReader();
            _Data = new ushort[_Sensor.DepthFrameSource.FrameDescription.LengthInPixels];
            print("----Kinect V2 started by DepthSource----");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!_Sensor.IsAvailable)
        {
            return;
        }
        var frame = _Reader.AcquireLatestFrame();
        if (frame != null)
        {
            frame.CopyFrameDataToArray(_Data);
            frame.Dispose();
            frame = null;
        }
    }

    public ushort[] GetKinectV2DepthData()
    {
        return _Data;
    }
}
