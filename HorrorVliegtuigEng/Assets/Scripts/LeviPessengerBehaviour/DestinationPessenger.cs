using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestinationPessenger : MonoBehaviour
{
    public TargetManagement TM;

    public PessengerBehaviour PB;
    public NavMeshAgent Passagier;
    public GameObject PassengerSeat;
    public Transform PlayerTarget;
    public Transform Toilet;

    public bool WalkToPlayer = false;
    public bool WeepingAnglesIsActive;
    public bool Stop;
    public bool NeedToPee = false;
    public bool ToYourSeats;

    public int peetimer;



    int timer = 0;
    bool resetTimer = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var Pessengerloc = PassengerSeat.transform.position;
        var playerloc = PlayerTarget.position;

        WeepingAngles();
        ToiletDestination();
        ToyourSeats();

    }

    void WeepingAngles()
    {
        var playerloc = PlayerTarget.position;

        if (WeepingAnglesIsActive == true)
        {
            if (WalkToPlayer == true)
            {
                Passagier.SetDestination(playerloc);
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;

            }

            if (WalkToPlayer == false)
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;

            }
        }
    }

    void ToiletDestination()
    {
        var toilet = Toilet.transform.position;
        if (NeedToPee == true)
        {
            Passagier.SetDestination(Toilet.position);
            peetimer++;

            NeedToPee = false;
        }
    }

    void ToyourSeats()
    {
        var Pessengerloc = PassengerSeat.transform.position;
        if (ToYourSeats == true)
        {
            Passagier.SetDestination(Pessengerloc);
            ToYourSeats = false;
        }
    }
}
