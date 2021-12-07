using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyBase : MonoBehaviour
{
    public Health health;
    public HealthBar healthBar;
    public GameObject startingAnimation;

    private float nextIncrement = 3f;
    private float timer;
    private float lockMovement;
    private int moveIndex = 0;

    private readonly Vector3[] movementLocations = new Vector3[]{new Vector3(-5,3,-7), new Vector3(6,3,0),
                                                        new Vector3(3,3,-6),  new Vector3(-6,3,0)};

    void Start()
    {
        health = GetComponent<Health>();
        health.SetHealth(250, 250);
        healthBar.SetMaxHealth(250);
        GameObject spawn = Instantiate(startingAnimation, transform.position, transform.rotation) as GameObject;
        Destroy(spawn, 2.0f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        lockMovement += Time.deltaTime;

        if (timer > nextIncrement && lockMovement >= 2.0f)
        {
            timer = 0f;
            setPosition();
        }
    }

    void setPosition()
    {
        transform.position = movementLocations[moveIndex];
        moveIndex++;
        if (moveIndex == 4)
        {
            moveIndex = 0;
        }
    }

    public void hitRegistered()
    {
        healthBar.SetHealth(health.getHealth());
    }
}
