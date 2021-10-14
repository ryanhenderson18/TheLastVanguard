using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    public Health health;
    public float period = 2.0f;
    private float nextIncrement = 0.0f;
    private readonly Vector3[] movementLocations = new Vector3[]{new Vector3(-5,1,-7), new Vector3(6,1,0),
                                                        new Vector3(3,1,-6),  new Vector3(-6,1,0)};
    private int shotDamage = 20;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        health = GetComponent<Health>();
        health.SetHealth(300, 300);
    }

    void Update()
    {
        if (Time.time > nextIncrement)
        {
            nextIncrement += period;
            ChangeLocation();
            ShootGun();
        }
        Transform playerTransform = GameObject.Find("Player").transform;
        transform.LookAt(playerTransform);

    }
    void ChangeLocation()
    {
        int moveLocation = Random.Range(0, 4);
        while (movementLocations[moveLocation] == transform.position)
        {
            moveLocation = Random.Range(0, 4);
        }
        transform.position = movementLocations[moveLocation];
    }

    void ShootGun()
    {
        Debug.DrawRay(transform.position, transform.forward * 50, Color.black, 1f);
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
