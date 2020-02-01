using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public AudioClip enemyshootingsfx;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    private float cooldownTimer = 0;
    int bulletlayer;
    public float fireDelay = 0.50f;
    
    Transform player;
    void Start()
    {
        bulletlayer = gameObject.layer;
    }

    void Update()
    {
        if (player == null)
        {
            //Find Player Ship
            GameObject go = GameObject.FindWithTag("Player");
            if (go != null)
            {
                player = go.transform;
            }
        }


        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4) 
        {
            Debug.Log("pew ");
            AudioManager.Instance.PlaySFX(enemyshootingsfx, 3.0f);
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            GameObject bulletGo= (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation); // so the gameobject cant shoot ifself
            bulletGo.layer = bulletlayer;
        }
    }
}
