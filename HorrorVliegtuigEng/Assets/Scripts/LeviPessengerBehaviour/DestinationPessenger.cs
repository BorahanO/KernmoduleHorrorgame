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

    public bool weepingAngles = false;
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

        ToiletDestination();
        WeepingAngles();
        ToyourSeats();

    }

    void WeepingAngles()
    {
        var playerloc = PlayerTarget.position;

        if (weepingAngles == true)
        {
            Passagier.SetDestination(playerloc);
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;

        }

        if (weepingAngles == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }

    }

    void ToiletDestination()
    {

        var toilet = Toilet.transform.position;
        if (NeedToPee == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }

        if (NeedToPee == true)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            Passagier.SetDestination(Toilet.position);
            peetimer++;

            if (peetimer > 2500)
            {
                var Pessengerloc = PassengerSeat.transform.position;
                Passagier.SetDestination(Pessengerloc);
            }
        }
    }

    void ToyourSeats()
    {
        if (ToYourSeats == true)
        {
            var Pessengerloc = PassengerSeat.transform.position;
            Passagier.SetDestination(Pessengerloc);
        }

    }
}
