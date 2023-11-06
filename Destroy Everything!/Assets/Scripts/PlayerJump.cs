using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private InputActionProperty jump_button;
    [SerializeField] private float jump_height = 3.0f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private LayerMask groundLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;
    private bool is_grabbing = false;

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }

    private void jump()
    {
        // 
        movement.y = Mathf.Sqrt(jump_height * -3.0f * gravity);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Calculate gravity based on the jump height and time it takes to reach the peak of the jump.
        gravity = -(2 * jump_height) / Mathf.Pow(jump_height / -Physics.gravity.y, 2);
    }

    // Update is called once per frame
    void Update()
    {
        bool is_grounded = IsGrounded();

        if(is_grounded)
        {
            // Reset movement.y when grounded.
            movement.y = 0.0f;

            if (jump_button.action.WasPressedThisFrame() && !is_grabbing)
            {
                // Calculate initial jump velocity to reach the desired jump height.
                movement.y = Mathf.Sqrt(2 * jump_height * -Physics.gravity.y);
            }
        }

        // Apply gravity to the character's vertical movement.
        movement.y += gravity * Time.deltaTime;

        // Move the character using the character controller.
        characterController.Move(movement * Time.deltaTime);

    }


    public void startGrabbing()
    {
        is_grabbing = true;
    }

    public void stopGrabbing()
    {
        is_grabbing = false;
    }


}


