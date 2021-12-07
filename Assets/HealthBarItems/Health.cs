using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    private int maxHealth;
    public GameObject explodeOnDestruction;
    
    public void SetHealth(int currentAmount, int maxAmount)
    {
        currentHealth = currentAmount;
        maxHealth = maxAmount;
    }
    public int getHealth()
    {
        return currentHealth;
    }
    public void HitTaken(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            GameObject tempExplosion = Instantiate(explodeOnDestruction, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            Destroy(tempExplosion, 1.0f);

        }
    }
    public void Heal(int amount)
    {
        if (currentHealth + amount > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += amount;
    }

}
