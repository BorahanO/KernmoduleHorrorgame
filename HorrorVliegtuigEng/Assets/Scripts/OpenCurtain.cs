using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCurtain : MonoBehaviour
{
    public GameObject curtainPos1;
    public GameObject curtainPos2;

    private void Start()
    {
        curtainPos1.SetActive(true);
        curtainPos2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        curtainPos1.SetActive(false);
        curtainPos2.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        curtainPos1.SetActive(true);
        curtainPos2.SetActive(false);
    }
}
