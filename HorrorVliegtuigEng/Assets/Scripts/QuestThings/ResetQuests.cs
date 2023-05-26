using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetQuests : MonoBehaviour
{
    public List<Quest> quests;

    private void Awake()
    {
        foreach (Quest q in quests)
        {
            q.isActive = false;
            q.currentObjective = 0;
        }
    }
}
