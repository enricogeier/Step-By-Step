using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



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

