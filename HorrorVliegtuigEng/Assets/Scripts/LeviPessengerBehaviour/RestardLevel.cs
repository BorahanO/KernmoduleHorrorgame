using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestardLevel : MonoBehaviour
{
    int timer;
    public LastScene lastScene;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer++;

        if (timer > 1000)
        {
            SceneManager.LoadScene(lastScene.LastLevelPlayed);
        }
    }
}
