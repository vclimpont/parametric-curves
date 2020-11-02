using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Assertions;

public class MatrixBezierCurve : MonoBehaviour
{
    public int nbPoints;
    public Vector3[] points;

    private CurveRenderer curve;
    private float[,] vec_t;
    private float[,] mat_coefs;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        curve = GetComponent<CurveRenderer>();

        vec_t = new float[1,4];
        mat_coefs = new float[,] { { -1, 3, -3, 1 }, { 3, -6, 3, 0 }, { -3, 3, 0, 0 }, { 1, 0, 0, 0 } };
        step = 1f / nbPoints;

        CalculateCurvePoints();
    }

    Vector3 BezierCurveCalculation(float t)
    {
        for (int i = 0; i < vec_t.Length; i++)
        {
            vec_t[0,i] = Mathf.Pow(t, vec_t.Length - 1 - i);
        }

        float[,] B = CalculateMatrix(vec_t, mat_coefs);

        Vector3 Qt = Vector3.zero;
        for (int j = 0; j < B.GetLength(1); j++)
        {
            Qt += (B[0, j] * points[j]);
        }

        return Qt;
    }

    float[,] CalculateMatrix(float[,] A, float[,] B)
    {
        Assert.IsTrue(A.GetLength(1) == B.GetLength(0));

        float[,] M = new float[A.GetLength(0), B.GetLength(1)];

        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                float v = 0;
                for (int k = 0; k < A.GetLength(1); k++)
                {
                    v += (A[i, k] * B[k, j]);
                }
                M[i, j] = v;
            }
        }

        return M;
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
