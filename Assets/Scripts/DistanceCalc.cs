using UnityEngine;
using System.Collections;

public class DistanceCalc : MonoBehaviour
{
    public GameObject HandLocation;

    public GameObject Plane;

    void Update()
    {
        int divider = 8;

        var distance = Vector3.Distance(HandLocation.transform.position, Plane.transform.position);

        var planeScaleX = Plane.transform.localScale;
        planeScaleX = Plane.transform.localScale = new Vector3(distance/divider, distance/divider, distance/divider);

        //transform.localScale += new Vector3(0.1F, 0, 0);

        //Debug.Log("distance = " + distance);
    }
}