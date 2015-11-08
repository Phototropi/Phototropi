using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{

    public float speed = 10;
    private bool down = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3();

        dir.x = KeyInput.Horizontal();
        dir.y = KeyInput.Depth();
        dir.z = KeyInput.Vertical();

        if (KeyInput.isMousDown())
            down = true;
        if (KeyInput.isMouseUp())
            down = false;

        if (down)
        {
            float newRotationX = KeyInput.RotateCamerainXPos(transform.localEulerAngles.x);
            float newRotationY = KeyInput.RotateCamerainYPos(transform.localEulerAngles.y);

            transform.localEulerAngles = new Vector3(newRotationX, newRotationY, 0);
        }
        else
        {
            //game pad rotate
            transform.localEulerAngles = new Vector3(KeyInput.CamRotationV(transform.localEulerAngles.x), KeyInput.CamRotationH(transform.localEulerAngles.y), 0);
        }
        dir.Normalize();

        transform.Translate(dir * speed * Time.deltaTime);
        transform.Translate(dir * speed * Time.deltaTime);

    }

}
