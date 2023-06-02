using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCart : MonoBehaviour
{
    [SerializeField] private LayerMask PushPullMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float PushPullRange;
    [SerializeField] private float PushPullForce;
    private Rigidbody currentObject;
    private bool isPushing = false;
    private bool isPulling = false;
    private Vector3 pushPullDirection;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isPushing && !isPulling)
            {
                StartPush();
            }
            else if (isPushing)
            {
                StopPush();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isPushing && !isPulling)
            {
                StartPull();
            }
            else if (isPulling)
            {
                StopPull();
            }
        }
    }

    void FixedUpdate()
    {
        if (isPushing && currentObject)
        {
            currentObject.velocity = pushPullDirection * PushPullForce;
        }
        else if (isPulling && currentObject)
        {
            currentObject.velocity = -pushPullDirection * PushPullForce;
        }
    }

    void StartPush()
    {
        Ray cameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, PushPullRange, PushPullMask))
        {
            currentObject = hitInfo.rigidbody;
            pushPullDirection = hitInfo.point - transform.position;
            pushPullDirection.Normalize();
            isPushing = true;
        }
    }

    void StopPush()
    {
        currentObject = null;
        isPushing = false;
    }

    void StartPull()
    {
        Ray cameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, PushPullRange, PushPullMask))
        {
            currentObject = hitInfo.rigidbody;
            pushPullDirection = hitInfo.point - transform.position;
            pushPullDirection.Normalize();
            isPulling = true;
        }
    }

    void StopPull()
    {
        currentObject = null;
        isPulling = false;
    }
}
