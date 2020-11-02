using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaikin : MonoBehaviour
{
    public Vector3[] points;

    private CurveRenderer curve;

    // Start is called before the first frame update
    void Start()
    {
        curve = GetComponent<CurveRenderer>();

        CalculateCurvePoints();
        curve.DrawCurve();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Subdivise();
            CalculateCurvePoints();
            curve.DrawCurve();
        }
    }

    void Subdivise()
    {
        List<Vector3> subPoints = new List<Vector3>();

        for (int i = 0; i < points.Length; i++)
        {
            if(i == points.Length - 1)
            {
                subPoints.Add(points[i] * 0.75f + points[0] * 0.25f);
                subPoints.Add(points[i] * 0.25f + points[0] * 0.75f);
            }
            else
            {
                subPoints.Add(points[i] * 0.75f + points[i + 1] * 0.25f);
                subPoints.Add(points[i] * 0.25f + points[i + 1] * 0.75f);
            }
        }

        points = subPoints.ToArray();
    }

    void CalculateCurvePoints()
    {
        curve.ClearPoints();

        for (int i = 0; i < points.Length; i++)
        {
            curve.AddToPoints(points[i]);
        }
    }
}
