using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSurvival : MonoBehaviour
{
    public GameObject easyEnemy;
    public GameObject mediumEnemy;
    public GameObject hardEnemy;

    public GameObject playerReference;


    private List<GameObject> clones = new List<GameObject>();

    private Vector3[] spawnPoints = new Vector3[] { new Vector3(-11, 2, 6), new Vector3(-11, 2, -9),
                                                    new Vector3(11, 2, 6),  new Vector3(11, 2, -9), new Vector3(11,3,6)};
    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        while (playerReference.activeSelf)
        {
            int number = getActiveCount();
            //4 enemies max at any one time
            if (number < 4)
            {
                int randomEnemyChoice = Random.Range(0, 101);
                int spawnChoice = Random.Range(0, 4);

                //maintains that an easy enemy will be spawned 25% of the time
                if (randomEnemyChoice < 40)
                {
                    clones.Add(Instantiate(easyEnemy, spawnPoints[spawnChoice], Quaternion.identity));
                }
                else if (randomEnemyChoice >= 40 && randomEnemyChoice < 80)
                {
                    clones.Add(Instantiate(mediumEnemy, spawnPoints[spawnChoice], Quaternion.identity));
                }
                else if (randomEnemyChoice >= 80 && getActiveHardEnemies() == 0)
                {
                    //hard coded a spawn point for hard enemies because the modeling is different
                    clones.Add(Instantiate(hardEnemy, spawnPoints[4], Quaternion.identity));
                }
                //only gets here if hard enemy chosen but already has one spawned
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
    public int getActiveHardEnemies()
    {
        int number = 0;
        foreach (GameObject clone in clones)
        {
            if (clone.activeSelf && clone.name == "HardEnemy(Clone)")
                number++;
        }
        return number;
    }
}