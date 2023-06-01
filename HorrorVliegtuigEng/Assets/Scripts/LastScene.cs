using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "lastScene", menuName = "ScriptableObjects/LastScene", order = 1)]
public class LastScene : ScriptableObject
{
    public int LastLevelPlayed;
}
