using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Flying : MonoBehaviour
{
    public float controlSpeed = 0.000000005f;    // How fast turning controls work
    public float horizSensitivity = 2f;         // Horizontal sensistivity 
    public float vertSensitivity = 2f;          // Vertical sensistivity 
    private float turn = 0f;
    private float tilt = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()

    {
        turn += horizSensitivity * Input.GetAxis("Mouse X");
        tilt -= vertSensitivity * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(tilt, turn, 0.0f);
        //if statements to Check which button is pressed and let that determine how/where to move in space. 
        // Transform the position object to the forward position when key W,A,S or D is pressed

        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * Time.deltaTime * controlSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= transform.right * Time.deltaTime * controlSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= transform.forward * Time.deltaTime * controlSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * Time.deltaTime * controlSpeed;
        }
    }
}