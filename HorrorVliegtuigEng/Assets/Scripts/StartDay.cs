using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartDay : MonoBehaviour
{
    public GameObject blackScreen;
    public PessengerBehaviour behaviour;
    public bool isDay1;

    private void Start()
    {
        StartCoroutine(startDay());
    }

    public IEnumerator startDay()
    {
        behaviour.WeepingAnglesActive = false;
        Time.timeScale = 0f;
        blackScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        blackScreen.SetActive(false);
        Time.timeScale = 1f;
        if (!isDay1)
        {
            behaviour.WeepingAnglesActive = true;
        }
    }
}
