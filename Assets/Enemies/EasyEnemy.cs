using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : MonoBehaviour
{
    public Health health;
    private int speed = 1;
    private float fireRate = 3f;
    private float timer;
    private int shotDamage = 20;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        health = GetComponent<Health>();
        health.SetHealth(100, 100);
    }

    void Update()
    {
        timer += Time.deltaTime;
        var playerTransform = GameObject.Find("Player").transform;

        transform.LookAt(playerTransform);
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        if (timer >= fireRate)
        {
            ShootGun();
            timer = 0f;
        }  
    }
    void ShootGun()
    {
        Debug.DrawRay(transform.position, transform.forward*50, Color.black, 1f);
        Ray Shot = new Ray(transform.position, transform.forward);

        RaycastHit hitInfo;
        if (Physics.Raycast(Shot, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.HitTaken(shotDamage);
            }
        }
    }
}
