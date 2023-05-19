using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManagement : MonoBehaviour
{
    public List<GameObject> targets;
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

       // Debug.Log(insight);
        foreach (var target in targets)
        {
            if (IsVisible(cam, target))
            {
                Debug.Log(target);
                insight = true;
            }
            else
            {
                insight = false;
            }
        }
    }
}
