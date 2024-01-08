using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevel : Level
{

    private Vector3[] spawn_positions = { new Vector3(8.73f, 0.15f, 23.19f), new Vector3(8.73f, 0.15f, 39.19f), new Vector3(8.73f, 0.15f, 67.18f) };

    GameObject firstChallenge;
    GameObject secondChallenge;
    GameObject thirdChallenge;
    GameObject fourthChallenge;




    int current_index = 0;

    private void Start()
    {
        firstChallenge = transform.Find("FirstChallenge").gameObject;
        secondChallenge = transform.Find("SecondChallenge").gameObject;
        thirdChallenge = transform.Find("ThirdChallenge").gameObject;
        fourthChallenge = transform.Find("FourthChallenge").gameObject;



        firstChallenge.SetActive(true);
        secondChallenge.SetActive(false);
        thirdChallenge.SetActive(false);
        fourthChallenge.SetActive(false);


    }

    public override void activate_table()
    {
        if(current_index < amount_of_tables)
        {
            
            switch(current_index)
            {
                case 0:
                    {
                        firstChallenge.SetActive(false);
                        secondChallenge.SetActive(true);
                        spawn_position = spawn_positions[current_index];
                        break;
                    }
                    
                case 1:
                    {
                        secondChallenge.SetActive(false);
                        thirdChallenge.SetActive(true);
                        spawn_position = spawn_positions[current_index];
                        break;
                    }
                    
                case 2:
                    {
                        thirdChallenge.SetActive(false);
                        fourthChallenge.SetActive(true);
                        spawn_position = spawn_positions[current_index];
                        break;
                    }
                    
            }


            ++current_index;

        }
    }


}
