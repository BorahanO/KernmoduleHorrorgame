using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullObject : MonoBehaviour
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
            ApplyPushForce();
        }
        else if (isPulling && currentObject)
        {
            ApplyPullForce();
        }
    }

    void StartPush()
    {
        Ray cameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, PushPullRange, PushPullMask))
        {
            currentObject = hitInfo.rigidbody;
            pushPullDirection = GetHorizontalDirection(hitInfo.point - transform.position);
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
            pushPullDirection = GetHorizontalDirection(hitInfo.point - transform.position);
            isPulling = true;
        }
    }

    void StopPull()
    {
        currentObject = null;
        isPulling = false;
    }

    void ApplyPushForce()
    {
        Vector3 pushForce = pushPullDirection * PushPullForce;
        pushForce.y = currentObject.velocity.y;
        currentObject.velocity = pushForce;
    }

    void ApplyPullForce()
    {
        Vector3 pullForce = -pushPullDirection * PushPullForce;
        pullForce.y = currentObject.velocity.y;
        currentObject.velocity = pullForce;
    }

    Vector3 GetHorizontalDirection(Vector3 direction)
    {
        direction.y = 0f;
        return direction.normalized;
    }
}
