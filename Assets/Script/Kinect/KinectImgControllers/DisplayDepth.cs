using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class DisplayDepth : MonoBehaviour {
	
	public DepthWrapper dw;

    private FileSaver fSaver = new FileSaver();

    private Texture2D tex;

    public float minHeight;
    public float maxHeight;

    // Use this for initialization
    void Start () {
		tex = new Texture2D(320,240,TextureFormat.ARGB32,false);

        GetComponent<Renderer>().material.mainTexture = tex;
	}
	
	// Update is called once per frame
	void Update () {
        Renderer renderer = GetComponent<Renderer>();
        if (dw.pollDepth())
		{
			tex.SetPixels32(convertDepthToColor(dw.depthImg));
            //tex.LoadRawTextureData(convertDepthToColor(dw.depthImg));
			//tex.SetPixels32(convertPlayersToCutout(dw.segmentations));
			tex.Apply(false);
            renderer.material.SetTexture("_MainTex", tex);
        }
        if (Input.GetKeyDown("c"))
        {
            fSaver.SaveDepthMap(dw.depthImg);
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
	
	private Color32[] convertPlayersToCutout(bool[,] players)
	{
		Color32[] img = new Color32[320*240];
		for (int pix = 0; pix < 320*240; pix++)
		{
			if(players[0,pix]|players[1,pix]|players[2,pix]|players[3,pix]|players[4,pix]|players[5,pix])
			{
				img[pix].a = (byte)255;
			} else {
				img[pix].a = (byte)0;
			}
		}
		return img;
	}

    int MapRange(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return Mathf.RoundToInt((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
    }
}
