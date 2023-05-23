using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public QuestManager manager;
    public QuestTriggers trigger;
    public Quest quest;

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartQuest")
        {
            trigger = other.GetComponentInParent<QuestTriggers>();
            quest = trigger.quest;
            manager.ActivateQuest(quest);
            other.enabled = false;
        }
        else if (other.tag == "ProgressQuest")
        {
            trigger = other.GetComponentInParent<QuestTriggers>();
            quest = trigger.quest;
            manager.advanceQuest(quest);
            other.enabled = false;
        }
    }
}
