using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableCube : MonoBehaviour
{
    public bool destroyYourself = false;


    private void OnTriggerEnter(Collider other)
    {
        if(destroyYourself)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject);
            }
        }
    }

}
