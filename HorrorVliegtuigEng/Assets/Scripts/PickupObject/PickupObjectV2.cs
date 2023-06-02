using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjectV2 : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float PickupRange;
    [SerializeField] private LayerMask TargetLayer;
    private GameObject currentItem;
    private bool isObjectVisible = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isObjectVisible)
            {
                HideObject();
            }
            else
            {
                ShowObject();
            }
        }
    }

    void HideObject()
    {
        Ray cameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, PickupRange, TargetLayer))
        {
            currentItem = hitInfo.collider.gameObject;
            currentItem.SetActive(false);
            isObjectVisible = false;
        }
    }

    void ShowObject()
    {
        if (currentItem != null)
        {
            currentItem.SetActive(true);
            currentItem.transform.position = PlayerCamera.transform.position + PlayerCamera.transform.forward * 2f;
            currentItem.transform.rotation = PlayerCamera.transform.rotation;
            currentItem = null;
            isObjectVisible = true;
        }
    }
}