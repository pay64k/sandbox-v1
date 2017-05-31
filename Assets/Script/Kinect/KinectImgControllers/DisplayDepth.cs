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

    private bool _saved = true;

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
            UnityEngine.Color32[] depthImgConverted = convertDepthToColor(dw.depthImg);

            //Mean filter = new Mean();
            GaussianBlur filter = new GaussianBlur(4, 11);
            Bitmap image1 = new Bitmap(320,240);
            for (int Xcount = 0; Xcount < image1.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < image1.Height; Ycount++)
                {
                    System.Drawing.Color col = System.Drawing.Color.FromArgb(
                        depthImgConverted[Ycount*image1.Width + Xcount].a,
                        depthImgConverted[Ycount * image1.Width + Xcount].r,
                        depthImgConverted[Ycount * image1.Width + Xcount].g,
                        depthImgConverted[Ycount * image1.Width + Xcount].b
                        );

                    image1.SetPixel(Xcount, Ycount, col);
                }
            }
            if (!_saved)
            {
                image1.Save("image1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                //_saved = !_saved;

            }
            Bitmap image2 = filter.Apply(image1);

            Color32[] color32Tex = new Color32[image2.Width * image2.Height];

            for (int Xcount = 0; Xcount < image2.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < image2.Height; Ycount++)
                {
                    color32Tex[Ycount * image2.Width + Xcount] = new Color32(
                        image2.GetPixel(Xcount, Ycount).R,
                        image2.GetPixel(Xcount, Ycount).G,
                        image2.GetPixel(Xcount, Ycount).B,
                        image2.GetPixel(Xcount, Ycount).A);
                }
            }

            if (!_saved)
            {
                image2.Save("image2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                _saved = !_saved;
            }
            tex.SetPixels32(color32Tex);

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
