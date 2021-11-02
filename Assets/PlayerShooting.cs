using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    private float fireRate = 1f;
    private int damage = 50;
    private int laserSpeed = 5;
    private float timer;

    public GameObject laserEmitter;
    public GameObject laser;
    //public Vector3 target;
    private int score = 0;

    public Text currentScore;
    public Text highScoreText;

    void Start()
    {
        //PlayerPrefs.DeleteKey("HighScore");
        currentScore.text = string.Format("Score: {0}", score);
        highScoreText.text = string.Format("HighScore: {0}", PlayerPrefs.GetInt("HighScore"));
    }
    void Update()
    {
        currentScore.text = string.Format("Score: {0}", score);
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
        GameObject tempLaserHandler;
        tempLaserHandler = Instantiate(laser, laserEmitter.transform.position, laserEmitter.transform.rotation) as GameObject;
        tempLaserHandler.transform.Rotate(Vector3.left * -90);

        Rigidbody tempRigidbody;
        tempRigidbody = tempLaserHandler.GetComponent<Rigidbody>();

        tempRigidbody.AddForce(transform.forward * laserSpeed, ForceMode.VelocityChange);
        //Debug.DrawRay(transform.position, transform.forward * 50, Color.red, 1f);
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
        Destroy(tempLaserHandler, 0.5f);
    }

    public void incrementScore(int amount)
    {
        score += amount;
        currentScore.text = string.Format("Score: {0}", score);
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = string.Format("HighScore: {0}", score);
        }
    }
}
