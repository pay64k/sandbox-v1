using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.KinectV2;

public class KinectDepth : MonoBehaviour
{
    private Windows.KinectV2.KinectSensor _Sensor;

    private DepthFrameReader _Reader;

    private Color32 minColor;
    private Color32 maxColor;

    private Color32[] colorScale;

    public float minHeight;
    public float maxHeight;

    public float alpha = 0.5f;

    private ushort[] _Data;

    Texture2D tex;

    private float[] previous_data;

    void Start()
    {
        previous_data = new float[512 * 424];
        for (int i = 0; i < previous_data.Length; i++)
        {
            previous_data[i] = 0f;
        }

        tex = new Texture2D(512, 424, TextureFormat.ARGB32, false);
        _Sensor = Windows.KinectV2.KinectSensor.GetDefault();

        GetComponent<Renderer>().material.mainTexture = tex;

        if (!_Sensor.IsOpen)
        {
            _Sensor.Open();
            _Reader = _Sensor.DepthFrameSource.OpenReader();
            _Data = new ushort[_Sensor.DepthFrameSource.FrameDescription.LengthInPixels];
            print("----Kinect V2 started----");
        }
    }

    void Update()
    {

        if (!_Sensor.IsAvailable)
        {
            return;
        }

        Renderer renderer = GetComponent<Renderer>();
        var frame = _Reader.AcquireLatestFrame();

        if (frame != null)
        {
            frame.CopyFrameDataToArray(_Data);
            frame.Dispose();
            frame = null;
        }
        ushort[] current_data = _Data;
        float[] current_data_float = new float[current_data.Length];

        for (int i = 0; i < current_data.Length; i++)
        {
            current_data_float[i] = MapRange2(current_data[i], minHeight, maxHeight, 0f, 1f);
        }

        for (int i = 0; i < current_data.Length; i++)
        {
            previous_data[i] = alpha * current_data_float[i] + (1 - alpha) * previous_data[i];
        }

        short[] previous_data_mapped = new short[previous_data.Length];

        for (int i = 0; i < current_data.Length; i++)
        {
            previous_data_mapped[i] = (short)MapRange(previous_data[i], 0f, 1f, 0, 255f);
        }

        tex.SetPixels32(convertDepthToColor(previous_data_mapped));

        tex.Apply(false);
        renderer.material.SetTexture("_MainTex", tex);
    }

    int MapRange(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return Mathf.RoundToInt((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
    }

    float MapRange2(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    private Color32[] convertDepthToColor(short[] depthBuf)
    {
        Color32[] img = new Color32[depthBuf.Length];
        for (int pix = 0; pix < depthBuf.Length; pix++)
        {
            img[pix].r = (byte)MapRange(depthBuf[pix], maxHeight, minHeight, 0, 255f);
            img[pix].g = (byte)(depthBuf[pix] / 8);
            img[pix].b = (byte)(depthBuf[pix] / 8);
        }

        return img;
    }

}

