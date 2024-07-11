using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawHeart : MonoBehaviour
{
    public float maxScale = 2.0f; // 하트의 최대 크기
    public float minScale = 0.5f; // 하트의 최소 크기
    public float lerpSpeed = 1.0f; // 크기 변경 속도

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Material heartMaterial; // 하트의 머테리얼

    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>(); // MeshFilter 추가
        meshRenderer = gameObject.AddComponent<MeshRenderer>(); // MeshRenderer 추가

        Mesh mesh = new Mesh();

        // 하트 모양의 정점 배열
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 2, 0),
            new Vector3(2, 1, 0),
            new Vector3(1, -1, 0),
            new Vector3(-1, -1, 0),
            new Vector3(-2, 1, 0),
            new Vector3(-1, 2, 0)
        };

        // 삼각형 배열
        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 6,
            0, 6, 1
        };

        // Mesh에 정점과 삼각형 설정
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        meshFilter.mesh = mesh;

        // 하트의 머테리얼 생성 및 설정
        heartMaterial = new Material(Shader.Find("Standard")); // 적절한 셰이더를 선택해야 함
        heartMaterial.color = Color.red; // 초기 색상 설정
        meshRenderer.material = heartMaterial;
    }

    void Update()
    {
        // 현재 스케일 값을 보간하여 변경
        float scale = Mathf.PingPong(Time.time * lerpSpeed, 1.0f) * (maxScale - minScale) + minScale;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
