using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stClassCheck : MonoBehaviour
{
    public bool isActive;
    public int stage;
    public Quest quest;
    public QuestManager manager;
    public PickupObject pickup;

    public StartConvo convo;
    public BoxCollider door;

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
                    door.enabled = true;
                    convo.allowedToShow = true;
                    break;
                case 1:
                    if (convo.hasBeenShown)
                    {
                        manager.advanceQuest(quest);
                    }
                    break;
                case 2:
                    convo.allowedToShow = false;
                    //if picked up phone, go to stage 3
                    if (pickup.CurrentObject != null)
                    {
                        if (pickup.CurrentObject.gameObject.tag == "Phone")
                        {
                            manager.advanceQuest(quest);
                        }
                    }
                    break;
                case 3:
                    if (pickup.CurrentObject == null)
                    {
                        manager.advanceQuest(quest);
                    }
                    break;
            }
        }
        else
        {
            door.enabled = false;
        }
    }
}
