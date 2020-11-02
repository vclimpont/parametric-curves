using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointCurves : MonoBehaviour
{
    public BezierCurve bcurve1;
    public BezierCurve bcurve2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            bcurve2.points[0] = bcurve1.points[bcurve1.points.Length - 1];
            bcurve2.CalculateCurvePoints();
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            bcurve2.points[0] = bcurve1.points[bcurve1.points.Length - 1];
            AlignDirections();
            bcurve2.CalculateCurvePoints();
        }
    }

    void AlignDirections()
    {
        Vector3 dir = (bcurve1.points[bcurve1.points.Length - 1] - bcurve1.points[bcurve1.points.Length - 2]).normalized;
        float dist = (bcurve1.points[bcurve1.points.Length - 1] - bcurve1.points[bcurve1.points.Length - 2]).magnitude;

        bcurve2.points[1] = bcurve2.points[0] + dist * dir;
    }
}
