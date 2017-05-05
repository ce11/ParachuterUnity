using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehavior : MonoBehaviour {
    public int score = 0;
    public int scoreIncrementation = 10;
	// Use this for initialization
	void Start () {
		
	}

    void OnGUI()
    {
        GUITools.DrawRect(new Rect(0, 50, 130, 30), Color.white);
        GUITools.DrawText(new Rect(0, 50, 130, 30), "Score: " + score);
    }

    void Update () {
		
	}

    public void IncrementScore()
    {
        score += scoreIncrementation;
    }
}
