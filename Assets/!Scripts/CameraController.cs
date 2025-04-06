using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public Vector2 sensitivity = new Vector2(120f, 80f);
    public float distance = 4f;
    public float height = 2f;
    public float rotationSmoothTime = 0.05f;

    private float yaw;
    private float pitch;
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        yaw += mouseDelta.x * sensitivity.x * Time.deltaTime;
        pitch -= mouseDelta.y * sensitivity.y * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -30f, 60f);

        Vector3 targetRotation = new Vector3(pitch, yaw);
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

        Quaternion rotation = Quaternion.Euler(currentRotation);
        Vector3 targetPosition = target.position - rotation * Vector3.forward * distance + Vector3.up * height;

        transform.position = targetPosition;
        transform.rotation = rotation;
    }
}