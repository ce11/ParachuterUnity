using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {
    public int difficultyIncreaseAfter = 1;
    private int difficultyIncreaseCounter = 0;
    public float difficultyIncreaseIncrement = 1.2f;
    public int minSpawnTime = 200;
    public int maxSpawnTime = 400;
    private int randomSpawnTime;
    private int spawnCounter = 0;
    private GameObject plane;
    HeartsBehavior livesHandler;
    ScoreBehavior scoreHandler;
    
    void EndGame()
    {

        // Show replay button
    }

    void OnGUI()
    {
        if(livesHandler.lives <= 0)
        {
            GUITools.DrawLargeText(new Rect(Screen.width /2 - 150, Screen.height /2 -150, 300, 300), "GAME OVER");
        }
    }

    void IncrementDifficulty()
    {
        minSpawnTime = (int)( minSpawnTime / difficultyIncreaseIncrement);
        maxSpawnTime = (int)( maxSpawnTime / difficultyIncreaseIncrement);
    }

    public void AddScore()
    {
        scoreHandler.IncrementScore();
        difficultyIncreaseCounter++;
        if(difficultyIncreaseCounter >= difficultyIncreaseAfter)
        {
            difficultyIncreaseCounter = 0;
            IncrementDifficulty();
        }
    }

    public void RemoveLife()
    {
        if(livesHandler.lives <= 0)
        {
            EndGame();
        }else
        {
            livesHandler.lives--;
        }
    }

	// Use this for initialization
	void Start () {
        plane = GameObject.Find("plane");
        livesHandler = GameObject.Find("heartContainer").gameObject.GetComponent<HeartsBehavior>();
        scoreHandler = GameObject.Find("scoreContainer").gameObject.GetComponent<ScoreBehavior>();
        GenerateSpawnTime();
    }

	void GenerateSpawnTime()
    {
        System.Random r = new System.Random();
        randomSpawnTime = r.Next(minSpawnTime, maxSpawnTime);
    }

    void FixedUpdate()
    {
        // Increment spawn counter if there are lives left
        if(livesHandler.lives > 0)
        {
            spawnCounter++;
        }
        if(spawnCounter >= randomSpawnTime)
        {
            spawnCounter = 0;
            GenerateSpawnTime();
            SpawnParachuter();
        }
    }

    // Method to spawn parachuter at plane location
    void SpawnParachuter()
    {
        // Create and position parachuter
        GameObject newParachuter = (GameObject)Instantiate(Resources.Load("ParachuterPrefab", typeof(GameObject)));
        newParachuter.transform.position = plane.transform.position;
        // Initialize event listeners
        newParachuter.gameObject.GetComponent<ParachutistBehavior>().missedParachuter += RemoveLife;
        newParachuter.gameObject.GetComponent<ParachutistBehavior>().caughtParachuter += AddScore;
    }
}
