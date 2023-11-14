using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{
    [SerializeField] GameObject sphereObject;
    [SerializeField] private int activation_id;

    public void load_sphere()
    {
        if(sphereObject != null)
        {
            // quaternion.identity = default rotation
            GameObject sphereInstance = Instantiate(sphereObject, transform.Find("SpherePosition").transform.position, Quaternion.identity);
            sphereInstance.transform.SetParent(transform);

            Sphere sphere = sphereInstance.GetComponent<Sphere>();
            sphere.id = activation_id;
        }
        else
        {
            Debug.LogError("Sphere could not be created because the prefab is missing");
        }
    }
}
