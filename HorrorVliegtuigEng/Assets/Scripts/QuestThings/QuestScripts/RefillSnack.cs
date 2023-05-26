using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillSnack : MonoBehaviour
{
    public bool isActive;
    public int stage;
    public Quest quest;
    public QuestManager manager;
    public PickupObject pickup;

    //public StartConvo convo;
    public BoxCollider storageDoor;
    public BoxCollider stationDoor;

    private bool temp1 = false;
    private bool temp2 = false;

    private void Start()
    {
        isActive = false;
    }

    private void Update()
    {
        isActive = quest.isActive;

        if (isActive)
        {
            stage = quest.currentObjective;
            switch (stage)
            {
                case 0:
                    storageDoor.enabled = true;
                    break;
                case 1:
                    if (pickup.CurrentObject != null)
                    {
                        if (pickup.CurrentObject.gameObject.tag == "Snack")
                        {
                            temp1 = true;
                        }
                    }
                    else if (pickup.CurrentObject == null && temp1)
                    {
                        manager.advanceQuest(quest);
                        temp1 = false;
                    }
                    break;
                case 2:
                    if (pickup.CurrentObject != null)
                    {
                        if (pickup.CurrentObject.gameObject.tag == "Drink")
                        {
                            temp2 = true;
                        }
                    }
                    else if (pickup.CurrentObject == null && temp2)
                    {
                        manager.advanceQuest(quest);
                        temp2 = false;
                    }
                    break;
                case 3:
                    stationDoor.enabled = true;
                    break;
            }
        }
        else
        {
            storageDoor.enabled = false;
            stationDoor.enabled = false;
        }
    }
}

