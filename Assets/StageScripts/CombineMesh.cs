using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMesh : MonoBehaviour
{
    public void CombineMeshes()
    {
        Quaternion oldRotation = transform.rotation;
        Vector3 oldPosition = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        Mesh CombinedMesh = new Mesh();
        CombineInstance[] combiners = new CombineInstance[filters.Length];
        for(int i = 0; i < filters.Length; i++)
        {
            if (filters[i].transform == transform)
                continue;
            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = filters[i].sharedMesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }
        CombinedMesh.CombineMeshes(combiners);
        GetComponent<MeshFilter>().sharedMesh = CombinedMesh;
        transform.rotation = oldRotation;
        transform.position = oldPosition;

        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
