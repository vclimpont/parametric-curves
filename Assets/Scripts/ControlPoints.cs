using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoints : MonoBehaviour
{
    public Vector3[] points;

    private CurveRenderer curve;
    private int selectedIndex;
    private bool updated;
    private bool updatedPosition;

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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selectedIndex = 0;
            updated = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedIndex = 1;
            updated = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedIndex = 2;
            updated = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedIndex = 3;
            updated = true;
        }

        if (updated)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                points[selectedIndex] += new Vector3(0, 1, 0);
                updatedPosition = true;
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                points[selectedIndex] += new Vector3(-1, 0, 0);
                updatedPosition = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                points[selectedIndex] += new Vector3(0, -1, 0);
                updatedPosition = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                points[selectedIndex] += new Vector3(1, 0, 0);
                updatedPosition = true;
            }
        }

        if (updatedPosition)
        {
            CalculateCurvePoints();
            curve.DrawCurve();

            updatedPosition = false;
        }
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
