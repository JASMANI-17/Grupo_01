using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGold, isHeal;

    private bool isCollected;

    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGold)
            {
                LevelManager.instance.goldCollected++;

                UIController.instance.UpdateGoldCount();

                Instantiate(pickupEffect, transform.position, transform.rotation);
                
                isCollected = true;
                Destroy(gameObject);   
            }

            if (isHeal)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();

                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
