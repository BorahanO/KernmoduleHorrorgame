using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PessengerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int NewPassengerWillStandUpTime;
    public int StandUpReductionTime;
    public int ReductionAmount;
    public int VerkleinTimer;

    public int HowMuchPee;
    public bool AllowdToPee;
    public bool ToYourSeats;
    int PeeTimer;
    public int timer;

    public int ImNextToPlayerTimer;

    public GameObject Toilet;

    public int Switch;

    public Camera cam;
    public int PeeCount;

    public bool WeepingAnglesActive;


    // public int HowManyPeopleCanWalk = 1;

    public List<GameObject> Pessengers;

    //public int MaximumPessengerSpawn;
    //public bool PessengerSpawn = false;

    Vector3 SpawnDistance = new Vector3(0, 0.5f, -1);

    // public TriggerManager TM;
    private void Awake()
    {
        Pessengers.AddRange(GameObject.FindGameObjectsWithTag("PessengerAssignToSystem"));
    }


    void Start()
    {
    // Vector3 Spawnpoint = PlayerTarget.TransformPoint(SpawnDistance);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }

    public GameObject weepingAngles()
    {

        Debug.Log("het wrodt gezien");
        int index = Random.Range(0, Pessengers.Count);
        GameObject chosenPessenger = Pessengers[index];

        if (chosenPessenger.GetComponentInChildren<EnemyNotAllowdToHunt>().IkStaNaastPlayer == false)
        {
            chosenPessenger.GetComponent<DestinationPessenger>().WeepingAnglesIsActive = true;
            chosenPessenger.GetComponentInChildren<JijGaatDood>().dubbleCheck = true;
            Debug.Log("Ik kom achter je aan!!!");
        }

        if (chosenPessenger.GetComponentInChildren<EnemyNotAllowdToHunt>().IkStaNaastPlayer == true)
        {
           // Debug.Log("ik mag niks doen");
        }
        return Pessengers[index];
    }

    public void weepingAnglesStop()
    {
        foreach (GameObject P in Pessengers)
        {
            WeepingAnglesActive = false;
            P.GetComponent<DestinationPessenger>().WalkToPlayer = false;
            P.GetComponent<DestinationPessenger>().WeepingAnglesIsActive = false;
            timer = 0;
            WeepingAnglesActive = true;
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
        timer++;
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
            if (timer >= NewPassengerWillStandUpTime)
            {
                Debug.Log("jaaaaa");
                weepingAngles();
                timer = 0;
            }
        }



        if (VerkleinTimer > StandUpReductionTime)
        {
            NewPassengerWillStandUpTime = NewPassengerWillStandUpTime - ReductionAmount;
            VerkleinTimer = 0;
        }
    }





}
 