using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger_Manager : MonoBehaviour
{
    public GameObject[] npcs;
    public bool followHead;
    void Start()
    {
        npcs = GameObject.FindGameObjectsWithTag("passenger");
    }
    
    void Update()
    {
        if (followHead)
        {
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].GetComponent<LookAtPlayer>().lookAt = true;
            }
        } 
        else
        {
            for (int i = 0; i < npcs.Length; i++)
            {
                npcs[i].GetComponent<LookAtPlayer>().lookAt = false;
            }
        }
    }

    void HeadFollow()
    {
        //Deze functie aanroepen vanuit quest manager om hoofdturn te toggelen
        //Code uit Update hierheen zetten voor optimalisation
    }
}
