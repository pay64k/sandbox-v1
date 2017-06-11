using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialManager : MonoBehaviour {

    private SerialPort portStream;

    public string ArduinoComPortName;
    private bool eval = false;

    void Start () {
        OpenArduinoPort();
    }
	
	void Update () {
        try
        {
            string serialRead = portStream.ReadLine();
            //print(serialRead);
            if (serialRead.Equals("eval"))
                eval = true;
        }
        catch (System.Exception ex)
        {
            eval = false; //when port has not received any data
            ex.ToString(); // so we don't get warnings 
        }
    }

    private void OpenArduinoPort()
    {
        portStream = new SerialPort(ArduinoComPortName, 9600);
        portStream.ReadTimeout = 10;
        portStream.Open();
    }

    public bool CheckButton()
    {
        return eval;
    }

}
