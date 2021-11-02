using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : MonoBehaviour
{
    public Health health;
    public GameObject playerReference;
    public GameObject laser;

    private int speed = 1;
    private int laserSpeed = 5;
    private float fireRate = 3f;
    private float timer;
    private int shotDamage = 20;

    void Start()
    {
        playerReference = GameObject.Find("Player");
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        health = GetComponent<Health>();
        health.SetHealth(100, 100);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (playerReference.activeSelf)
        {
            Transform playerTransform = playerReference.transform;
            transform.LookAt(playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }

        if (timer >= fireRate)
        {
            ShootGun();
            timer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.SetActive(false);
        }
    }
    void ShootGun()
    {
        GameObject tempLaserHandler;
        tempLaserHandler = Instantiate(laser, transform.position, transform.rotation) as GameObject;
        tempLaserHandler.transform.Rotate(Vector3.left * -90);

        Rigidbody tempRigidbody;
        tempRigidbody = tempLaserHandler.GetComponent<Rigidbody>();

        tempRigidbody.AddForce(transform.forward * laserSpeed, ForceMode.VelocityChange);
        //Debug.DrawRay(transform.position, transform.forward*50, Color.black, 1f);
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
        Destroy(tempLaserHandler, 0.5f);
    }
}
