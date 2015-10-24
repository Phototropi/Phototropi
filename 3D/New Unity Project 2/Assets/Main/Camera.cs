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

        if (Input.GetKey(KeyCode.W)) dir.z += 1;
        if (Input.GetKey(KeyCode.S)) dir.z -= 1;
        if (Input.GetKey(KeyCode.D)) dir.x += 1;
        if (Input.GetKey(KeyCode.A)) dir.x -= 1;
        if (Input.GetKey(KeyCode.R)) dir.y += 1;
        if (Input.GetKey(KeyCode.F)) dir.y -= 1;

        if (Input.GetMouseButtonDown(0))
            down = true;
        if (Input.GetMouseButtonUp(0))
            down = false;

        if (down)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y");

            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0);
        }

        dir.Normalize();

        transform.Translate(dir * speed * Time.deltaTime);
        transform.Translate(dir * speed * Time.deltaTime);

    }
}
