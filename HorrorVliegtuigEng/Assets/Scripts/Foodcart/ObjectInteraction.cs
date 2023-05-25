using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private bool isInteracting = false;
    private GameObject currentObject;
    private Vector3 objectOffset;

    private void Update()
    {
        // Check for object release input
        if (isInteracting && Input.GetKeyUp(KeyCode.E))
        {
            ReleaseObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger area of an interactable object
        if (other.CompareTag("Interactable") && !isInteracting)
        {
            // Display interaction prompt if necessary

            // Check for object pickup input using raycast
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.collider.gameObject == other.gameObject)
                    {
                        PickUpObject(other.gameObject);
                    }
                }
            }
        }
    }

    private void PickUpObject(GameObject obj)
    {
        isInteracting = true;
        currentObject = obj;
        objectOffset = currentObject.transform.position - transform.position;
        currentObject.GetComponent<Rigidbody>().isKinematic = true;
        currentObject.transform.parent = transform;
    }

    private void ReleaseObject()
    {
        isInteracting = false;
        currentObject.transform.parent = null;
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
        currentObject = null;
    }
}