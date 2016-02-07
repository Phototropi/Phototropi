using UnityEngine;
using System.Collections;

public class Gelenk_Parameter : MonoBehaviour
{
    public int ID = 0;
    public Vector3 NullWinkel = new Vector3(0, 0, 0);
    public Vector3 LimitWinkel = new Vector3(0, 0, 0);
    public bool RotationsBewegung = true;
    public Vector3 RotateSpeed = new Vector3(0, 0, 0);
    public Vector3 RotateAngles = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        Main.Gelenk.Add(this.transform);
        RotateAngles = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!COMport.isConnected())
        {
            transform.Rotate(RotateSpeed);
            RotateAngles = transform.eulerAngles;
        }
        transform.eulerAngles = RotateAngles;
    }
}
