using UnityEngine;
using System.Collections;
using System;
using AForge.Imaging.Filters;
using System.Drawing;

[RequireComponent(typeof(Renderer))]
public class DisplayDepth : MonoBehaviour {
	
	public DepthWrapper dw;

    public GameObject ScoreObject;

    public float ScoreDisplayTime = 5f; 

    private FileSaver fSaver = new FileSaver();
    private Score score;

    private bool update = true;
    
    private Texture2D tex;

    public float minHeight;
    public float maxHeight;

    public float alpha = 0.5f;


    private float[] previous_data;

    void Start () {
		tex = new Texture2D(320,240,TextureFormat.ARGB32,false);
        tex.filterMode = FilterMode.Bilinear;
        tex.Apply();

        previous_data = new float[320*240];
        for (int i=0;i< previous_data.Length;i++)
        {
            previous_data[i] = 0f;
        }
        GetComponent<Renderer>().material.mainTexture = tex;

        score = GetComponent<Score>();
        ScoreObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Renderer renderer = GetComponent<Renderer>();

        if (dw.pollDepth() && update)
		{

            short[] current_data = dw.depthImg;
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

            tex.SetPixels32(convertDepthToColor(previous_data_mapped));
                        
            tex.Apply(false);
            renderer.material.SetTexture("_MainTex", tex);
        }
        if (Input.GetKeyDown("c"))
            fSaver.SaveDepthMap(dw.depthImg);

        if (Input.GetKeyDown("f1"))
            StartCoroutine(ShowScore());
        
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
	
	//private Color32[] convertPlayersToCutout(bool[,] players)
	//{
	//	Color32[] img = new Color32[320*240];
	//	for (int pix = 0; pix < 320*240; pix++)
	//	{
	//		if(players[0,pix]|players[1,pix]|players[2,pix]|players[3,pix]|players[4,pix]|players[5,pix])
	//		{
	//			img[pix].a = (byte)255;
	//		} else {
	//			img[pix].a = (byte)0;
	//		}
	//	}
	//	return img;
	//}

    int MapRange(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return Mathf.RoundToInt((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
    }

    float MapRange2(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    IEnumerator ShowScore()
    {
        update = !update;
        fSaver.SaveBornholm(dw.depthImg);
        score.SendDepthMap(dw.depthImg);
        var result = fSaver.ReadScore();
        print("RESULT: " + float.Parse(result));
        ScoreObject.SetActive(true);
        float mappedResult = MapRange2(float.Parse(result), 0.72f, 0.92f, 0.1f, 1f);
        print("MAPPED: " + mappedResult.ToString());
        ScoreObject.GetComponentInChildren<TextMesh>().text = (mappedResult * 100).ToString("F2") + "%";
        yield return new WaitForSeconds(ScoreDisplayTime);
        ScoreObject.SetActive(false);
        update = !update;
    }

}
