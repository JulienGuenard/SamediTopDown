using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public Slider healthBar;


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }

        healthBar.value = currentHealth;
    }
}