using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class RightAngledWallCreator : MonoBehaviour
{
    Mesh rightWall;
    Vector3[] vertices;
    int[] triangles;
    void Start()
    {
        transform.position = Vector3.zero;
        rightWall = new Mesh();
        GetComponent<MeshFilter>().mesh = rightWall;
        vertices = new Vector3[] { new Vector3 (10,0,10),
                                   new Vector3 (10,10,10),
                                   new Vector3 (15,10,5),
                                   new Vector3 (15,0,5)};
        triangles = new int[] { 0, 1, 2, 3, 0, 2 };
        rightWall.vertices = vertices;
        rightWall.triangles = triangles;

        Vector2 [] uvs = new Vector2[vertices.Length];
        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(0, 1);
        uvs[2] = new Vector2(1, 1);
        uvs[3] = new Vector2(1, 0);

        rightWall.uv = uvs;
        rightWall.RecalculateNormals();
    }
}
