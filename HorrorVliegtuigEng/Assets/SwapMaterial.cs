using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{

    public Material material1;
    public DestinationPessenger DP;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DP.WeepingAnglesIsActive == true)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = material1;
        }
        
    }
}
