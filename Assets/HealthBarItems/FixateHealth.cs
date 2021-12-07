using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixateHealth : MonoBehaviour
{
    private Transform mainCamera;
    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.forward);
    }
}
