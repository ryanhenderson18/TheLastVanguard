using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSurvival : MonoBehaviour
{
    public GameObject easyEnemy;
    public GameObject mediumEnemy;
    public GameObject hardEnemy;

    public GameObject playerReference;

    private float gameTime;
    private float interval = 120;

    private int difficulty = 0;

    private List<GameObject> clones = new List<GameObject>();

    private Vector3[] spawnPoints = new Vector3[] { new Vector3(-11, 1, 6), new Vector3(-11, 1, -9),
                                                    new Vector3(11, 1, 6),  new Vector3(11, 1, -9)};
    void Start()
    {
        StartCoroutine(spawnEnemies());
    }
    //void Update()
    //{
    //    //done to advance difficulty incrementally
    //    gameTime += Time.deltaTime;
    //    if (gameTime >= interval)
    //    {
    //        difficulty++;
    //        gameTime = 0f;
    //    }
    //}
    IEnumerator spawnEnemies()
    {
        //only do while player is alive
        while (playerReference.activeSelf)
        {
            int alive = getActiveCount();
            //at most 4 active enemies at a time
            if (alive < 4)
            {
                int spawnChoice = Random.Range(0, 4);
                int enemyChoice = Random.Range(0, 101);
                //chooses and spawns an enemy with the given constraints
                SpawnHelper(difficulty, enemyChoice, spawnChoice);
                //if (enemyChoice <= 60)
                //{
                //    clones.Add(Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity));
                //}
                //else if (enemyChoice > 60 && enemyChoice <= 90 || hardEnemySpawned())
                //{
                //    clones.Add(Instantiate(mediumEnemy, spawnPoints[spawnChoice], Quaternion.identity));
                //}
                //else
                //{
                //    clones.Add(Instantiate(hardEnemy, spawnPoints[spawnChoice], Quaternion.identity));
                //}
            }
            difficulty++;
            yield return new WaitForSeconds(5);
        }
    }

    public int getActiveCount()
    {
        int number = 0;
        foreach(GameObject clone in clones)
        {
            if (clone.activeSelf)
                number++;
        }
        return number;
    }

    public bool hardEnemySpawned()
    {
        foreach(GameObject clone in clones)
        {
            if (clone.activeSelf)
            {
                if (clone.name == "HardEnemy(Clone)")
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void SpawnHelper(int difficulty, int randomValue, int spawnChoice)
    {
        //easist difficulty
        if (difficulty == 0)
        {
            //ratios: easy = 80%, med = 20%
            if (randomValue <= 80)
            {
                clones.Add(Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
            else
            {
                clones.Add(Instantiate(mediumEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
        }
        else if (difficulty == 1)
        {
            //ratios: easy = 60%, medium = 40%
            if (randomValue <= 60)
            {
                clones.Add(Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
            else
            {
                clones.Add(Instantiate(mediumEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
        }
        else if (difficulty == 2)
        {
            //ratios: easy = 40%, med = 40%, hard = 10%
            if (randomValue <= 40)
            {
                clones.Add(Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
            //medium enemy will be spawned if there is already an active hard enemy
            else if (randomValue > 40 && randomValue <= 90 || hardEnemySpawned())
            {
                clones.Add(Instantiate(mediumEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
            else
            {
                clones.Add(Instantiate(hardEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }

        }
        //hardest difficulty
        else
        {
            //ratios: easy = 20%, med = 40%, hard = 40% 
            if (randomValue <= 20)
            {
                clones.Add(Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
            else if (randomValue > 20 && randomValue <= 60 || hardEnemySpawned())
            {
                clones.Add(Instantiate(mediumEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
            else
            {
                clones.Add(Instantiate(hardEnemy, spawnPoints[spawnChoice], Quaternion.identity));
            }
        }
    }
}
