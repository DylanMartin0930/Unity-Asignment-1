using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 4; 
    public int health; 
    public HealthBar healthbar; 
    void Start()
    {
        health = maxHealth; 
        healthbar.SetMaxHealthBar(health); 
    }

    public void TakeDamage(int damage){
        health -= damage;
        healthbar.SetHealthBar(health);
        if(health <= 0){
            Destroy(gameObject); 
        }
         
    }

 
}
