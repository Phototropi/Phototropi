using UnityEngine;
using System.Collections;

public class Arm_Parameter : MonoBehaviour
{

    Parameter.Arm parameter = new Parameter.Arm();

    // Use this for initialization
    void Start()
    {
        parameter.Masse = 1;
        parameter.Schwerpunkt = 1;
        parameter.Trägheitstensor = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
