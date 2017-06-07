using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.KinectV2;

public class PlaneDepth : MonoBehaviour
{
    private Windows.KinectV2.KinectSensor _Sensor;

    private DepthFrameReader _Reader;

    private Color32 minColor;
    private Color32 maxColor;

    public int PlaneIdentifier;

    private Color32[] colorScale;

    public float minHeight = 784;
    public float maxHeight = 1071;

    public float alpha = 0.15f;

    public DepthSource depthSource;

    Texture2D tex;

    private float[] previous_data;

    void Start()
    {
        previous_data = new float[512 * 424/2];
        for (int i = 0; i < previous_data.Length; i++)
        {
            previous_data[i] = 0f;
        }

        tex = new Texture2D(512, 424 / 2, TextureFormat.ARGB32, false);

        GetComponent<Renderer>().material.mainTexture = tex;

    }

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();

        ushort[] current_data = depthSource.GetKinectV2DepthData();
        float[] current_data_float = new float[current_data.Length / 2];

        for (int i = 0; i < current_data.Length / 2; i++)
        {
            current_data_float[i] = MapRange2(current_data[i], minHeight, maxHeight, 0f, 1f);
        }

        for (int i = 0; i < current_data.Length / 2; i++)
        {
            previous_data[i] = alpha * current_data_float[i] + (1 - alpha) * previous_data[i];
        }

        short[] previous_data_mapped = new short[previous_data.Length];

        for (int i = 0; i < current_data.Length / 2; i++)
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

