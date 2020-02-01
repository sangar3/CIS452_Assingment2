using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour, PlayerDie
{
    public int health = 1;
    public AudioClip deathsfx;
    public float invulnPeriod = 0; // for player only 
    float invulnTimer = 0;
    int correctlayer;
    float invulnAnimTimer = 0;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctlayer = gameObject.layer;
        spriteRend = GetComponent<SpriteRenderer>();

        if(spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
            if(spriteRend == null)
            {
                Debug.LogError("Object" + gameObject.name + "has no spring renderer");    
            }
        }
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
            if(spriteRend != null)
            {
                spriteRend.enabled = true;
            }
            else
            {
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled; //invert state to toggle on/off
                }
            }
        }
        if (health <= 0)
        {
            Die();
            AudioManager.Instance.PlaySFX(deathsfx, 3.0f);
            Debug.Log("death");
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}

