using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BezierCurve : MonoBehaviour
{
    public int nbPoints;
    public Vector3[] points;

    private CurveRenderer curve;
    private float step;

    private int selectedIndex;
    private bool updated;
    private bool updatedPosition;

    // Start is called before the first frame update
    void Start()
    {
        curve = GetComponent<CurveRenderer>();
        step = 1f / nbPoints;

        CalculateCurvePoints();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            selectedIndex = 0;
            updated = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
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

        if(updated)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                points[selectedIndex] += new Vector3(0, 1, 0);
                updatedPosition = true;
            }
            else if(Input.GetKeyDown(KeyCode.Q))
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

        if(updatedPosition)
        {
            CalculateCurvePoints();
            updatedPosition = false;
        }
    }

    Vector3 BezierCurveCalculation(float t)
    {
        Vector3 Qt = Vector3.zero;
        for (int i = 0; i < points.Length; i++)
        {
            Qt += points[i] * Bernstein(t, i, points.Length - 1);
        }

        return Qt;
    }

    float Bernstein(float u, int i, int n)
    {
        return (float)(Factorial(n) / (Factorial(i) * Factorial(n - i))) * Mathf.Pow(u, i) * Mathf.Pow(1 - u, n - i);
    }

    BigInteger Factorial(int n)
    {
        var k = new BigInteger(1);
        for (int i = 1; i <= n; i++)
        {
            k *= i;
        }

        return k;
    }

    public void CalculateCurvePoints()
    {
        curve.ClearPoints();

        for (float t = 0; t < 1; t += step)
        {
            curve.AddToPoints(BezierCurveCalculation(t));
        }

        curve.DrawCurve();
    }
}
