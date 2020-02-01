/*
		 * (Santiago Garcia II)
		 * (  PlayerSpawner.cs)
		 * (Assignment2)
		 * (Spawns the player, updates the lives/score )
	*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public AudioClip gameoversfx;
    GameObject playerInstance;
    public Text Scoretext;
    private int score=0;
    public int numLives = 4; // always 1 higher than it is


    float respawnTimer;

    void Start()
    {
        SpawnPlayer();
        
        UpdateScore();
    }
    void SpawnPlayer()
    {
       
        --numLives;
        float respawnTimer = 3f;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
       
    }
    void Update()
    {
        if(playerInstance == null && numLives >0)
        {
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }   

    void OnGUI()
    {
        if (numLives > 0 || playerInstance != null)
        {
            
            GUI.Label(new Rect(0, 0, 100, 50), " Lives Left" + ":" + numLives);
           
        }
        if(numLives ==0)
        {
            Debug.Log("GAMEOVER ");
            AudioManager.Instance.PlaySFX(gameoversfx, 3.0f);
            SceneManager.LoadScene("Gameover");
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
       
        Scoretext.text ="Score: "+ score.ToString();
    }
}
