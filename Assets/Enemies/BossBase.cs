using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    public Health healthVariable;
    public HealthBar healthBar;
    public GameObject startingAnimation;

    private int rotationSpeed = 50;
    private float lockMovement;
    void Start()
    {
        healthVariable = GetComponent<Health>();
        healthVariable.SetHealth(500, 500);
        healthBar.SetMaxHealth(500);
        GameObject spawn = Instantiate(startingAnimation, transform.position, transform.rotation) as GameObject;
        Destroy(spawn, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        lockMovement += Time.deltaTime;
        if (lockMovement >= 2.0f)
        {
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);
            //transform.Rotate(transform.rotation.x, transform.rotation.y + 1, transform.rotation.z);
        }
    }

    public void hitRegistered()
    {
        healthBar.SetHealth(healthVariable.getHealth());
    }
}
