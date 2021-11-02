using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : MonoBehaviour
{
    public Health health;
    public GameObject playerReference;
    public GameObject laser;

    public float period = 2f;
    private float nextIncrement = 2f;
    private int laserSpeed = 5;
    private float timer;
    private int moveIndex = 0;
    private readonly Vector3[] movementLocations = new Vector3[]{new Vector3(-5,1,-7), new Vector3(6,1,0),
                                                        new Vector3(3,1,-6),  new Vector3(-6,1,0)};
    private int shotDamage = 20;

    void Start()
    {
        playerReference = GameObject.Find("Player");
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        health = GetComponent<Health>();
        health.SetHealth(300, 300);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (playerReference.activeSelf)
        {
            Transform playerTransform = playerReference.transform;
            transform.LookAt(playerTransform);
        }

        if (timer >= nextIncrement)
        {
            timer = 0f;
            transform.position = movementLocations[moveIndex];
            moveIndex++;
            ShootGun();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.SetActive(false);
        }
        if (moveIndex == 4)
        {
            moveIndex = 0;
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
        //Debug.DrawRay(transform.position, transform.forward * 50, Color.black, 1f);
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
