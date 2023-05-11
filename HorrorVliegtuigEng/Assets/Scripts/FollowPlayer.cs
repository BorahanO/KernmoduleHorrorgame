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

    bool ImAllowdToFollow = true;



    int timer = 0;
    bool resetTimer= false;


    // Start is called before the first frame update
    void Start()
    {
              GetComponent<FollowPlayer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ID.insight);

        var playerloc = PlayerTarget.position;
        var Pessengerloc = PassengerLoc.transform.position;
        cameradetector = GetComponent<InCameraDetector>();

        
        if (ImAllowdToFollow == true)
        {
            if (ID.insight == false)
            {
               // Passagier.SetDestination(playerloc);

            }

            if (ID.insight == true)
            {
                timer++;

                if (timer >= 200)
                {
                    Passagier.SetDestination(Pessengerloc);
                }
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


