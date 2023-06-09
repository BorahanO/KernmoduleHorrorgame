using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConvo : MonoBehaviour
{
    [SerializeField] public bool hasBeenShown;
    public bool allowedToShow;

    public GameObject text;
    public AudioSource mur;

    private void Start()
    {
        text.SetActive(false);
        hasBeenShown = false;
        allowedToShow = false;
    }

    private void Update()
    {

    }

    public IEnumerator ShowText()
    {
        if (!hasBeenShown && allowedToShow)
        {
            mur.Play();
            text.SetActive(true);
            hasBeenShown = true;
            yield return new WaitForSeconds(2f);
            text.SetActive(false);
        }
    }
}
