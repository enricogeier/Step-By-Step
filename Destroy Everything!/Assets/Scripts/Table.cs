using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Table : MonoBehaviour
{
    private bool activated = false;
    private Level level;


    [SerializeField] public int id;



    private void OnTriggerEnter(Collider other)
    {

        Sphere sphere = other.gameObject.GetComponent<Sphere>();
        if (sphere != null)
        {
            if (sphere.id == id && !activated)
            {
                activated = true;

                // TODO: shader for table instead
                GetComponent<MeshRenderer>().material.color = Color.white;

                level.activate_table();

            }
            else
            {
                Destroy(other.gameObject);
            }
        }

    }

    private void Start()
    {
        level = GetComponentInParent<Level>();

    }




}