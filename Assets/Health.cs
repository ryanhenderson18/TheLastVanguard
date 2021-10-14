using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    private int maxHealth;
    
    public void SetHealth(int currentAmount, int maxAmount)
    {
        currentHealth = currentAmount;
        maxHealth = maxAmount;
    }
    
    public void HitTaken(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            gameObject.SetActive(false);
    }
    public void Heal(int amount)
    {
        if (currentHealth + amount > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += amount;
    }
}
