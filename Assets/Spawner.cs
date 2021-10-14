using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject easyEnemy;
    public GameObject mediumEnemy;
    public GameObject hardEnemy;

    private int spawnedHard = 0;
    private int enemyCount = 0;
    private int Max = 7;
    private Vector3[] spawnPoints = new Vector3[] { new Vector3(-11, 1, 6), new Vector3(-11, 1, -9),
                                                    new Vector3(11, 1, 6),  new Vector3(11, 1, -9)};
    void Start()
    {
        StartCoroutine(spawner());
    }

    IEnumerator spawner()
    {
        while(enemyCount < Max)
        {
            int spawnChoice = Random.Range(0,4);
            int EnemySpawnChoice = Random.Range(0, 3);
            if (EnemySpawnChoice <= 0)
                Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity);
            if (EnemySpawnChoice == 1)
                Instantiate(mediumEnemy, spawnPoints[spawnChoice], Quaternion.identity);
            if (EnemySpawnChoice == 2 && spawnedHard < 1)
            {
                Instantiate(hardEnemy, spawnPoints[spawnChoice], Quaternion.identity);
                spawnedHard++;
            }
            enemyCount++;
            yield return new WaitForSeconds(5);
        }
        
    }

}
