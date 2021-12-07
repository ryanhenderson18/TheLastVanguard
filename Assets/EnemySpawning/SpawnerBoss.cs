using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    public GameObject boss;

    void Start()
    {
        Instantiate(boss, new Vector3(0, 2, -4), Quaternion.identity);
    }
}