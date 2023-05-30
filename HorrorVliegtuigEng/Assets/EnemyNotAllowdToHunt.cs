using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNotAllowdToHunt : MonoBehaviour
{
    public bool DezePessengerIsGekozen;
    public bool IkBenGekozenMagIkLopen;
    public bool IkStaNaastPlayer = false;

    public int IkHebNaastThePlayerGestaan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (DezePessengerIsGekozen == true)
        {
            if (IkStaNaastPlayer == true)
            {
                GetComponent<DestinationPessenger>().YouNotAllowdToFollowYet = true;
            }

            if (IkStaNaastPlayer == false)
            {
                GetComponent<DestinationPessenger>().YouNotAllowdToFollowYet = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            IkStaNaastPlayer = true;
            IkHebNaastThePlayerGestaan++;
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
