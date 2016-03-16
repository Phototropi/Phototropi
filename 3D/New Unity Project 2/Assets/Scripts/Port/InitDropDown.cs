using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitDropDown : MonoBehaviour
{
    public int ID = 0;

    // Use this for initialization
    void Start()
    {
        COMPortSettings.Dropdowns.Insert(ID, (Dropdown)GetComponent("Dropdown"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
