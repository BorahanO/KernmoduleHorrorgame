using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/QuestObject", order = 1)]
public class Quest : ScriptableObject
{
    public int Stage;
    public int QuestId;
    public string QuestName;
    public string QuestDescription;

    public List<string> ObjectiveList;
    public int currentObjective;
    public bool Completed = false;
}
