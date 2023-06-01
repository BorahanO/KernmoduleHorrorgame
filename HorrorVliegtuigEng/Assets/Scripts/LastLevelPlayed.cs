using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelPlayed : MonoBehaviour
{
    public LastScene LastScene;
    public int scene;

    private void Start()
    {
        LastScene.LastLevelPlayed = scene;
    }
}
