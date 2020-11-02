using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveRenderer : MonoBehaviour
{
    public float width;
    public Material material;

    private LineRenderer line;
    private List<Vector3> points;

    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
        points = new List<Vector3>();
    }

    void SetupLine()
    {
        line.sortingLayerName = "Line";
        line.sortingOrder = 5;

        SetupVertices();

        line.startWidth = width;
        line.endWidth = width;
        line.useWorldSpace = true;
        line.material = material;
    }

    void SetupVertices()
    {
        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }

    public void DrawCurve()
    {
        SetupLine();
    }

    public void AddToPoints(Vector3 p)
    {
        points.Add(p);
    }

    public void ClearPoints()
    {
        points.Clear();
    }
}
