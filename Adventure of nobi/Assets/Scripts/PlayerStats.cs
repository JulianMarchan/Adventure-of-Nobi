using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ito yung main stats ng player hindi yung "player.cs"
public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetButtonDown("Crouch"))
    {
        TakeDamage(20);
    }
    }
      void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
