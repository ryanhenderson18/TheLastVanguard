using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerL3 : MonoBehaviour
{
    public GameObject easyEnemy;
    public GameObject mediumEnemy;

    private List<GameObject> clones = new List<GameObject>();

    private int maxSpawned = 14;
    private Vector3[] spawnPoints = new Vector3[] { new Vector3(-11, 2, 6), new Vector3(-11, 2, -9),
                                                    new Vector3(11, 2, 6),  new Vector3(11, 2, -9)};

    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        while (clones.Count < maxSpawned)
        {
            int number = getActiveCount();
            //2 enemies max at any one time
            if (number < 2)
            {
                int randomEnemyChoice = Random.Range(0, 101);
                int spawnChoice = Random.Range(0, 4);

                //maintains that an easy enemy will be spawned 50% of the time
                if (randomEnemyChoice < 50)
                {
                    clones.Add(Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity));
                }
                else
                {
                    clones.Add(Instantiate(mediumEnemy, spawnPoints[spawnChoice], Quaternion.identity));
                }
            }
            yield return new WaitForSeconds(5);
        }
    }

    public int getActiveCount()
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