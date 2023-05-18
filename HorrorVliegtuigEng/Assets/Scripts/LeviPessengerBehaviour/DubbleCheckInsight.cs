using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DubbleCheckInsight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("inside2" + insight2);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 6)
        {
            Debug.Log("hallo");
        }
        if (other.gameObject.tag == "Pessenger")
        {
            Debug.Log("hallo");
            other.gameObject.GetComponent<InCameraDetector>().insight2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("hallo");
        }


        if (other.gameObject.tag == "Pessenger")
        {
            other.gameObject.GetComponent<InCameraDetector>().insight2 = false;
        }

    }

}
