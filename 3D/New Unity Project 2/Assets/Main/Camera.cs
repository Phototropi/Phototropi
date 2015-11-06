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

        if (KeyInput.isForward()) dir.z += 1;
        if (KeyInput.isBack()) dir.z -= 1;
        if (KeyInput.isRight()) dir.x += 1;
        if (KeyInput.isLeft()) dir.x -= 1;
        if (KeyInput.isUp()) dir.y += 1;
        if (KeyInput.isDown()) dir.y -= 1;

        if (KeyInput.isMousDown())
            down = true;
        if (KeyInput.isMouseUp())
            down = false;

        if (down)
        {
            float newRotationX = KeyInput.RotateCamerainXPos(transform.localEulerAngles.y);
            float newRotationY = KeyInput.RotateCamerainYPos(transform.localEulerAngles.x);

            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0);
        }

        dir.Normalize();

        transform.Translate(dir * speed * Time.deltaTime);
        transform.Translate(dir * speed * Time.deltaTime);

    }

}
