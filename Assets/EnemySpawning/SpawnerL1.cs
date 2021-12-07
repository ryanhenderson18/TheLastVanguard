using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerL1 : MonoBehaviour
{
    public GameObject easyEnemy;
    private List<GameObject> clones = new List<GameObject>();
    private int maxSpawned = 10;
    private Vector3[] spawnPoints = new Vector3[] { new Vector3(-11, 2, 6), new Vector3(-11, 2, -9),
                                                    new Vector3(11, 2, 6),  new Vector3(11, 2, -9)};
    void Start()
    {
        StartCoroutine(spawner());
    }

    IEnumerator spawner()
    {
        while (clones.Count < maxSpawned)
        {
            int alive = getActiveCount();
            //only want to have 2 enemies at a max at any time
            if (alive < 2)
            {
                int spawnChoice = Random.Range(0, 4);
                clones.Add(Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
            yield return new WaitForSeconds(5);
        }
    }

    private int getActiveCount()
    {
        int number = 0;
        foreach (GameObject clone in clones)
        {
            if (clone.activeSelf)
                number++;
        }
        return number;
    }

}
