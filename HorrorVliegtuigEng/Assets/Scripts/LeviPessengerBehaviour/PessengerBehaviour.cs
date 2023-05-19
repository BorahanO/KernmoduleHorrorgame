using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PessengerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int NewPassengerWillStandUpTime;

    public int HowMuchPee;
    public bool AllowdToPee;
    int PeeTimer;

    public bool weepingangles;


    // public int HowManyPeopleCanWalk = 1;

    public List<GameObject> Pessengers;

    //public int MaximumPessengerSpawn;
    //public bool PessengerSpawn = false;

    Vector3 SpawnDistance = new Vector3(0, 0.5f, -1);

    // public TriggerManager TM;
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
        StateMachine();
       // pessengerIsComing();
    }

    public GameObject weepingAngles()
    {
        int index = Random.Range(0, Pessengers.Count);
        GameObject chosenPessenger = Pessengers[index];
        chosenPessenger.GetComponent<DestinationPessenger>().weepingAngles = true;
        return Pessengers[index];
    }

    public GameObject INeedToPee()
    {
       Debug.Log(PeeTimer);
       int index = Random.Range(0, Pessengers.Count);
       GameObject chosenPessenger = Pessengers[index];
       chosenPessenger.GetComponent<DestinationPessenger>().NeedToPee = true;
       return Pessengers[index];
    }


    public void StateMachine()
    {
        PeeTimer++;
        if (PeeTimer > HowMuchPee * 10 || AllowdToPee == true)
        {
         INeedToPee();
         AllowdToPee = false;
        }



        if (weepingangles == true)
        {
            //timer++;
            //if (timer >= NewPassengerWillStandUpTime)
            //{
            //    weepingAngles();
            //    timer = 0;
            //}
            weepingAngles();
        }
    }





}
