using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO.Ports;

public class COMPortSettings : MonoBehaviour
{

    public static List<Dropdown> Dropdowns = new List<Dropdown>();
    public static List<Text> ScrollViews = new List<Text>();
    public static List<string> PortNames = new List<string>();
    private static string port = "";
    private static bool init = true;

    // Use this for initialization
    void Start()
    {
        COMport.DataReceived += DataReceived;
    }

    private void DataReceived(string data)
    {
        ScrollViews[0].text = data;
    }

    private static void Init()
    {
        PortNames.Clear();
        PortNames.AddRange(COMport.getPortNames());
        Dropdowns[1].options.Clear();
        port = PortNames[0];
        foreach (string item in PortNames)
        {
            Dropdowns[1].options.Add(new Dropdown.OptionData(item));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (init&& Dropdowns.Count>0)
        {
            Init();
            init = false;
        }
        COMport.ReceiveData();
    }

    public void ConnectBTN(int ID)
    {
        switch (Dropdowns[ID].value)
        {
            case 0: COMport.Disconnect(); break;
            case 1: COMport.Connect(port); break;
            default: break;
        }
    }

    public void COMBTN(int ID)
    {
        port = PortNames[Dropdowns[ID].value];
    }
}
