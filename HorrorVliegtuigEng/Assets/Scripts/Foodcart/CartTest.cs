using UnityEngine;

public class CartTest : MonoBehaviour
{
    public float pushForce = 10f;
    public float pullForce = 5f;
    private Rigidbody playerRb;
    private Rigidbody objectRb;
    private bool isPulling = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isPulling)
                StartPullingObject();
            else
                StopPullingObject();
        }
    }

    private void FixedUpdate()
    {
        if (isPulling)
        {
            Vector3 pullDirection = (transform.position - objectRb.transform.position).normalized;
            objectRb.AddForce(pullDirection * pullForce, ForceMode.Force);
        }
    }

    private void StartPullingObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            objectRb = hit.collider.GetComponent<Rigidbody>();
            if (objectRb != null)
            {
                isPulling = true;
                objectRb.isKinematic = false;
                objectRb.useGravity = false;
            }
        }
    }

    private void StopPullingObject()
    {
        isPulling = false;
        objectRb.isKinematic = true;
        objectRb.useGravity = true;
    }
}