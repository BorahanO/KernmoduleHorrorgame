using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CleanRound : MonoBehaviour
{
    public bool isActive;
    public int stage;
    public Quest quest;
    public QuestManager manager;
    public Camera cam;

    [Space]
    public TMP_Text mintrash;
    public TMP_Text maxtrash;
    public GameObject trashUI;
    [Space]

    [SerializeField] private GameObject player;
    public GameObject allTrash;
    public List<GameObject> stTrashList;
    public List<GameObject> businessTrashList;
    public List<GameObject> economyTrashList;
    public List<GameObject> floorDirt;

    public PickupObject pickup;       //checken of je iets moet oppakken
    public BoxCollider storageDoor1;
    public BoxCollider storageDoor2;

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
                    allTrash.SetActive(true);
                    trashUI.SetActive(true);
                    storageDoor1.enabled = false;
                    storageDoor2.enabled = false;
                    maxtrash.text = "4";
                    int temp = 0;
                    foreach (GameObject g in stTrashList)
                    {
                        if (g.activeSelf == false)
                        {
                            temp++;
                        }
                        mintrash.text = temp.ToString();
                    }
                    foreach (GameObject g in stTrashList)
                    {
                        if (g.activeSelf == true)
                        {
                            return;
                        }
                    }
                    manager.advanceQuest(quest);
                    break;
                case 1:
                    maxtrash.text = "6";
                    int temp1 = 0;
                    foreach (GameObject g in businessTrashList)
                    {
                        if (g.activeSelf == false)
                        {
                            temp1++;
                        }
                        mintrash.text = temp1.ToString();
                    }
                    foreach (GameObject g in businessTrashList)
                    {
                        if (g.activeSelf == true)
                        {
                            return;
                        }
                    }
                    manager.advanceQuest(quest);
                    break;
                case 2:
                    maxtrash.text = "8";
                    int temp2 = 0;
                    foreach (GameObject g in economyTrashList)
                    {
                        if (g.activeSelf == false)
                        {
                            temp2++;
                        }
                        mintrash.text = temp2.ToString();
                    }
                    foreach (GameObject g in economyTrashList)
                    {
                        if (g.activeSelf == true)
                        {
                            return;
                        }
                    }
                    manager.advanceQuest(quest);
                    break;
                case 3:
                    trashUI.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 4f))
                        {
                            if (hit.transform.tag == "trashCan")
                            {
                                manager.advanceQuest(quest);
                            }
                        }
                    }
                    break;
                case 4:
                    storageDoor1.enabled = true;
                    break;
                case 5:
                    if (pickup.CurrentObject != null)     //als je iets in je hand hebt
                    {
                        if (pickup.CurrentObject.gameObject.tag == "mop")
                        {
                            manager.advanceQuest(quest);
                        }
                    }
                    break;
                case 6:
                    trashUI.SetActive(true);
                    maxtrash.text = "10";
                    if (pickup.CurrentObject != null)     //als je iets in je hand hebt
                    {
                        if (pickup.CurrentObject.gameObject.tag == "mop")
                        {
                            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;
                            if (Physics.Raycast(ray, out hit, 4f))
                            {
                                if (hit.transform.tag == "floorDirt")
                                {
                                    hit.transform.parent.parent.gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                    int temp3 = 0;
                    foreach (GameObject g in floorDirt)
                    {
                        if (g.activeSelf == false)
                        {
                            temp3++;
                        }
                        mintrash.text = temp3.ToString();
                    }
                    foreach (GameObject g in floorDirt)
                    {
                        if (g.activeSelf == true)
                        {
                            return;
                        }
                    }
                    manager.advanceQuest(quest);
                    break;
                case 7:
                    trashUI.SetActive(false);
                    storageDoor2.enabled = true;
                    break;
            }
        }
        else
        {
            trashUI.SetActive(false);
            allTrash.SetActive(false);
            storageDoor1.enabled = false;
            storageDoor2.enabled = false;
        }
    }
}
