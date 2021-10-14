using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    private float fireRate = 1f;
    private int damage = 50;
    private float timer;

    public Vector3 target;
    private int score = 0;
    public string text;
    public Text textelement;

    void Start()
    {
        text = string.Format("Score: {0}", score);
        textelement.text = text;
    }
    void Update()
    {
        textelement.text = text;
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
            {
                timer = 0f;
                ShootGun();
            }
        }
    }

    void ShootGun()
    {
        Debug.DrawRay(transform.position, transform.forward * 50, Color.red, 1f);
        Ray Shot = new Ray(transform.position, transform.forward);

        RaycastHit hitInfo;
        if (Physics.Raycast(Shot, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.HitTaken(damage);
                incrementScore(20);
            }
        }
    }

    public void incrementScore(int amount)
    {
        score += amount;
        text = string.Format("Score: {0}", score);
    }
}
