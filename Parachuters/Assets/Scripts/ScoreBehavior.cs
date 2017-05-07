using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehavior : MonoBehaviour {
    public int score = 0;
    public int scoreIncrementation = 10;

    void OnGUI()
    {
        GUITools.DrawRect(new Rect(0, 50, 130, 30), Color.white);
        GUITools.DrawRegularText(new Rect(10, 55, 130, 30), "Score: " + score);
    }

    public void IncrementScore()
    {
        score += scoreIncrementation;
    }
}
