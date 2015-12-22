using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Servo : MonoBehaviour
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
            transform.GetChild(0).GetComponent<Text>().text = "Winkel:" + COMport.getServoAngle(ID);
        else
            transform.GetChild(0).GetComponent<Text>().text = "Winkel:" + (Main.Gelenk[ID].GetComponent<Gelenk_Parameter>().transform.localEulerAngles.y).ToString();
    }
}
