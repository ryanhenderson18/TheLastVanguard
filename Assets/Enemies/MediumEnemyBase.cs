using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyBase : MonoBehaviour
{
    public Health health;
    public HealthBar healthBar;
    public GameObject startingAnimation;
    private GameObject playerReference;
    private float lockMovementTimer;

    private int speed = 2;

    void Start()
    {
        playerReference = GameObject.Find("Player");
        health = GetComponent<Health>();
        health.SetHealth(200, 200);
        healthBar.SetMaxHealth(200);
        GameObject spawn = Instantiate(startingAnimation, transform.position, transform.rotation) as GameObject;
        Destroy(spawn, 2.0f);
    }

    void Update()
    {
        lockMovementTimer += Time.deltaTime;
        if (playerReference.activeSelf && lockMovementTimer >= 2.0f)
        {
            Transform playerTransform = playerReference.transform;
            Quaternion desiredRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * 2);
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    public void hitRegistered()
    {
        healthBar.SetHealth(health.getHealth());
    }
}
