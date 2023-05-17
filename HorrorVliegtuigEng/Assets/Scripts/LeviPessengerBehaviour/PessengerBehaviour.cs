using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PessengerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    int timer = 0;
    public int NewPassengerWillStandUpTime;
    public bool PessengerIsComing = false;

    public int ImAllowdToFollowtime = 500;

    public int HowManyPeopleCanWalk = 1;

    public List<GameObject> Pessengers;

    public Transform PlayerTarget;
    Vector3 SpawnDistance = new Vector3(0, 0.5f, -1);
    

    public JumpScareTrigger jumpscaretrigger;

    private void Awake()
    {
        
    }


    void Start()
    {
       // Vector3 Spawnpoint = PlayerTarget.TransformPoint(SpawnDistance);
    }

    // Update is called once per frame
    void Update()
    {
        pessengerIsComing();

        

    }


    // deze functie wordt gebruikt om pessengers achter je te laten spawnen met een trigger 
    public GameObject PessengerJumpscaretrigger()
    {
        // Choose a random index from the list of game objects
       
        int index = Random.Range(0, Pessengers.Count);
        GameObject chosenPessenger = Pessengers[index];

        chosenPessenger.GetComponent<FollowPlayer>().enabled = true;
        // Return the game object at the chosen index
        if (jumpscaretrigger.jumpscareIsTriggerd == true)
        {
            chosenPessenger.transform.position = new Vector3(PlayerTarget.position.x, PlayerTarget.position.y, PlayerTarget.position.z);
        }
        return Pessengers[index];
    }



    /// oude functie waar een random pessenger wordt gekozen om achter je te spawenen;
    public GameObject ChooseRandomObject()
    {
        // Choose a random index from the list of game objects

        int index = Random.Range(0, Pessengers.Count);
        GameObject chosenPessenger = Pessengers[index];
        Debug.Log(chosenPessenger);
        chosenPessenger.GetComponent<FollowPlayer>().ImAllowdToFollow = true;
       
        // Return the game object at the chosen index
  
        return Pessengers[index];
    }


    public void pessengerIsComing()
    {
        timer++;
        
        if (timer >= NewPassengerWillStandUpTime)
        {
            PessengerIsComing = true;
            Debug.Log("is Coming!");
        }


        if (PessengerIsComing == true)
        {

            ChooseRandomObject();
            timer = 0;
            PessengerIsComing = false;
        }
    }



 
}
