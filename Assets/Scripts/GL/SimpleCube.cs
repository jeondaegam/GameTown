using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCube : MonoBehaviour
{
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private Material cubeMaterial;
    private float colorLerpSpeed = 1.0f;

    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            // Front
            new Vector3(-1, -1,  1),
            new Vector3( 1, -1,  1),
            new Vector3( 1,  1,  1),
            new Vector3(-1,  1,  1),
            // Back
            new Vector3(-1, -1, -1),
            new Vector3( 1, -1, -1),
            new Vector3( 1,  1, -1),
            new Vector3(-1,  1, -1)
        };

        int[] triangles = new int[]
        {
            // Front
            0, 2, 1,
            0, 3, 2,
            // Back
            4, 5, 6,
            4, 6, 7,
            // Left
            0, 7, 3,
            0, 4, 7,
            // Right
            1, 2, 6,
            1, 6, 5,
            // Top
            3, 7, 6,
            3, 6, 2,
            // Bottom
            0, 1, 5,
            0, 5, 4
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        meshFilter.mesh = mesh;

        //meshRenderer.material = new Material(Shader.Find("Standard"));
        //meshRenderer.material.color = Color.red;

        //meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        //meshRenderer.sharedMaterial.color = Color.black;

        cubeMaterial = new Material(Shader.Find("Standard"));
        cubeMaterial.color = Color.red;
        meshRenderer.material = cubeMaterial;

    }

    // Lerp노드에 의해 실시간으로 변경되는 컬러값을 머터리얼에 적용한다 
    private void Update()
    {
        // 현재 색상 
        //Color currentColor = meshRenderer.material.color;
        //Color currentColor = meshRenderer.sharedMaterial.color;
        Color currentColor = cubeMaterial.color;

        // 파랑색 톤의 목표 색상 (예 : 파랑에서 연두색으로 변환)
        // RGB값 설정하는 것 같은데 핑퐁이 뭐냐 
        Color targetColor = new Color(0.0f, 1.0f, Mathf.PingPong(Time.time * colorLerpSpeed, 1.0f));

        // 부드러운 색상 변경을 위한 Lerp 사용 (VFX의 Lerp 노드)
        //Color lerpedColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * colorLerpSpeed);

        //머터리얼의 색상을 변경된 색상으로 설정
        //meshRenderer.material.color = lerpedColor;
        //meshRenderer.sharedMaterial.color = lerpedColor;

        //cubeMaterial.color = lerpedColor;

        float lerp = Mathf.PingPong(Time.time, colorLerpSpeed) / colorLerpSpeed;
        meshRenderer.material.color = Color.Lerp(currentColor, targetColor, lerp);


    }
}
