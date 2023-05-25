using System;
using UnityEngine;

public class PushCart : MonoBehaviour
{
    [SerializeField] private float Speed;
    Rigidbody rb;
    private bool readyToPush;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        readyToPush = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        readyToPush = false;
    }

    private void Update()
    {
        if (readyToPush && Input.GetKeyDown(KeyCode.E))
        {
            rb.velocity = Vector3.forward * Speed;
        }
        
        if (readyToPush && Input.GetKeyDown(KeyCode.F))
        {
            rb.velocity = -Vector3.forward * Speed;
        }
    }
}
