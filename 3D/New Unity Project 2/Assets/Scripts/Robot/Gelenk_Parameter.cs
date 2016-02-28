using UnityEngine;
using System.Collections;
using System;

public class Gelenk_Parameter : MonoBehaviour
{
    public int ID = 0;
    public Vector3 NullWinkel = new Vector3(0, 0, 0);
    public Vector3 LimitWinkel = new Vector3(0, 0, 0);
    public bool RotationsBewegung = true;
    public float RotateSpeed = 0;
    public Vector3 RotateVector = new Vector3(0, 0, 0);
    public Vector3 RotateAngles = new Vector3(0, 0, 0);
    public char Direktion = 'Y';
    private double Angle = 0;
    private double TempAngle = 0;
    private double OldAngle = 0;
    private int IntervalCounter = 0;
    private int Interval = 1;
    private DateTime time = DateTime.Now;

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
            if (Direktion == 'X' || Direktion == 'x')
            {
                RotateVector.x = RotateSpeed;
            }
            if (Direktion == 'Y' || Direktion == 'y')
            {
                RotateVector.y = RotateSpeed;
            }
            if (Direktion == 'Z' || Direktion == 'z')
            {
                RotateVector.z = RotateSpeed;
            }
            transform.Rotate(RotateVector);
            RotateAngles = transform.localEulerAngles;
        }
        else
        {
            if (Direktion == 'X' || Direktion == 'x')
            {
                RotateAngles.x = (float)Angle;
            }
            if (Direktion == 'Y' || Direktion == 'y')
            {
                RotateAngles.y = (float)Angle;
            }
            if (Direktion == 'Z' || Direktion == 'z')
            {
                RotateAngles.z = (float)Angle;
            }
            double schritt = (COMport.getServoAngle(ID) - OldAngle) / 12;//Interval;

            //if (schritt > 0)
            //    if (Angle + schritt >= COMport.getServoAngle(ID))
            //        Angle = COMport.getServoAngle(ID);
            //    else
            //        Angle += schritt;

            //if (schritt < 0)
            //    if (Angle + schritt <= COMport.getServoAngle(ID))
            //        Angle = COMport.getServoAngle(ID);
            //    else
                    Angle += schritt;

            //if (Math.Round(Angle, 4) == Math.Round(COMport.getServoAngle(ID)))
            //    Angle = COMport.getServoAngle(ID);

            if (TempAngle != COMport.getServoAngle(ID))
            {
                Interval = IntervalCounter;
                IntervalCounter = 0;
                OldAngle = TempAngle;
                TempAngle = COMport.getServoAngle(ID);
            }
            IntervalCounter++;
            transform.localEulerAngles = RotateAngles;
        }
    }
}
