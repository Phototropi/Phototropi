using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Light : MonoBehaviour
{
    public int ID = 0;
    private string[] name = {
        "Center",
        "Top",
        "Bottom",
        "Left",
        "Right",
    };
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (COMport.isConnected())
                transform.GetChild(i).GetComponent<Text>().text = name[i] + ": " + COMport.getLight(i);
            else
                transform.GetChild(i).GetComponent<Text>().text = name[i] + ": " + 0;
        }
    }
}
