using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestinationPessenger : MonoBehaviour
{

    public PessengerBehaviour PB;
    public NavMeshAgent Passagier;
    public GameObject PassengerSeat;
    public GameObject PlayerTarget;
    public Transform Toilet;



    public GameObject Idle;
    public GameObject Walking;
    public GameObject Sitting;

    public bool WalkToPlayer = false;
    public bool WeepingAnglesIsActive;
    public bool NeedToPee = false;
    public bool ToYourSeats;
    public int HowMuchPee;

    public bool YouAreSitting = false;
    public int peetimer;
    public Transform SittingDirection;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 lastpos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        WeepingAngles();
        ToiletDestination();
        ToyourSeats();

        Animaties();

    }

    private void FixedUpdate()
    {
    }

    void WeepingAngles()
    {
        if (WeepingAnglesIsActive == true)
        {
            Debug.Log("imactive");
            if (WalkToPlayer == true)
            {
                var playerloc = PlayerTarget.transform.position;
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

            if (peetimer > HowMuchPee)
            {
             Passagier.SetDestination(Pessengerloc);
             HowMuchPee = 0;
             //PB.PeeCount = 2;
             Debug.Log(PB.PeeCount);
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


    void Animaties()
    {
        Sitting.transform.LookAt(SittingDirection);


        if (WeepingAnglesIsActive == true)
        {
            Walking.active = false;
            Idle.active = true;
            Sitting.active = false;
        }

        if (WeepingAnglesIsActive == false)
        {
            if (YouAreSitting == false)
            {
                Sitting.active = false;

                if (Passagier.velocity.sqrMagnitude == 0f)
                {
                    Walking.active = false;
                    Idle.active = true;
                    Sitting.active = false;
                }
                if (Passagier.velocity.sqrMagnitude > 0f)
                {
                    Walking.active = true;
                    Idle.active = false;
                    Sitting.active = false;
                }
            }

            if (YouAreSitting == false)
            {
                if (GetComponent<NavMeshAgent>().velocity.x > 0.0001)
                {
                    Walking.active = true;
                    Idle.active = false;
                    Sitting.active = false;
                }
            }

            if (YouAreSitting == true)
            {

                if (Passagier.velocity.sqrMagnitude == 0f)
                {
                    Walking.active = false;
                    Idle.active = false;
                    Sitting.active = true;
                }
            }

        }




    }
}

