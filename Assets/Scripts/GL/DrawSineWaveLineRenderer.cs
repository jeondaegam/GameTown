using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSineWaveLineRenderer : MonoBehaviour
{
    public int numPoints = 100;
    public float amplitude = 1.0f;
    public float frequency = 1.0f;
    public float speed = 1.0f;

    private LineRenderer lineRenderer;

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
            float x = t * 2.0f - 1.0f; // x 좌표를 -1에서 1로 정규화
            float y = Mathf.Sin(x * Mathf.PI * frequency + time) * amplitude; // Sine 함수 계산
            Vector3 pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);
        }
    }
}
