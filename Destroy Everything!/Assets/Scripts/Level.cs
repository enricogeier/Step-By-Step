using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level: MonoBehaviour
{
    List<bool> table_list = new List<bool>();

    private Finish finish;
    

    [SerializeField] public int amount_of_tables;
    [SerializeField] public int BORDER_Y = -6;
    [SerializeField] public Vector3 spawn_position = Vector3.zero;


    public void open_next_level()
    {
        Debug.LogWarning("Next Level has been activated");

        finish.activate();
    }
    public void check_table_list()
    {
        int activated = 0;
        foreach(bool table in table_list)
        {
            if(table)
            {
                activated++;
            }
        }

        if(activated == amount_of_tables)
        {
            open_next_level();
        }
    }

    public void activate_table()
    {
        table_list.Add(true);
        check_table_list();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
