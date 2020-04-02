
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float horizSensitivity = 2f;         // Horizontal sensistivity 
    public float vertSensitivity = 2f;          // Vertical sensistivity 
    private float turn = 0f;
    private float tilt = 0f;
    public Transform target;

    public Vector3 offset;
    private void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);
        turn += horizSensitivity * Input.GetAxis("Mouse X");

        tilt -= vertSensitivity * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(tilt, turn, 0.0f);
    }
}
