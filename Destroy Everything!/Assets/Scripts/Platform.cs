using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private Vector3 startPosition;

    [SerializeField] private float rotateXVelocity = 0.0f;
    [SerializeField] private float rotateYVelocity = 0.0f;
    [SerializeField] private float rotateZVelocity = 0.0f;

    [SerializeField] private float moveXVelocity = 0.0f;
    [SerializeField] private float moveYVelocity = 0.0f;
    [SerializeField] private float moveZVelocity = 0.0f;

    [SerializeField] private float moveDistance = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotateXVelocity, rotateYVelocity, rotateZVelocity);
        
        // TODO: implement object movement


    }
}
