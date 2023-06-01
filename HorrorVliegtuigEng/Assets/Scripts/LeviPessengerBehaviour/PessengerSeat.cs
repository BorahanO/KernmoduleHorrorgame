using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PessengerSeat : MonoBehaviour
{

    public GameObject Pessenger;
    public Passenger_Manager PM;
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
            Pessenger.GetComponent<DestinationPessenger>().YouAreSitting = true;
            Debug.Log("jij zit nu");
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
