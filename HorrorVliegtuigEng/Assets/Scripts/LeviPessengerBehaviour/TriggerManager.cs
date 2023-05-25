using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public TriggerSpawnPair[] triggerSpawnPairs;
    public GameObject prefabPessenger;

    public int activeTriggerIndex = 0;
    private Quaternion rotation;
    public bool jumpscareIsTriggered = false;

    public PessengerBehaviour PB;

    public GameObject Playertarget;

    public GameObject trigger;
    public GameObject spawnLocation;


    [System.Serializable]
    public class TriggerSpawnPair
    {
        public GameObject trigger;
        public GameObject spawnLocation;
    }

    private void Start()
    {
        SetTriggerSpawnActive(activeTriggerIndex);
    }

    private void Update()
    {
        if (activeTriggerIndex == 1)
        {
            PB.ToYourSeats = true;
        }

        if (activeTriggerIndex == 2)
        {
            rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            SetTriggerSpawnActive(activeTriggerIndex);
        }

        if (activeTriggerIndex == 3)
        {
            rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            SetTriggerSpawnActive(activeTriggerIndex);
        }

        if (activeTriggerIndex == 4)
        {
            rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            SetTriggerSpawnActive(activeTriggerIndex);
        }


        if (jumpscareIsTriggered)
        {
            PessengerJumpscareTrigger(activeTriggerIndex);
        }
    }

    public void PessengerJumpscareTrigger(int index)
    {
        GameObject spawnLocation = triggerSpawnPairs[activeTriggerIndex].spawnLocation;
        Vector3 spawnDistance = Vector3.zero;
        Instantiate(prefabPessenger, spawnLocation.transform.TransformPoint(spawnDistance), rotation);
        jumpscareIsTriggered = false;

        var PessengerSeat = GameObject.FindWithTag("SpawnPessenger");



        // als je de pessenger wil laten spawnen achter de speler gebruik dan de code hieronder.
        if (index == 3)
        {

        }
    }

    private void SetTriggerSpawnActive(int index)
    {
        for (int i = 0; i < triggerSpawnPairs.Length; i++)
        {
            if (i == index)
            {
                triggerSpawnPairs[i].trigger.SetActive(true);
                triggerSpawnPairs[i].spawnLocation.SetActive(true);
            }
            else
            {
                triggerSpawnPairs[i].trigger.SetActive(false);
                triggerSpawnPairs[i].spawnLocation.SetActive(false);
            }
        }
    }
}


