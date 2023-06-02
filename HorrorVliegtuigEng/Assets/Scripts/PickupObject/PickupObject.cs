using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    public Rigidbody CurrentObject;

    [SerializeField] private float scrollSpeed = 0.1f; // New variable for scroll speed adjustment

    void Update()
    {
        // Scrolling input for adjusting PickupTarget position
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        PickupTarget.position += PlayerCamera.transform.forward * scrollInput * scrollSpeed;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {
                CurrentObject.GetComponent<BoxCollider>().enabled = true;
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                CurrentObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}