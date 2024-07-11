using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBezierCurve : MonoBehaviour
{
    private Material lineMaterial;
    public Vector3 point0 = new Vector3(-1, 0, 0);
    public Vector3 point1 = new Vector3(-0.5f, 1, 0);
    public Vector3 point2 = new Vector3(0.5f, 1, 0);
    public Vector3 point3 = new Vector3(1, 0, 0);
    public int segments = 100;

    void OnRenderObject()
    {
        // 새로운 material을 생성, 없으면 생성
        if (!lineMaterial)
        {
            var shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            lineMaterial.SetInt("_ZWrite", 0);
        }

        // material 적용
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);

        // 베지어 곡선 그리기
        GL.Begin(GL.LINE_STRIP);
        GL.Color(new Color(0, 1, 0, 1)); // 녹색
        for (int i = 0; i <= segments; i++)
        {
            float t = i / (float)segments;
            Vector3 position = CalculateBezierPoint(t, point0, point1, point2, point3);
            GL.Vertex3(position.x, position.y, position.z);
        }
        GL.End();

        GL.PopMatrix();
    }

    // 베지어 곡선 점 계산 함수
    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0; // 첫 번째 항
        p += 3 * uu * t * p1; // 두 번째 항
        p += 3 * u * tt * p2; // 세 번째 항
        p += ttt * p3; // 네 번째 항

        return p;
    }
}
