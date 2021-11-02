using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public GameObject laserEmitter;
    public GameObject laser;

    public float laserSpeed;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        laserSpeed = 5f;
        damage = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            GameObject tempLaserHandler;
            tempLaserHandler = Instantiate(laser, laserEmitter.transform.position, laserEmitter.transform.rotation) as GameObject;
            tempLaserHandler.transform.Rotate(Vector3.left * -90);

            Rigidbody tempRigidbody;
            tempRigidbody = tempLaserHandler.GetComponent<Rigidbody>();
            
            tempRigidbody.AddForce(transform.forward * laserSpeed, ForceMode.VelocityChange);
            Ray Shot = new Ray(transform.position, transform.forward);

            RaycastHit hitInfo;
            if (Physics.Raycast(Shot, out hitInfo, 100))
            {
                var health = hitInfo.collider.GetComponent<Health>();
                if (health != null)
                {
                    health.HitTaken(damage);
                }
            }
        }
    }
}
