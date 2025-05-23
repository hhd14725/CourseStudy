using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Distance & Height")]
    [Tooltip("Distance from the target")]
    public float distance = 5f;
    [Tooltip("Height above the target")]
    public float height = 2f;

    [Header("Collision")]
    public LayerMask collisionMask;
    public float collisionOffset = 0.3f;

    [Header("Rotation")]
    public float yawSpeed = 120f;
    public float pitchSpeed = 80f;
    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float yaw;
    private float pitch;
    private Vector2 lookInput;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    private void LateUpdate()
    {
        yaw += lookInput.x * yawSpeed * Time.deltaTime;
        pitch -= lookInput.y * pitchSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + Vector3.up * height + rotation * Vector3.back * distance;

        Vector3 castOrigin = target.position + Vector3.up * height;
        Vector3 direction = (desiredPosition - castOrigin).normalized;
        float maxDist = Vector3.Distance(castOrigin, desiredPosition);

        if(Physics.SphereCast(castOrigin, 0.3f, direction, out RaycastHit hit, maxDist, collisionMask))
        {
            desiredPosition = hit.point + hit.normal * collisionOffset;
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, 10f* Time.deltaTime);
        target.rotation = Quaternion.Euler(0, yaw, 0);
        transform.rotation = rotation;
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }


}
