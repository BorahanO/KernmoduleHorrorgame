using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNotAllowdToHunt : MonoBehaviour
{
    public bool IkStaNaastPlayer = false;

    public int IkHebNaastThePlayerGestaan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            IkStaNaastPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            IkStaNaastPlayer = false;
        }
    }
}
