using UnityEngine;
using System.Collections;
using MathNet.Filtering;
using System;

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

    // Use this for initialization
    void Start () {
		tex = new Texture2D(320,240,TextureFormat.ARGB32,false);

        GetComponent<Renderer>().material.mainTexture = tex;
        score = GetComponent<Score>();

        ScoreObject.SetActive(false);

        //blaFilter(new double[] { 1, 2, 3, 4 });
    }
	
	// Update is called once per frame
	void Update () {
        Renderer renderer = GetComponent<Renderer>();

        if (dw.pollDepth() && update)
		{
            var filterResult = blaFilter(dw.depthImg);

            //tex.SetPixels32(convertDepthToColor(dw.depthImg));
            tex.SetPixels32(convertDepthToColor(dw.depthImg));

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
        if (x <= minHeight)
            x = minHeight;
        if (x >= maxHeight)
            x = maxHeight;
        return Mathf.RoundToInt((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
    }

    float MapRange2(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    public short[] filter(short[] map) {

        short[] newMap = new short[map.Length];
        for (int i = 0; i < map.Length; i++)
        {
            //newMap[i] = 
        }
         
        return newMap;
    }


    public float[] blaFilter(short[] signal)
    {
        //double[] signal = (some 1d signal);
        float[] filter = { 0.25f, 0.25f, 0.25f, 0.25f }; // box-car filter
        float[] result = new float[signal.Length + filter.Length + 1];
        float[] resultShorter = new float[signal.Length];

        // Set result to zero:
        for (int i = 0; i < result.Length; i++) result[i] = 0;

        // Do convolution:
        for (int i = 0; i < signal.Length; i++)
            for (int j = 0; j < filter.Length; j++)
                result[i + j] = Mathf.RoundToInt(result[i + j] + signal[i] * filter[j]);

        for (int i = 0; i < result.Length - 5; i++)
        {
            try
            {
                resultShorter[i] = result[i];

            }
            catch(Exception e)
            {
                print(e);
            }

        }

        return resultShorter;
        //foreach (double item in result) print(item);
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
