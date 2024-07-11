using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGLExample : MonoBehaviour
{
    private Material lineMaterial;

    void OnRenderObject()
    {
        // 새로운 material을 생성, 없으면 생성
        if (!lineMaterial)
        {
            // Unity에 내장된 간단한 색상을 그리기에 유용한 셰이더를 사용
            var shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // 알파 블렌딩 켜기
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // 후면 컬링 끄기
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // 깊이 쓰기 끄기
            lineMaterial.SetInt("_ZWrite", 0);
        }

        // material 적용
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        // 그리기 위한 변환 행렬을 우리의 변환에 맞추기
        GL.MultMatrix(transform.localToWorldMatrix);

        // 간단한 삼각형 그리기
        GL.Begin(GL.TRIANGLES);
        GL.Color(new Color(1, 0, 0, 0.5f)); // 빨간색, 반투명
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(1, 0, 0);
        GL.Vertex3(0, 1, 0);
        GL.End();

        GL.PopMatrix();
    }
}
