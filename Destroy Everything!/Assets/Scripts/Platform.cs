using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour

{

    private Vector3 startPosition;
    private bool playerOnPlatform = false;

    private Vector3 lastRotation = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 deltaRotation;

    private Vector3 lastPosition = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 deltaPosition;

    private bool wait = false;




    [SerializeField] private GameObject player;
    [SerializeField] private bool rotateX = false;
    [SerializeField] private bool rotateY = false;
    [SerializeField] private bool rotateZ = false;

    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float rotationDistance = 0.0f; // default: 10.0f
    [SerializeField] private float moveDistance = 0.0f;
    [SerializeField] private float wait_time;



    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger == false) // false new
        {
            UnityEngine.Debug.Log("ON Trigger betreten");
            other.transform.SetParent(transform);
        }
        else { UnityEngine.Debug.Log("fuck"); }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            UnityEngine.Debug.Log("playeronPlatform auf true gesetzt");
            playerOnPlatform = true;
        }
        else { UnityEngine.Debug.Log("fuck2"); }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerOnPlatform = false;
        }
    }

    private void afterWait()
    {
        wait = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        if (rotateX && (rotateY || rotateZ) || rotateY && rotateZ)
        {
            rotateX = false;
            rotateY = false;
            rotateZ = false;

            Debug.LogError("Platform can not rotate on two axis!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (rotateX)
        {
            gameObject.transform.Rotate(rotationDistance * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (rotateY)
        {
            gameObject.transform.Rotate(0.0f, rotationDistance * Time.deltaTime, 0.0f);
        }
        else if (rotateZ)
        {
            gameObject.transform.Rotate(0.0f, 0.0f, rotationDistance * Time.deltaTime);
        }

        deltaRotation = transform.rotation.eulerAngles - lastRotation;

        if (!wait)
        {

            gameObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            deltaPosition = transform.position - lastPosition;

            if (Vector3.Distance(gameObject.transform.position, startPosition) > moveDistance)
            {
                wait = true;
                Invoke("afterWait", wait_time);

                moveDirection *= -1;
                startPosition = gameObject.transform.position;

            }

        }

        if (!wait)
        {
            // Check
            // Player 
            if (playerOnPlatform && player != null)
            {
                Debug.LogWarning("Player on Platform true");
                Vector3 platformMovement = transform.position - lastPosition;
                player.transform.position += platformMovement;
                lastPosition = transform.position;

                //Vector3 deltaPosition = transform.position - startPosition;
                //player.position += deltaPosition;
                //player.position += deltaPosition;
                //player.GetComponent<CharacterController>().transform.position += new Vector3(deltaPosition.x, 0.0f, deltaPosition.y);
                //player.GetComponent<CharacterController>().Move(moveDirection * moveSpeed * Time.deltaTime);



            }

            lastPosition = transform.position;

        }

        lastRotation = transform.rotation.eulerAngles;




    }
}
