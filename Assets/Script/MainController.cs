using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainController : MonoBehaviour {

    public DepthWrapper dw;
    public GameObject scoreObject;
    public SerialManager serialManager;
    public DisplayDepth planeKinectV1;
    public float ScoreDisplayTime = 5f;
    public TextAsset ranksFile;

    private FileSaver fSaver = new FileSaver();
    private RunScoreExe scoreExe;
    private string[] ranks;

    // Use this for initialization
    void Start () {
        //scoreExe = GetComponent<RunScoreExe>();
        scoreExe = new RunScoreExe();
        scoreObject.SetActive(false);
        ranks = readRanksFile(ranksFile);
    }
	
	// Update is called once per frame
	void Update () {

        if (serialManager.CheckButton())
        {
            //print("pressed");
            StartCoroutine(ShowScore());
        }

        if (Input.GetKeyDown("f"))
            planeKinectV1.enableFiltering = !planeKinectV1.enableFiltering;

       if (Input.GetKeyDown("c"))
            fSaver.SaveDepthMap(dw.depthImg);
    }

    IEnumerator ShowScore()
    {
        planeKinectV1.disableMapUpdate();
        fSaver.SaveBornholm(dw.depthImg);
        scoreExe.SendDepthMap(dw.depthImg);
        var result = fSaver.ReadScore();
        //var result = "0.72";
        float mappedResult = CalculatePercentage(float.Parse(result), 0.72f, 0.92f, 0.1f, 1f);
        setTextInChild(scoreObject, "ScoreText", (mappedResult).ToString("F2") + "%");
        setTextInChild(scoreObject, "RankText", getRank(mappedResult));
        scoreObject.SetActive(true);
        yield return new WaitForSeconds(ScoreDisplayTime);
        scoreObject.SetActive(false);
        planeKinectV1.enableMapUpdate();
    }

    float CalculatePercentage(float x, float in_min, float in_max, float out_min, float out_max)
    {
        var result = (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        if (result < 0)
            result = 0;
        if (result > 1)
            result = 1;
        //print(result * 100);
        return result * 100 ;
    }

    private string[] readRanksFile(TextAsset file)
    {
        string[] lines = file.text.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        return lines;
    }

    private string getRank(float score)
    {
        float interval = 100f / ranks.Length;
        int resultRank = (int)((score - 1) / interval);
        return  ranks[resultRank];
    }

    private void setTextInChild(GameObject parent, string childName, string text)
    {
        TextMesh[] texts =  parent.GetComponentsInChildren<TextMesh>();
        foreach(TextMesh mesh in texts)
        {
            if (mesh.name.Equals(childName))
                mesh.text = text;
        }
    }

}
