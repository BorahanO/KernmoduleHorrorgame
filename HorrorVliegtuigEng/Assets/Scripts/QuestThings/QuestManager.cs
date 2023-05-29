using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int currentStage;
    public Quest activeQuest;
    public bool isQuestActive;

    public string currentObjective;
    public TMP_Text objectiveText;

    [SerializeField] private List<Quest> fase3Quests;

    private void Start()
    {
        ActivateQuest(fase3Quests[0]);
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

        if (isQuestActive)
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
        if (isQuestActive || q.Stage != currentStage)
        { return; }
        else
        {
            activeQuest = q;
            isQuestActive = true;
            activeQuest.isActive = true;
            Debug.Log("started quest " + q.QuestName);
        }
    }

    public void advanceQuest(Quest q)
    {
        if (q.currentObjective < q.ObjectiveList.Count - 1)
        {
            q.currentObjective++;
            Debug.Log("progressed quest " + q.QuestName);
        }
        else
        {
            isQuestActive = false;
            activeQuest.isActive = false;
            activeQuest = null;
            if (q.QuestId + 1 != fase3Quests.Count)
            {
                ActivateQuest(fase3Quests[q.QuestId + 1]);
            }
            else
            { //next day
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            Debug.Log("completed quest" + q.QuestName);
        }
    }
}
