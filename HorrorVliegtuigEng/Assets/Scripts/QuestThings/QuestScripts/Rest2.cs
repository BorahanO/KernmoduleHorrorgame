using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest2 : MonoBehaviour
{
    public bool isActive;
    public int stage;
    public Quest quest;
    public QuestManager manager;
    public GameObject instructionsText;

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
                    instructionsText.SetActive(false);
                    break;
                case 1:
                    instructionsText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        manager.advanceQuest(quest);
                    }
                    break;
            }
        }
        else
        {
            instructionsText.SetActive(false);
        }
    }
}
