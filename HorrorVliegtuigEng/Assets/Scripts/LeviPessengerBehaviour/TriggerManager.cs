using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Trigger1;
    public GameObject Trigger2;
    public GameObject Trigger3;


    public int TriggerCount;


    Quaternion rotation;

    public GameObject SpawnLocatie1;
    public GameObject SpawnLocatie2;
    public GameObject SpawnLocatie3;

    public bool jumpscareIsTriggerd = false;

    public GameObject PrefabPessenger;
    public Transform PlayerTarget;


    void Start()
    {
        Trigger1.active = true;
        Trigger2.active = false;
        Trigger3.active = false;

        SpawnLocatie1.active = true;
        SpawnLocatie2.active = false;
        SpawnLocatie3.active = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerCount == 1)
        {
            //rotatie
            rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);

            Trigger1.active = false;
            SpawnLocatie1.active = false;


            Trigger2.active = true;
            SpawnLocatie2.active = true;
        }

        if (TriggerCount == 2)
        {
            //rotatie
            rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);

            Trigger2.active = false;
            SpawnLocatie2.active = false;


            Trigger3.active = true;
            SpawnLocatie3.active = true;
        }

        if (TriggerCount == 3)
        {
            //rotatie
            rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);

            Trigger2.active = false;
            SpawnLocatie2.active = false;


            Trigger3.active = true;
            SpawnLocatie3.active = true;
        }

        if (jumpscareIsTriggerd == true)
        { 
            PessengerJumpscaretrigger();
        }


        //  Debug.Log("triggerCount" + TriggerCount);
    }

    public void PessengerJumpscaretrigger()
    {
        GameObject SpawnLocation = GameObject.FindWithTag("SpawnLocation");

        Vector3 SpawnDistance = new Vector3(0, 0, 0);
        Instantiate(PrefabPessenger, SpawnLocation.transform.TransformPoint(SpawnDistance), rotation);
        jumpscareIsTriggerd = false;
    }

}
