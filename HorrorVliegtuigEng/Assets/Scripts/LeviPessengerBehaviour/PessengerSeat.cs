using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PessengerSeat : MonoBehaviour
{

    public GameObject Pessenger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PessengerCollisionBox")
        {
            Debug.Log("het werkt");
          Pessenger.GetComponent<DestinationPessenger>().YouAreSitting = true;
        }

    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "PessengerCollisionBox")
        {
            Pessenger.GetComponent<DestinationPessenger>().YouAreSitting = false;
        }

    }
}
