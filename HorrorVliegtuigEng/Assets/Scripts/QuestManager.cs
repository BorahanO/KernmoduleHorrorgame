using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int currentStage;
    public Quest activeQuest;
    public bool isQuestActive;

    public string currentObjective;
    public TMP_Text objectiveText;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (currentObjective != null)
        {
            objectiveText.text = currentObjective;
        }
        else
        {
            objectiveText.text = "no active quests";
        }

        if(isQuestActive)
        {
            currentObjective = activeQuest.ObjectiveList[activeQuest.currentObjective];
        }
        else
        {
            currentObjective = null;
        }
    }

    public void ActivateQuest(Quest q)
    {
        if (isQuestActive || q.Stage != currentStage || q.Completed) 
        { return; }
        else
        {
            activeQuest = q;
            isQuestActive = true;
            Debug.Log("started quest");
        }
    }

    public void advanceQuest(Quest q)
    {
        if (q.currentObjective < q.ObjectiveList.Count -1)
        {
            q.currentObjective++;
            Debug.Log("progressed quest");
        }
        else
        {
            isQuestActive = false;
            activeQuest = null;
            q.Completed = true;
            Debug.Log("completed quest");
        }
    }
}
