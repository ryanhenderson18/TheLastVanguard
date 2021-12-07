using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public HealthBar HealthBar;
    public HealthBar HealBar;
    public GameObject spawnAnimation;
    private Health healthVariable;

    private int playerSpeed = 7;
    private int rotationSpeed = 1100;
    private float lockMovementTimer;

    private float healCooldown = 15f;
    private int healAmount = 40;
    private int healBarIncrementer = 0;
    private float healTimer;
    private float healBarTimer;

    void Start()
    { 
        healthVariable = GetComponent<Health>();
        healthVariable.SetHealth(100, 100);

        HealthBar.SetMaxHealth(100);
        HealBar.SetMaxHealth(15);
        HealBar.SetHealth(0);
        GameObject spawn = Instantiate(spawnAnimation, transform.position, transform.rotation);
        Destroy(spawn, 2.0f);
    }
    
    void Update()
    {
        lockMovementTimer += Time.deltaTime;
        healTimer += Time.deltaTime;
        healBarTimer += Time.deltaTime;

        if (healBarTimer >= 1)
        {
            healBarIncrementer++;
            if (healBarIncrementer <= 15)
                HealBar.SetHealth(healBarIncrementer);
            healBarTimer = 0f;
        }

        if (healTimer >= healCooldown && Input.GetKeyDown(KeyCode.H))
        {
            healthVariable.Heal(healAmount);
            HealthBar.SetHealth(healthVariable.getHealth());
            HealBar.SetHealth(0);
            healTimer = 0f;
            if (healBarIncrementer >= 15)
                healBarIncrementer = 0;
        }

        if (lockMovementTimer >= 2.0f)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0, vertical);
            direction.Normalize();
            transform.Translate(direction * playerSpeed * Time.deltaTime, Space.World);
            if (direction != Vector3.zero)
            {
                Quaternion rotate = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, rotationSpeed * Time.deltaTime);
            }
        }
    }
    public void hitRegistered()
    {
        HealthBar.SetHealth(healthVariable.getHealth());
    }
}
