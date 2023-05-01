using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    InCameraDetector cameradetector;


    public AnnaMariaKoekoek AMK;

    public NavMeshAgent Passagier;
    Vector3 PassagierLoc; 
    public Transform PlayerTarget;
    public Transform NewPassagierLoc;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FollowPlayer>().enabled = false;
        PassagierLoc.Set(NewPassagierLoc.position.x, NewPassagierLoc.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var playerloc = PlayerTarget.position;
        cameradetector = GetComponent<InCameraDetector>();


        if(AMK.PessengerIsComing == true)
        {
            
        }

        if (cameradetector.insight == true)
        {
            Passagier.SetDestination(playerloc);
        }

        if(cameradetector.insight == false)
        {
            Passagier.SetDestination(NewPassagierLoc.transform.position);
        }
    }

    }

