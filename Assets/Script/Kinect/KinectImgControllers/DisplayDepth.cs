using UnityEngine;
using System.Collections;
using System;
using AForge.Imaging.Filters;
using System.Drawing;

[RequireComponent(typeof(Renderer))]
public class DisplayDepth : MonoBehaviour {
	
	public DepthWrapper dw;

    public GameObject ScoreObject;

    private bool updateMapProjection = true;
    
    private Texture2D tex;

    public float minHeight;
    public float maxHeight;

    public float alpha = 0.5f;
    public bool enableFiltering = true;

    private float[] previous_data;
    private short[] current_data;
    GaussianBlur blurFilter = new GaussianBlur(4, 11);
    Bitmap bitmap;
    
    void Start () {
        bitmap = new System.Drawing.Bitmap(320, 240, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
        updateMapProjection = true;
		tex = new Texture2D(320,240,TextureFormat.ARGB32,false);
        tex.filterMode = FilterMode.Bilinear;
        tex.Apply();

        previous_data = new float[320*240];
        for (int i=0;i< previous_data.Length;i++)
        {
            previous_data[i] = 0f;
        }
        GetComponent<Renderer>().material.mainTexture = tex;

    }
	
	void Update () {
        Renderer renderer = GetComponent<Renderer>();

        if (dw.pollDepth() && updateMapProjection)
		{

            current_data = dw.depthImg;
            float[] current_data_float = new float[current_data.Length];

            for (int i=0;i< current_data.Length; i++)
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
            if(enableFiltering)
                FilterImage(previous_data_mapped);
            tex.SetPixels32(convertDepthToColor(previous_data_mapped));
                        
            tex.Apply(false);
            renderer.material.SetTexture("_MainTex", tex);
        }
    }
	
	private Color32[] convertDepthToColor(short[] depthBuf)
	{
		Color32[] img = new Color32[depthBuf.Length];
		for (int pix = 0; pix < depthBuf.Length; pix++)
		{
			img[pix].r = (byte)MapRange(depthBuf[pix], maxHeight, minHeight , 0, 255f); 
			img[pix].g = (byte)(depthBuf[pix] / 8);
			img[pix].b = (byte)(depthBuf[pix] / 8);
		}

		return img;
	}
	
    int MapRange(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return Mathf.RoundToInt((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
    }

    float MapRange2(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    public void disableMapUpdate()
    {
        updateMapProjection = false;
    }

    public void enableMapUpdate()
    {
        updateMapProjection = true;
    }

    void FilterImage(short[] depthImage)
    {
        // Copy Image to Bitmap
        System.Drawing.Rectangle ImageBounds = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
        System.Drawing.Imaging.ImageLockMode Mode = System.Drawing.Imaging.ImageLockMode.ReadWrite;
        System.Drawing.Imaging.PixelFormat Format = bitmap.PixelFormat;
        System.Drawing.Imaging.BitmapData BitmapData = bitmap.LockBits(ImageBounds, Mode, Format);

        System.IntPtr ptr = BitmapData.Scan0;

        System.Runtime.InteropServices.Marshal.Copy(depthImage, 0, ptr, depthImage.Length);

        bitmap.UnlockBits(BitmapData);

        //Apply Filter
        blurFilter.ApplyInPlace(bitmap);

        //Copy Bitmap back to Image
        BitmapData = bitmap.LockBits(ImageBounds, Mode, Format);

        ptr = BitmapData.Scan0;
        System.Runtime.InteropServices.Marshal.Copy(ptr, depthImage, 0, depthImage.Length);

        bitmap.UnlockBits(BitmapData);
    }

}
