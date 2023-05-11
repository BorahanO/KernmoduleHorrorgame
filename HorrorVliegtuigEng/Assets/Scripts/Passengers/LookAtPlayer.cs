using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public bool lookAt = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (lookAt == true) 
        {
            transform.LookAt(player);
        } 
        else
        {
            transform.localEulerAngles = new Vector3(90,180,180);
        }
    }
}
