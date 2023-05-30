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


    public GameObject Idle;
    public GameObject Walking;
    public GameObject Sitting;

    public bool WalkToPlayer = false;
    public bool WeepingAnglesIsActive;
    public bool Stop;
    public bool NeedToPee = false;
    public bool ToYourSeats;
    public bool ImSitting;

    public bool WeepingAnglesMagDoorGaan;
    public bool YouNotAllowdToFollowYet;
    public bool YouAreSitting = false;
    public int peetimer;


    int PositionCheckTimer;
    int timer = 0;
    bool resetTimer = false;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 lastpos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        var Pessengerloc = PassengerSeat.transform.position;
        var playerloc = PlayerTarget.position;
        var toilet = Toilet.transform.position;

        WeepingAngles();
        ToiletDestination();
        ToyourSeats();


        if (transform.hasChanged == true)
        {
            Walking.active = true;
            Idle.active = false;
            Sitting.active = false;
        }

        if (YouAreSitting == true)
        {
            Walking.active = false;
            Idle.active = false;
            Sitting.active = false;
        }

        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.01f) Debug.Log("We're moving!");
        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 0.05f) Debug.Log("Nooooooooooo!");

        PositionCheckTimer++;

    }

    private void FixedUpdate()
    {
    }

    void WeepingAngles()
    {
        if (WeepingAnglesIsActive == true)
        {
            if (WalkToPlayer == true)
            {
                Walking.active = false;
                Idle.active = true;
                Sitting.active = false;

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
            Walking.active = true;
            Idle.active = false;
            Sitting.active = false;

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

    void InYourSeat()
    {
        if (ImSitting == true)
        {
            Walking.active = false;
            Idle.active = false;
            Sitting.active = true;
        }
    }

}
