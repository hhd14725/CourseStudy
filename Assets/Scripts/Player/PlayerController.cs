using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    public float jumpStaminaCost;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;
    private int jumpCount = 0;


    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    public bool canLook = true;

    private Vector2 mouseDelta;
    public Action inventory;

    private Rigidbody _rigidbody;
    private PlayerBuffHandler _buffHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _buffHandler = GetComponent<PlayerBuffHandler>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Move();
        jumpCount = 0;
        Debug.Log(_rigidbody.velocity);
    }

    private void LateUpdate()
    {
        if(canLook)
        {
            CameraLook();
        }
        
    }
    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;

        dir *= moveSpeed;
     
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
   
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed )
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        int allowExtraJumps = (_buffHandler != null) ? _buffHandler.MaxExtraJumps : 0;
        if(context.phase == InputActionPhase.Started && (isGrounded() || jumpCount < allowExtraJumps))
        {
            if(CharacterManager.Instance.Player.condition.UseStamina(jumpStaminaCost))
            {
                _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                jumpCount++;
            }
            
        }
    }

    bool isGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (Vector3.forward*0.2f) +(Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-Vector3.forward*0.2f) +(Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (Vector3.right*0.2f) +(Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-Vector3.right*0.2f) +(Vector3.up * 0.01f), Vector3.down)
       
        };
        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i],0.1f, groundLayerMask))
            {
                return true;
            }
           
        }
        return false;
    }

    public void OnInventoryInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}
