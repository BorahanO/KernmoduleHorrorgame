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
        if (WeepingAnglesIsActive == true)
        {
            Debug.Log("het werdt gezien");
            if (WalkToPlayer == true)
            {
                var playerloc = PlayerTarget.position;
                Passagier.SetDestination(playerloc);
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;

            }

            if (WalkToPlayer == false)
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;

            }
        }
        if (WeepingAnglesIsActive == false)
        {
            var Pessengerloc = PassengerSeat.transform.position;
            Passagier.SetDestination(Pessengerloc);
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }

    }

    void ToiletDestination()
    {
        var Pessengerloc = PassengerSeat.transform.position;
        var toilet = Toilet.transform.position;
        if (NeedToPee == true)
        {
            Passagier.SetDestination(Toilet.position);
            peetimer++;

            if (peetimer > 10000)
            {
             Passagier.SetDestination(Pessengerloc);
             NeedToPee = false;
            }
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
