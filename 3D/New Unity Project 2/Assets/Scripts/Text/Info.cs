using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public int ID = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (COMport.isConnected())
            transform.GetChild(0).GetComponent<Text>().text = COMport.getInfo();
        else
            transform.GetChild(0).GetComponent<Text>().text = "Not Connected";
    }
}
