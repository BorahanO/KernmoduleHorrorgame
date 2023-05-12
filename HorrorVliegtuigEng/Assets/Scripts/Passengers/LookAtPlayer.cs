using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject player;
    public bool lookAt = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }

    void Update()
    {
        if (lookAt == true) 
        {
            transform.LookAt(playerTransform);
        } 
        else
        {
            transform.localEulerAngles = new Vector3(90,180,180);
        }
    }
}
