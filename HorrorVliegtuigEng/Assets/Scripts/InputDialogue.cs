using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputDialogue : MonoBehaviour
{
    private bool isActivated = true;
    public List<string> dialogueList = new List<string>();
    private int textIndex = 0;
    [SerializeField] private GameObject PressToContinueButton;
    public string NextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isActivated)
            {
                StartCoroutine(NarrationBox.narrationBoxSingleton.ShowText(dialogueList[0], false));
                NarrationBox.narrationBoxSingleton.TextBox.SetActive(true);
                PressToContinueButton.SetActive(true);
                isActivated = true;

            }
        }
    }

    private void Update()
    {
        if (isActivated)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                textIndex++;
                if (textIndex < dialogueList.Count)
                {
                    StartCoroutine(NarrationBox.narrationBoxSingleton.ShowText(dialogueList[textIndex], false));
                }
                else
                {
                    NarrationBox.narrationBoxSingleton.TextBox.SetActive(false);
                    PressToContinueButton.SetActive(false);
                    SceneManager.LoadScene(NextScene);
                }
            }
        }
    }
}
