using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaMariaKoekoek : MonoBehaviour
{
    // Start is called before the first frame update
    int timer = 0;
    public int EventsTime;
    public bool PessengerIsComing = false;

    GameObject[] Pessengers;
   
    
    private void Awake()
    {
        Pessengers = GameObject.FindGameObjectsWithTag("Pessenger");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;

        if(timer >= EventsTime)
        {
            Debug.Log("hallo");
            timer = 0;
            PessengerIsComing = true;
        }


        if(PessengerIsComing == true)
        {

        }

    }


   

}
