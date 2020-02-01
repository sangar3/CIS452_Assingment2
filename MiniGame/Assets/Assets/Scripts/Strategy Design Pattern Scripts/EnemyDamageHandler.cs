/*
		 * (Santiago Garcia II)
		 * ( EnemyDamageHandler.cs)
		 * (Assignment2)
		 * (keeps track of when enemeies are destroyed by played and updates the score)
	*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour, EnemyDie
{
    public int health = 1;
    public int ScoreValue;
    public AudioClip deathsfx;
    public float invulnPeriod = 0; // for player only 
    float invulnTimer = 0;
    int correctlayer;
    float invulnAnimTimer = 0;

    private PlayerSpawner gameController; 

    private SpriteRenderer spriteRend;

    void Start()
    {
        // Using Strategy Pattern: to create a component that takes in the the stores the sprite render in the component only if its null
        correctlayer = gameObject.layer;
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
            if (spriteRend == null)
            {
                Debug.LogError("Object" + gameObject.name + "has no spring renderer");
            }
        }
        // Using Strategy Pattern: to create gameobject that takes in the gamecontroller everytime the mini game starts and storing it in a private variable instead(encaplustion)
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<PlayerSpawner>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot Find player spawner script");
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
        if (invulnTimer <= 0)
        {
            gameObject.layer = correctlayer;
            if (spriteRend != null)
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
            gameController.AddScore(ScoreValue); //Using Strategy Pattern:to call Gamecontroller to add to the score when an enemy is killed.
            EDead();
            
            AudioManager.Instance.PlaySFX(deathsfx, 3.0f);
            
            Debug.Log("Enemy dead add score");
        }
    }
    public void EDead()
    {
       
        Destroy(gameObject);
       


    }
}
