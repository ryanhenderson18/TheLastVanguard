using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;

    private float delayShot;
    private float timer;
    private float period = 2f;
    private float range;

    private int damageAmount;
    private string EnemyType;

    void Start()
    {
        EnemyType = gameObject.transform.parent.name;
        switch (EnemyType)
        {
            case "EasyEnemy(Clone)":
                damageAmount = 10;
                range = 5;
                break;
            case "MediumEnemy(Clone)":
                //three barrels does a lot of damage :)
                damageAmount = 7;
                range = 5;
                break;
            case "HardEnemy(Clone)":
                damageAmount = 30;
                range = 5;
                break;
            case "Boss(Clone)":
                damageAmount = 10;
                period = 1f;
                range = 10;
                break;
        }
    }
    void Update()
    {
        delayShot += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= period && delayShot >= 4f)
        {
            timer = 0f;
            shootGun();
        }
    }

    void shootGun()
    {
        GameObject flash = Instantiate(particle, transform.position, transform.rotation) as GameObject;
        Destroy(flash, 0.25f);
        Ray Shot = new Ray(transform.position, transform.forward);

        RaycastHit hitInfo;
        if (Physics.Raycast(Shot, out hitInfo, range))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            var player = hitInfo.collider.GetComponent<PlayerBase>();
            if (health != null && player != null)
            {
                health.HitTaken(damageAmount);
                player.hitRegistered();
            }
        }
    }
}
