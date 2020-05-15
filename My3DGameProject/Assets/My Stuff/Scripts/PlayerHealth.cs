using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    public HealthBar healthBar;

    public Text text;
    string message = "You Died";


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(20); //just to test healthbar
        }

        if(currentHealth <= 0)
        {
            text.text = message;         
        }
    }

   public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setMaxHealth(currentHealth);
    }
}
