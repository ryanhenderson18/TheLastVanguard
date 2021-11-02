using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : MonoBehaviour
{
    public Health health;
    public int speed = 3;
    public GameObject playerReference;
    public GameObject laser;

    private float fireRate = 2f;
    private float timer;
    private int laserSpeed = 5;
    private int shotDamage = 30;

    void Start()
    {
        playerReference = GameObject.Find("Player");
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
        if (playerReference.activeSelf)
        {
            Transform playerTransform = playerReference.transform;
            transform.LookAt(playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
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
        //Debug.DrawRay(transform.position, transform.forward * 100, Color.black, 2f);
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
