using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoCubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform cube1Transform = transform.Find("D1");
        Transform cube2Transform = transform.Find("D2");

       
        DestroyableCube cube1 = cube1Transform.GetComponent<DestroyableCube>();
        DestroyableCube cube2 = cube2Transform.GetComponent<DestroyableCube>();

        int seed = GetInstanceID() ^ (int)System.DateTime.Now.Ticks;
        UnityEngine.Random.InitState(seed);

        if(UnityEngine.Random.Range(0, 2) == 1)
        {
            cube1.destroyYourself = true;
        }
        else
        {
            cube2.destroyYourself = true;
        }
        
    
    
    }

  
}
