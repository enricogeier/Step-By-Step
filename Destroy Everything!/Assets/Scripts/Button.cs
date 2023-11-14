using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    enum State
    {
        PRESSED, NOT_PRESSED
    }




    private float button_start_y;
    private LayerMask hands;
    private State state;
    private ButtonSystem buttonSystem;



    [SerializeField] private float button_pressed_y_offset = 0.1f;
    [SerializeField] private float button_sleep_time = 3.0f;
    


    private void Start()
    {
        button_start_y = transform.position.y;
        hands = LayerMask.NameToLayer("Default");
        state = State.NOT_PRESSED;
        buttonSystem = GetComponentInParent<ButtonSystem>();

    }

    private void OnTriggerEnter(Collider other)
    {
            
        if(other.gameObject.layer == hands && state == State.NOT_PRESSED)
        {
            state = State.PRESSED;
            transform.position = new Vector3(transform.position.x, transform.position.y - button_pressed_y_offset, transform.position.z);

            // execute code which should happen after button has been pressed

            buttonSystem.load_sphere();

            // sleep button_sleep_time, Invoke instead of yield because OnTriggerEnter is not a coroutine
            Invoke("go_up", button_sleep_time);






        }

    
    
    
    }

    // function which is executed after delay
    private void go_up()
    {
        transform.position = new Vector3(transform.position.x, button_start_y, transform.position.z);
        state = State.NOT_PRESSED;
    }










    private void Update()
    {
    }




}
