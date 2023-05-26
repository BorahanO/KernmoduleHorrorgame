using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public bool jumpscareIsTriggerd;
    public TriggerManager TM;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other);
            TM.EenKeerUitvoeren = true;
            TM.jumpscareIsTriggered = true;
            TM.activeTriggerIndex++;
        }
    }
}
