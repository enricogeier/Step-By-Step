using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionProperty jump_button;
    [SerializeField] private float jump_height = 3.0f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private LayerMask teleport_back;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    private Level level;


    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.5f, groundLayers);
    }


    // Start is called before the first frame update
    void Start()
    {
        level = GetComponentInParent<Level>();
        characterController.Move(level.spawn_position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < level.BORDER_Y)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Teleport Back");
            movement.y = 0.0f;
            characterController.Move(level.spawn_position - transform.position);
            this.gameObject.layer = LayerMask.NameToLayer("Player");
        }
        else
        {


            bool is_grounded = IsGrounded();

            if (is_grounded)
            {
                // Reset movement.y when grounded.
                //movement.y = 0.0f;

                if (jump_button.action.WasPressedThisFrame())
                {
                    // Calculate initial jump velocity to reach the desired jump height.
                    // value of Physics.gravity is Vector3.DOWN
                    movement.y = Mathf.Sqrt(2 * jump_height * -Physics.gravity.y);
                }
            }

            // Apply gravity to the character's vertical movement.
            movement.y += gravity * Time.deltaTime;

            // Move the character using the character controller.
            characterController.Move(movement * Time.deltaTime);

        }


    }


}


