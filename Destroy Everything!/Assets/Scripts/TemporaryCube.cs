using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryCube : Platform
{

    private bool destroyWait = false;

    private BoxCollider[] boxColliders;
    private Renderer meshRenderer;


    [SerializeField] private float untilDestroyTime = 2.0f;
    [SerializeField] private float respawnTime = 5.0f;

   

    private void AfterDestroyTime()
    {
     
        meshRenderer.enabled = false;

        
        foreach(BoxCollider collider in boxColliders)
        {
            collider.enabled = false;
            collider.enabled = false;
        }


        Invoke("AfterRespawnTime", respawnTime);

    }


    private void AfterRespawnTime()
    {
        meshRenderer.enabled = true;


        foreach (BoxCollider collider in boxColliders)
        {
            collider.enabled = true;
            collider.enabled = true;
        }


        destroyWait = false;
    }


    private void Start()
    {
        boxColliders = GetComponents<BoxCollider>();
        meshRenderer = GetComponent<Renderer>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if(!destroyWait)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                destroyWait = true;
                Invoke("AfterDestroyTime", untilDestroyTime);
                       
            }

        }

    }






}
