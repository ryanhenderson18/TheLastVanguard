using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class LeftAngledWallCreator : MonoBehaviour
{
    Mesh leftWall;
    Vector3[] vertices;
    int[] triangles;
    void Start()
    {
        transform.position = Vector3.zero;
        leftWall = new Mesh();
        GetComponent<MeshFilter>().mesh = leftWall;
        vertices = new Vector3[] { new Vector3 (-15,10,5),
                                   new Vector3 (-10,10,10),
                                   new Vector3 (-15,0,5),
                                   new Vector3 (-10,0,10)};
        triangles = new int[] { 3, 2, 1, 0, 1, 2 };
        leftWall.vertices = vertices;
        leftWall.triangles = triangles;

        Vector2[] uvs = new Vector2[vertices.Length];
        uvs[0] = new Vector2(0, 1);
        uvs[1] = new Vector2(1, 1);
        uvs[2] = new Vector2(0, 0);
        uvs[3] = new Vector2(1, 0);

        leftWall.uv = uvs;
        leftWall.RecalculateNormals();
    }
}
