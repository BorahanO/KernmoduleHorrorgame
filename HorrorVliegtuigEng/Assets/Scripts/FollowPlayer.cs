using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    InCameraDetector cameradetector;

    public NavMeshAgent agent;
    public GameObject player;
    public GameObject Person;
    Vector3 playerloc;
    Vector3 personloc;

    // Start is called before the first frame update
    void Start()
    {
        playerloc = player.transform.position;
        personloc = Person.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        cameradetector = GetComponent<InCameraDetector>();
       
        // hieronder gaat de passagier de speler achterna 
        // De locatie van de speler wordt nog niet geupdate, voor nu nog niet heel belangrijk

        if (cameradetector.insight == false)
        {
            agent.SetDestination(playerloc);
        }

        if(cameradetector.insight == true)
        {   
            agent.SetDestination(personloc);
        }

    }
}
