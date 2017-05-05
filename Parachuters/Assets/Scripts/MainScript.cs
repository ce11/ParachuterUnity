using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {
    public int spawnTime = 1000;
    private int spawnCounter = 0;
    private GameObject plane;
    HeartsBehavior livesHandler;
    ScoreBehavior scoreHandler;

    void EndGame()
    {

    }

    public void AddScore()
    {
        scoreHandler.IncrementScore();
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
        GameObject.Find("parachutist").gameObject.GetComponent<ParachutistBehavior>().missedParachuter += RemoveLife;
        GameObject.Find("parachutist").gameObject.GetComponent<ParachutistBehavior>().caughtParachuter += AddScore;
        Debug.Log(livesHandler == null);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        spawnCounter++;
        if(spawnCounter == spawnTime)
        {
            spawnCounter = 0;
            System.Random r = new System.Random();
            spawnTime = r.Next(500, 1000);
            Debug.Log("new spawn "+spawnTime);
            SpawnParachuter();
        }
    }

    // Method to spawn parachuter at plane location
    void SpawnParachuter()
    {
        GameObject newParachuter = (GameObject)Instantiate(Resources.Load("ParachuterPrefab", typeof(GameObject)));
        newParachuter.transform.position = plane.transform.position;
        newParachuter.gameObject.GetComponent<ParachutistBehavior>().missedParachuter += RemoveLife;
        newParachuter.gameObject.GetComponent<ParachutistBehavior>().caughtParachuter += AddScore;

        Debug.Log(plane.transform.position.x);
    }
}
