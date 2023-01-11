using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;
    private float invincibleCounter;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;         
        }
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
            currentHealth--;
            PlayerController.instance.anim.SetTrigger("Hurt");

            if(currentHealth <= 0)
            {
                currentHealth = 0;

                Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

                LevelManager.instance.RespawnPlayer();
            } 
            else
            {
                invincibleCounter = invincibleLength;

                PlayerController.instance.Knockback(); 
            }

            UIController.instance.UpdateHealthDisplay();
        }
       
    }

    public void HealPlayer()
    { 
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        } 
        
        UIController.instance.UpdateHealthDisplay();    
    }
}
