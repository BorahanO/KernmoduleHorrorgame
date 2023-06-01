using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckUnlockedDays : MonoBehaviour
{
    public CompleteDayScriptable day1;
    public CompleteDayScriptable day2;
    public CompleteDayScriptable day3;
    public CompleteDayScriptable day4;
    public CompleteDayScriptable day5;
    [Space]

    public AudioSource unlocked;
    public AudioSource locked;
    [Space]

    public MenuManager menuManager;

    public void checkIfLocked()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        switch (BtnName)
        {
            case "Level1":
                if (day1.isUnlocked)
                {
                    menuManager.LoadScene(1);
                    unlocked.Play();
                }
                else
                {
                    locked.Play();
                }
                break;
            case "Level2":
                if (day2.isUnlocked)
                {
                    menuManager.LoadScene(2);
                    unlocked.Play();
                }
                else
                {
                    locked.Play();
                }
                break;
            case "Level3":
                if (day3.isUnlocked)
                {
                    menuManager.LoadScene(3);
                    unlocked.Play();
                }
                else
                {
                    locked.Play();
                }
                break;
            case "Level4":
                if (day4.isUnlocked)
                {
                    menuManager.LoadScene(4);
                    unlocked.Play();
                }
                else
                {
                    locked.Play();
                }
                break;
            case "Level5":
                if (day5.isUnlocked)
                {
                    menuManager.LoadScene(5);
                    unlocked.Play();
                }
                else
                {
                    locked.Play();
                }
                break;
        }
    }
}
