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

    public int HowManyPeopleCanWalk = 1;

    public List<GameObject> Pessengers;

    public int MaximumPessengerSpawn;
    public bool PessengerSpawn = false;

    public Transform PlayerTarget;
    Vector3 SpawnDistance = new Vector3(0, 0.5f, -1);

    // public TriggerManager TM;

    public bool Trigger;

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


    /// oude functie waar een random pessenger wordt gekozen om achter je te spawenen;
    public GameObject ChooseRandomObject()
    {
        int index = Random.Range(0, Pessengers.Count);
        GameObject chosenPessenger = Pessengers[index];
        chosenPessenger.GetComponent<FollowPlayer>().ImAllowdToFollow = true;
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
