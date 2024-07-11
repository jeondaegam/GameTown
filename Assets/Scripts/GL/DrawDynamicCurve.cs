using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDynamicCurve : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public int numPoints = 100;
    public float curveHeight = 2.0f;
    public float curveWidth = 5.0f;
    public float speed = 1.0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numPoints;
    }

    void Update()
    {
        float time = Time.time * speed;
        for (int i = 0; i < numPoints; i++)
        {
            float t = i / (float)(numPoints - 1);
            float x = Mathf.Lerp(-curveWidth, curveWidth, t); // x 좌표를 -curveWidth에서 curveWidth 사이에서 보간
            float y = Mathf.Sin(x * Mathf.PI + time) * curveHeight; // Sine 곡선을 통해 y 좌표 계산
            Vector3 pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);
        }
    }
}
