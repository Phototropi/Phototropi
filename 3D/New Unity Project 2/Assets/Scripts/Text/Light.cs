using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Light : MonoBehaviour
{
    public int ID = 0;
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
                transform.GetChild(i).GetComponent<Text>().text = "Sensor " + i + ":" + COMport.getLight(i);
            else
                transform.GetChild(i).GetComponent<Text>().text = "Sensor " + i + ":" + 0;
        }
    }
}
