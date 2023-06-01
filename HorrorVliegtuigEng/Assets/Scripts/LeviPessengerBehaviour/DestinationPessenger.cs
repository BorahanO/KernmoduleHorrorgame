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
    public Transform Toilet1;
    public Transform Toilet2;

    public AudioSource WalkingSound;


    public GameObject Idle;
    public GameObject Walking;
    public GameObject Sitting;

    public bool WalkToPlayer = false;
    public bool WeepingAnglesIsActive;
    public bool WeepingAnglesButIneedToPee;
    public bool DoneWithPee;
    public bool NeedToPee = false;
    public bool ToYourSeats;
    public int GoingBackToWheepingafterWheepingTimer;
    public int HowMuchPee;

    public bool YouAreSitting = false;
    public int peetimer;
    public Transform SittingDirection;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 lastpos = gameObject.transform.position;
        WalkingSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        WeepingAngles();
        ToiletDestination();
        ToyourSeats();

        Animaties();
        WheepingAnglesButIneedToPee();
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
       // var toilet = Toilet1.transform.position;
        if (NeedToPee == true)
        {
            int randomNumber = Random.Range(1, 2);
            if (randomNumber == 1)
            {
                Passagier.SetDestination(Toilet1.transform.position);
            }

            if(randomNumber == 2)
            {
                Passagier.SetDestination(Toilet2.transform.position);
            }
           
            peetimer++;

            if (peetimer > HowMuchPee)
            {
             Passagier.SetDestination(Pessengerloc);
             HowMuchPee = 0;
             DoneWithPee = true;
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

    void WheepingAnglesButIneedToPee()
    {
        if (WeepingAnglesButIneedToPee == true)
        {
            if (DoneWithPee == true)
            {
                GoingBackToWheepingafterWheepingTimer++;
                if(GoingBackToWheepingafterWheepingTimer > 3000)
                {
                    WeepingAnglesIsActive = true;
                }
            }

        }
    }
    void Animaties()
    {
        Sitting.transform.LookAt(SittingDirection);


        if(Walking.active == true)
        {
            WalkingSound.Play();
        }

        if(Walking.active == false)
        {
            WalkingSound.Stop();
        }

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

