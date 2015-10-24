using UnityEngine;
using System.Collections;

public class Gelenk_Parameter : MonoBehaviour
{
    public int ID = 0;
    public float typ = 1;
    public float Reibungskoeffizient = 1;
    public float Diff = 1;
    public bool RotationsBewegung = true;
    public Vector3 Rotate = new Vector3(0, 0, 0);
    public Vector3 RotateDirection = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        Main.Gelenk.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (RotationsBewegung)
        { transform.Rotate(RotateDirection); }
        else
        { transform.eulerAngles = Rotate; }
    }
}
