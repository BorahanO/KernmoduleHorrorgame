using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaMariaKoekoek : MonoBehaviour
{
    // Start is called before the first frame update
    public FollowPlayer followplayer;
    InCameraDetector incameradetector;
    private void Awake()
    {

        followplayer = GetComponent<FollowPlayer>();
        incameradetector = GetComponent<InCameraDetector>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
