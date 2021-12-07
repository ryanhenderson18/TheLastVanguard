using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour
{
    private float fireRate = 1f;
    private int damage = 50;

    private float shotTimer;
    private float healTimer;
    private int score = 0;

    public Text currentScore;
    public Text highScoreText;

    private string[] EnemyTypes = new string[] { "EasyEnemyBase"};

    void Start()
    {
        currentScore.text = string.Format("Score: {0}", score);
        if (highScoreText)
            highScoreText.text = string.Format("HighScore: {0}", PlayerPrefs.GetInt("HighScore"));
    }
    void Update()
    {
        currentScore.text = string.Format("Score: {0}", score);
        shotTimer += Time.deltaTime;
        if (shotTimer >= fireRate)
        {
            if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
            {
                shotTimer = 0f;
                ShootGun();
            }
        }
    }

    void ShootGun()
    {
        Ray Shot = new Ray(transform.position, transform.forward);

        RaycastHit hitInfo;
        if (Physics.Raycast(Shot, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.HitTaken(damage);
                incrementScore(damage);
                //regretfully could not figure out another way to achieve this. var declarations cannot be vague or set to null
                while (true)
                {
                    var eEnemy = hitInfo.collider.GetComponent<EasyEnemyBase>();
                    if (eEnemy != null)
                    {
                        eEnemy.hitRegistered();
                        break;
                    }
                    var mEnemy = hitInfo.collider.GetComponent<MediumEnemyBase>();
                    if (mEnemy != null)
                    {
                        mEnemy.hitRegistered();
                        break;
                    }
                    var hEnemy = hitInfo.collider.GetComponent<HardEnemyBase>();
                    if (hEnemy != null)
                    {
                        hEnemy.hitRegistered();
                        break;
                    }
                    var bEnemy = hitInfo.collider.GetComponent<BossBase>();
                    if (bEnemy != null)
                    {
                        bEnemy.hitRegistered();
                        break;
                    }
                }
            }
        }
    }

    public void incrementScore(int amount)
    {
        score += amount;
        currentScore.text = string.Format("Score: {0}", score);
        if (score > PlayerPrefs.GetInt("HighScore", 0) && SceneManager.GetActiveScene().name == "Survival")
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = string.Format("HighScore: {0}", score);
        }
    }
}
