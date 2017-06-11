using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class RunScoreExe : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
        
	}

    public void SendDepthMap(short[] depthMap)
    {
        //print("Starting exe");
        string exeFilePath = @"C:\MatchBornholm\ARRegistration.EXE";
        try
        {
            Process myProcess = new Process();
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;

            myProcess.StartInfo.FileName = exeFilePath; //"C:\\Windows\\system32\\cmd.exe";

            //myProcess.EnableRaisingEvents = true;
            //print(myProcess.StartInfo.Arguments);
            myProcess.Start();

            myProcess.WaitForExit();

            //int ExitCode = myProcess.ExitCode;
            //print("Exit code: " + ExitCode.ToString());
        }
        catch (Exception e)
        {
            print(e);
        }
    }

}
