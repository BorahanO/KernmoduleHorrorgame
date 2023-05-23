using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConvo : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private float range;
    [SerializeField] private QuestManager manager;
    [SerializeField] private bool hasBeenShown;

    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
        hasBeenShown = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, range, mask) && !hasBeenShown)
            {
                StartCoroutine(ShowText());
            }
        }

    }

    private IEnumerator ShowText()
    {
        text.SetActive(true);
        manager.advanceQuest(manager.activeQuest);
        hasBeenShown = true;
        yield return new WaitForSeconds(5f);
        text.SetActive(false);
    }
}
