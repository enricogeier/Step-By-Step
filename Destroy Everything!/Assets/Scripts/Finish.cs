using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private EndChallenge endChallenge;

    public void activate()
    {
        endChallenge.activate();
    }

    private void OnTriggerEnter(Collider other)
    {
        // start next level



    }


    // Start is called before the first frame update
    void Start()
    {
        endChallenge = GetComponentInChildren<EndChallenge>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

