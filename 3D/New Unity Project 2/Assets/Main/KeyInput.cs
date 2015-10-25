using UnityEngine;
using System.Collections;

public class KeyInput : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void G1PDown()
    {
        Main.Gelenk[1].GetComponent<Gelenk_Parameter>().RotateSpeed.y = 1;
    }

    public void G1MDown()
    {
        Main.Gelenk[1].GetComponent<Gelenk_Parameter>().RotateSpeed.y = -1;
    }

    public void G0PDown()
    {
        Main.Gelenk[0].GetComponent<Gelenk_Parameter>().RotateSpeed.y = 1;
    }

    public void G0MDown()
    {
        Main.Gelenk[0].GetComponent<Gelenk_Parameter>().RotateSpeed.y = -1;
    }

    public void G1PUp()
    {
        Main.Gelenk[1].GetComponent<Gelenk_Parameter>().RotateSpeed.y = 0;
    }

    public void G1MUp()
    {
        Main.Gelenk[1].GetComponent<Gelenk_Parameter>().RotateSpeed.y = 0;
    }

    public void G0PUp()
    {
        Main.Gelenk[0].GetComponent<Gelenk_Parameter>().RotateSpeed.y = 0;
    }

    public void G0MUp()
    {
        Main.Gelenk[0].GetComponent<Gelenk_Parameter>().RotateSpeed.y = 0;
    }
}
