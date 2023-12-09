

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    private Level level;


    [SerializeField] public int id;


    private void Start()
    {
        level = GetComponentInParent<Level>();
    }


    private void Update()
    {
        if (level != null && transform.position.y < level.BORDER_Y)
        {
            Destroy(gameObject);
        }
    }




}

