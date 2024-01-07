using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryCube : Platform
{

    private bool wait = false;


    [SerializeField] private float waitTime = 2.0f;

    private void afterWait()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!wait)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                wait = true;
               Invoke("afterWait", waitTime);
            
            }

        }

    }





}
