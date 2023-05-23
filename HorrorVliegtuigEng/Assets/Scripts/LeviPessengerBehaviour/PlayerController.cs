using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float range;
    private GameObject convoObject;
    private StartConvo convo;

    [Space]
    public QuestManager manager;
    public QuestTriggers trigger;
    public Quest quest;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var ray = new Ray(player.transform.position, player.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, mask))
            {
                convoObject = hit.transform.gameObject;
                convo = convoObject.GetComponentInParent<StartConvo>();
                if (convo != null)
                {
                    StartCoroutine(convo.ShowText());
                }

            }
        }
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
