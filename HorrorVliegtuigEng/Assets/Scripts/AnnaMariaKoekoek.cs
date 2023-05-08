using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaMariaKoekoek : MonoBehaviour
{
    // Start is called before the first frame update
    int timer = 0;
    public int NewPassengerWillStandUpTime;
    public bool PessengerIsComing = false;

    public int ImAllowdToFollowtime = 500;

    public int HowManyPeopleCanWalk = 1;

    public List<GameObject> Pessengers;

   
    
    private void Awake()
    {

    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

       timer++;

        if(timer >= NewPassengerWillStandUpTime)
        {
            PessengerIsComing = true; 
        }


        if(PessengerIsComing == true)
        {
            ChooseRandomObject();
            timer = 0;
            PessengerIsComing = false;
        }

    }


    public GameObject ChooseRandomObject()
    {
            // Choose a random index from the list of game objects
            int index = Random.Range(0, Pessengers.Count);
            GameObject chosenPessenger = Pessengers[index];
           // Debug.Log(chosenPessenger);
            chosenPessenger.GetComponent<FollowPlayer>().enabled = true;
            // Return the game object at the chosen index
            return Pessengers[index];

    }



}
