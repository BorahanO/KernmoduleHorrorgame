using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask convoMask;
    [SerializeField] private LayerMask trashMask;
    [SerializeField] private float range;
    private GameObject trashObject;
    private GameObject convoObject;
    private StartConvo convo;
    public Camera cam;
    public PessengerBehaviour behaviour;

    [Space]
    public QuestManager manager;
    public QuestTriggers trigger;
    public Quest quest;
    [Space]

    public int maxPuffs;
    public int usedPuffs;
    public TMP_Text maxPuffsTxt;
    public TMP_Text minPuffs;

    private void Start()
    {
        maxPuffsTxt.text = maxPuffs.ToString();
    }

    private void Update()
    {
        minPuffs.text = usedPuffs.ToString();
        if (Input.GetKeyDown(KeyCode.E))
        {
            //var ray = new Ray(player.transform.position, player.transform.forward);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, convoMask))
            {
                convoObject = hit.transform.gameObject;
                convo = convoObject.GetComponentInParent<StartConvo>();
                if (convo != null)
                {
                    StartCoroutine(convo.ShowText());
                }

            }
            else if (Physics.Raycast(ray, out hit, range, trashMask))
            {
                trashObject = hit.transform.parent.gameObject;
                trashObject.SetActive(false);
            }
            else if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.transform.tag == "medkit" && usedPuffs != maxPuffs)
                {
                    behaviour.weepingAnglesStop();
                    usedPuffs++;
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
