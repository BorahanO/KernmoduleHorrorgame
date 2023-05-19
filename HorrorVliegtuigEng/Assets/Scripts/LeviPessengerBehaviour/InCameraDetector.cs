using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{

    public Camera camera;
    MeshRenderer renderer;
    Plane[] cameraFrustum;
    Collider collider;
    public bool insight = true;
    public bool insight2;

    public DubbleCheckInsight dubbelcheckInsight;

    PessengerBehaviour PB;

    // Start is called before the first frame update
    void Start()
    {
        dubbelcheckInsight = GetComponent<DubbleCheckInsight>();
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        collider = GetComponent<Collider>();

        if (insight2 == true)
        {
            insight = true;
        }
        //Debug.Log(insight);
        // als gameobject is camera zicht is dan gaat er een boolean aan of uit
        // dit werkt blijkbaar alleen met meshrenderer of kleur ofzo 
        // maar alleen een boolean heeft hij blijkbaar problemen. 

        var Pessenger = this.gameObject.transform.position;

        var bounds = collider.bounds;

        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            insight = true;
        }
        else
        {
            insight = false;
        }

        Debug.DrawLine(bounds.center, bounds.size);
    }

}
