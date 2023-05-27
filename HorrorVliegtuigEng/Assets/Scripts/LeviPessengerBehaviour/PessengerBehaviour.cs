using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PessengerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int NewPassengerWillStandUpTime;
    public int StandUpTimeVerkleining;
    public int VerkleinTimer;

    public bool GoToIdleState;

    public int HowMuchPee;
    public bool AllowdToPee;
    public bool ToYourSeats;
    int PeeTimer;
    public int timer;

    public GameObject Toilet;

    public int Switch;

    public bool WeepingAnglesActive;


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

        if (Input.GetKeyDown(KeyCode.K))
        {
            weepingAnglesStop();
        }
    }

    public GameObject weepingAngles()
    {
        int index = Random.Range(0, Pessengers.Count);
        GameObject chosenPessenger = Pessengers[index];
        chosenPessenger.GetComponent<DestinationPessenger>().WeepingAnglesIsActive = true;
        chosenPessenger.GetComponentInChildren<JijGaatDood>().JijMagDood = true;
        return Pessengers[index];
    }

    public void weepingAnglesStop()
    {
        foreach (GameObject P in Pessengers)
        {
            WeepingAnglesActive = false;
            P.GetComponent<DestinationPessenger>().WalkToPlayer = false;
            P.GetComponent<DestinationPessenger>().WeepingAnglesIsActive = false;
        }

    }
    public GameObject INeedToPee()
    {
       int index = Random.Range(0, Pessengers.Count);
       GameObject chosenPessenger = Pessengers[index];
       chosenPessenger.GetComponent<DestinationPessenger>().NeedToPee = true;
       return Pessengers[index];
    }

    public void GoToYourSeats()
    {
        foreach (GameObject P in Pessengers)
        {
            P.GetComponent<DestinationPessenger>().ToYourSeats = true;
        }

    }

    public void StateMachine()
    {
        PeeTimer++;
        VerkleinTimer++;
        if (PeeTimer > HowMuchPee || AllowdToPee == true)
        {
          Debug.Log("lekker plassen");
          INeedToPee();
          PeeTimer = 0;
          AllowdToPee = false;
        }

        if (ToYourSeats == true)
        {
            GoToYourSeats();
            ToYourSeats = false;
        }

        if (WeepingAnglesActive == true)
        {
            timer++;
            if (timer >= NewPassengerWillStandUpTime)
            {
                weepingAngles();
                timer = 0;
            }
        }


        if (VerkleinTimer > StandUpTimeVerkleining)
        {
            NewPassengerWillStandUpTime = NewPassengerWillStandUpTime - 1000;
            VerkleinTimer = 0;
        }
    }





}
