using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    InCameraDetector cameradetector;


    public PessengerBehaviour PB;
    public InCameraDetector ID;

    public NavMeshAgent Passagier;
    public GameObject PassengerLoc;
    public Transform PlayerTarget;

    public bool ImAllowdToFollow = false;



    int timer = 0;
    bool resetTimer = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerloc = PlayerTarget.position;
        var Pessengerloc = PassengerLoc.transform.position;
        cameradetector = GetComponent<InCameraDetector>();


        if (ImAllowdToFollow == false)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        }

        if (ImAllowdToFollow == true)
        {
            if (ID.insight == false)
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                Passagier.SetDestination(playerloc);

            }

            if (ID.insight == true)
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            }
        }


      //  if (GetComponent<FollowPlayer>().enabled == true)
       // {
       //     if (resetTimer == false)
      //      {
       //         timer++;
      //      }
      //      if (timer > AMK.ImAllowdToFollowtime)
      //      {
      //          ImAllowdToFollow = false;

     //             if(ImAllowdToFollow == false)
     //             {
      //              timer = 0;
      //              resetTimer = true;
     //             }   
     //       }
     //   }
    }

       



}


