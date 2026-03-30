using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    public float sensitivity = 2f;
    private float rotX = 0f;
    private float rotY = 0f;
    private bool isLooking = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Press Alt to toggle between look mode and cursor mode
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isLooking = !isLooking;
            Cursor.lockState = isLooking ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isLooking;
        }

        if (isLooking)
        {
            rotX += Input.GetAxis("Mouse X") * sensitivity;
            rotY -= Input.GetAxis("Mouse Y") * sensitivity;
            rotY = Mathf.Clamp(rotY, -90f, 90f);
            transform.rotation = Quaternion.Euler(rotY, rotX, 0f);
        }
    }
}