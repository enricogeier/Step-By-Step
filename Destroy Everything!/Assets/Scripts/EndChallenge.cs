
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChallenge : MonoBehaviour
{
    private bool activated = false;
    private Transform firstRow;
    private Transform secondRow;

    private Transform front;

    private bool wait = false;

    private Vector3 firstRowInitialPosition;
    private Vector3 secondRowInitialPosition;

    [SerializeField] private float wait_time;
    [SerializeField] private float localDistance;


    public void activate()
    {
        activated = true;
    }

    void doWait()
    {
        wait = false;
    }

    private void ResetCubes()
    {
        firstRow.transform.position = firstRowInitialPosition;
        secondRow.transform.position = secondRowInitialPosition;
        front = secondRow;
        wait = true;
        Invoke("doWait", wait_time);
    }

    private void Start()
    {
        firstRow = transform.Find("1st Row");
        secondRow = transform.Find("2nd Row");

        front = secondRow;
        firstRowInitialPosition = firstRow.transform.position;
        secondRowInitialPosition = secondRow.transform.position;

    }


    void Update()
    {
        if (activated && !wait)
        {

            if (front == secondRow)
            {
                if(firstRow.transform.localPosition.x + 4 > localDistance)
                {
                    ResetCubes();
                }
                else
                {

                    firstRow.transform.position = new Vector3(firstRow.transform.position.x + 4, firstRow.transform.position.y, firstRow.transform.position.z);
                    front = firstRow;
                    wait = true;
                    Invoke("doWait", wait_time);

                }
            }
            else
            {
                if(secondRow.transform.localPosition.x + 4 > localDistance)
                {
                    ResetCubes();
                }
                else
                {
                    secondRow.transform.position = new Vector3(secondRow.transform.position.x + 4, secondRow.transform.position.y, secondRow.transform.position.z);
                    front = secondRow;
                    wait = true;
                    Invoke("doWait", wait_time);
                }
            }
        }
    }
}



