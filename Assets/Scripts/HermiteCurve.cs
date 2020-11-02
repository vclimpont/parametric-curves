using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermiteCurve : MonoBehaviour
{
    public int nbPoints;
    public Vector2 P0;
    public Vector2 P1;
    public Vector2 V0;
    public Vector2 V1;

    private CurveRenderer curve;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        curve = GetComponent<CurveRenderer>();

        step = 1f / nbPoints;
        for (float u = 0; u < 1; u += step)
        {
            curve.AddToPoints(HermiteCurveCalculation(u));
        }

        curve.DrawCurve();
    }

    Vector2 HermiteCurveCalculation(float u)
    {
        float F1 = 2 * Mathf.Pow(u, 3) - 3 * Mathf.Pow(u, 2) + 1;
        float F2 = -2 * Mathf.Pow(u, 3) + 3 * Mathf.Pow(u, 2);
        float F3 = Mathf.Pow(u, 3) - 2 * Mathf.Pow(u, 2) + u;
        float F4 = Mathf.Pow(u, 3) - Mathf.Pow(u, 2);

        Vector2 pu = F1 * P0 + F2 * P1 + F3 * V0 + F4 * V1;
        return pu;
    }
}
