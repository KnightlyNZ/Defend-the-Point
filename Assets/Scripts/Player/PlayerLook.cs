using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera playerCamera;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    private float xRotation = 0f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x * Time.deltaTime * xSensitivity;
        float mouseY = input.y * Time.deltaTime * ySensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
