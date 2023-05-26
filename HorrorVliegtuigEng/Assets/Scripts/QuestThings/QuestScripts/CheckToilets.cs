using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToilets : MonoBehaviour
{
    public bool isActive;
    public int stage;
    public Quest quest;
    public QuestManager manager;
    public BoxCollider door1;
    public BoxCollider door2;


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
                    door1.enabled = true;
                    door2.enabled = true;
                    break;
            }
        }
        else
        {
            door1.enabled = false;
            door2.enabled = false;
        }
    }
}
