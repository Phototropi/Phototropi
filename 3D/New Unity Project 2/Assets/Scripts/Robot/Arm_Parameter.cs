using UnityEngine;
using System.Collections;

public class Arm_Parameter : MonoBehaviour
{

    public float Masse = 1;
    public float Schwerpunkt = 1;
    public float Trägheitstensor = 1;

    // Use this for initialization
    void Start()
    {
        Main.Arm.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
