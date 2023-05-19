using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestinationPessenger : MonoBehaviour
{

    InCameraDetector cameradetector;

    public TargetManagement TM;

    public PessengerBehaviour PB;
    public NavMeshAgent Passagier;
    public GameObject PassengerSeat;
    public Transform PlayerTarget;
    public Transform Toilet;

    public bool weepingAngles = false;
    public bool Stop;
    public bool NeedToPee = false;



    int timer = 0;
    bool resetTimer = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        DestinationAirplane();

        if (weepingAngles == true)
        {
            WeepingAngles();
        }

        if (Stop == true)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    void WeepingAngles()
    {
        var playerloc = PlayerTarget.position;
        var Pessengerloc = PassengerSeat.transform.position;
        cameradetector = GetComponent<InCameraDetector>();


        if (TM.insight == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            Passagier.SetDestination(playerloc);

        }

        if (TM.insight == true)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }

    }

    void DestinationAirplane()
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
        }
    }
}
