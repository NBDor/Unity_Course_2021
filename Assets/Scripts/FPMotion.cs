using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMotion : MonoBehaviour
{
    public GameObject playerCamera; // needs to be connected to real object in Unity

    private CharacterController controller;
    private float speed = 0.5f;
    private float rx =0f, ry;
    private float angularSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // gets player controller
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;

        // mouse to rotate player
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        // use Clamp function to limit the sight angles 
        rx = Mathf.Clamp(rx, -45, 45);
        // runs only on playerCamera
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed;
        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);
        // runs on player 
        transform.localEulerAngles = new Vector3(0,ry,0); // sets new orientation of player
        // keyboard
        dx = Input.GetAxis("Horizontal") * speed; // Horizontal means 'A' or 'D'
        dz = Input.GetAxis("Vertical") * speed; // Vertical means 'W' or 'S'
        
        Vector3 motion = new Vector3(dx, 0, dz); // in local coordinates

        motion = transform.TransformDirection(motion); // in Global coordinates
        controller.Move(motion);

      

        // example of basic motion to Forward direction(z-axis) 
        /*

                        transform.SetPositionAndRotation(
                            new Vector3(transform.position.x, transform.position.y, transform.position.z + speed),
                            transform.rotation);
        */
        // another example of basic motion to Forward direction(z-axis)
        //transform.Translate(new Vector3(0, 0, speed));
    }
}
