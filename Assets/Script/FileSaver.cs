﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSaver {

    private int fileIndexCounter = 0;
    public void SaveDepthMap(short[] map)
    {
        MonoBehaviour.print("written file no: " + fileIndexCounter.ToString());
        string[] foo = map.OfType<object>().Select(o => o.ToString()).ToArray();
        System.IO.File.WriteAllLines(@"Assets\HeightMaps\HeightMap" + fileIndexCounter + ".txt", foo);
        //System.IO.File.WriteAllLines(@"C:\Users\s127578\PycharmProjects\untitled\map", foo);
        fileIndexCounter++; 
    }

    public void saveCameraPosition(Vector3 position, float fov)
    {

        System.IO.File.WriteAllLines(@"Assets\CameraCalibration\positions_v1.txt", new string[2] { position.ToString("G4"), fov.ToString("G6") });
        MonoBehaviour.print("Saved camera: " + position.ToString("G4") + fov.ToString("G6"));
    }

    public ArrayList loadCameraPosition()
    {
        string[] lines = System.IO.File.ReadAllLines(@"Assets\CameraCalibration\positions_v1.txt");
        Vector3 position = StringToVector3(lines[0]);
        float fov = float.Parse(lines[1]);
        ArrayList list = new ArrayList();
        list.Add(position);
        list.Add(fov);
        MonoBehaviour.print("Loaded camera: " + position.ToString("G6") + fov.ToString("G6"));
        return list;
    }

    public void SaveBornholm(short[] map)
    {
        //MonoBehaviour.print("Saving to Bornholm directory");
        string[] foo = map.OfType<object>().Select(o => o.ToString()).ToArray();
        System.IO.File.WriteAllLines(@"C:\MatchBornholm\HeightMap\HeightMap.txt", foo);
    }

    public string ReadScore()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\MatchBornholm\Results\Score.txt");
        return lines[0];

    }

    //----------------------------------------------------


    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }

    public static Quaternion StringToQuanterion(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Quaternion result = new Quaternion(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]),
            float.Parse(sArray[3]));
        return result;
    }

    public string[] Vector3ToString(Vector3[] list)
    {
        string[] pos = new string[4];
        for (int i = 0; i < 4; i++)
        {
            pos[i] = list[i].ToString("G4");
        }
        return pos;
    }


}
