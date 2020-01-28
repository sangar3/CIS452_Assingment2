using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour, PlayerDie
{
    public int health = 1;
    public float invulnPeriod = 0; // for player only 
    float invulnTimer = 0;
    int correctlayer;
    void Start()
    {
        correctlayer = gameObject.layer;
    }
    void OnTriggerEnter2D()
    {
        Debug.Log("trigger");
       
        health--;

        invulnTimer = invulnPeriod;

        gameObject.layer = 10;
        
        
    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if(invulnTimer <= 0)
        {
            gameObject.layer = correctlayer;
        }
        if (health <= 0)
        {
            Die();
            Debug.Log("death");
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}

