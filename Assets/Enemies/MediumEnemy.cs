using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : MonoBehaviour
{
    public Health health;
    public int speed = 3;

    private float fireRate = 2f;
    private float timer;
    private int shotDamage = 30;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        health = GetComponent<Health>();
        health.SetHealth(200, 200);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            ShootGun();
            timer = 0f;
        }
        Transform playerTransform = GameObject.Find("Player").transform;
        transform.LookAt(playerTransform);
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

    }

    void ShootGun()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.black, 2f);
        Ray shot = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(shot, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.HitTaken(shotDamage);
            }
        }
    }
}
