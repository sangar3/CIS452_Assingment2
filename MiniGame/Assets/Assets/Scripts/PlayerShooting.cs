using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public AudioClip playershootingsfx;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    int bulletlayer;
    private float cooldownTimer = 0;
    public float fireDelay = 0.25f;
   
    void Start()
    {
        bulletlayer = gameObject.layer;
    }


    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("pew ");
            AudioManager.Instance.PlaySFX(playershootingsfx, 3.0f);
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation); // so the gameobject cant shoot ifself
            bulletGo.layer = bulletlayer;
        }
    }
}
