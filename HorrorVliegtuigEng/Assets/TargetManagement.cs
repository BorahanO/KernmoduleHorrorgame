using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManagement : MonoBehaviour
{
    public List<GameObject> targets;
    public PessengerBehaviour PB;
    public Camera cam;
    public bool insight;

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }

        return true;
    }

    private void Update()
    {

        if(PB.weepingangles == true)
        {
            foreach (var target in targets)
            {
                if (IsVisible(cam, target))
                {
                    target.GetComponent<DestinationPessenger>().weepingAngles = true;
                }
                else
                {
                    target.GetComponent<DestinationPessenger>().weepingAngles = false;
                }
            }
        }
       // Debug.Log(insight);
 
    }
}
