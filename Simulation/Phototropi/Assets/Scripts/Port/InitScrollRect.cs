using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitScrollRect : MonoBehaviour
{
    public int ID = 0;
    // Use this for initialization
    void Start()
    {
        COMPortSettings.ScrollViews.Insert(ID, (Text)GetComponent("Text"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
