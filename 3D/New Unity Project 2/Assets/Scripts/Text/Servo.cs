using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Servo : MonoBehaviour
{

    public int ID = 0;
    public char Direktion = 'Y';

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
            if (Direktion == 'X' || Direktion == 'x')
        {
            transform.GetChild(0).GetComponent<Text>().text = "Winkel:" + (Main.Gelenk[ID].GetComponent<Gelenk_Parameter>().transform.eulerAngles.x).ToString();
        }
        if (Direktion == 'Y' || Direktion == 'y')
        {
            transform.GetChild(0).GetComponent<Text>().text = "Winkel:" + (Main.Gelenk[ID].GetComponent<Gelenk_Parameter>().transform.eulerAngles.y).ToString();
        }
        if (Direktion == 'Z' || Direktion == 'z')
        {
            transform.GetChild(0).GetComponent<Text>().text = "Winkel:" + (Main.Gelenk[ID].GetComponent<Gelenk_Parameter>().transform.eulerAngles.z).ToString();
        }
    }
}
