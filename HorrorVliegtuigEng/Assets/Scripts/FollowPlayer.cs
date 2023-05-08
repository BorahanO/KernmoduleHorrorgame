using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    InCameraDetector cameradetector;


    public AnnaMariaKoekoek AMK;
    public InCameraDetector ID;

    public NavMeshAgent Passagier;
    public GameObject PassengerLoc;
    public Transform PlayerTarget;

    Rigidbody m_Rigidbody;


    bool ImAllowdToFollow = true;



    int timer = 0;
    bool resetTimer= false;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        GetComponent<FollowPlayer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ID.insight);

        var playerloc = PlayerTarget.position;
        var Pessengerloc = PassengerLoc.transform.position;
        cameradetector = GetComponent<InCameraDetector>();

        if (ImAllowdToFollow == false)
        {
            Passagier.SetDestination(Pessengerloc);
        }

        if (ImAllowdToFollow == true)
        {
            if (ID.insight == false)
            {
                Passagier.SetDestination(playerloc);

            }

            if (ID.insight == true)
            {

                Passagier.SetDestination(Pessengerloc);

            }
        }


        if (GetComponent<FollowPlayer>().enabled == true)
        {
            if (resetTimer == false)
            {
                timer++;
            }
            if (timer > AMK.ImAllowdToFollowtime)
            {
                ImAllowdToFollow = false;

                  if(ImAllowdToFollow == false)
                  {
                    timer = 0;
                    resetTimer = true;
                  }   
            }
        }
    }



}


