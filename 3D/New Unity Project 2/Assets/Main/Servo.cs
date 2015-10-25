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
        transform.GetChild(1).GetComponent<Text>().text = (Main.Gelenk[ID].GetComponent<Gelenk_Parameter>().transform.localRotation.y*180).ToString();
    }
}
