using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsBehavior : MonoBehaviour {
    public int lives = 3;
    private int lifeWidth = 30;
    private int lifeMargin = 10;
    private Texture2D heartTexture;
    // Use this for initialization
    void OnGUI() {
        GUITools.DrawRect(new Rect(0, 0, (lifeWidth+ lifeMargin) * lives + lifeMargin, lifeWidth), Color.white);
        var startX = 10;
        for(var i = 0; i < lives; i++)
        {
            GUITools.DrawImage(new Rect(startX, 0, lifeWidth, lifeWidth), heartTexture);
            startX += lifeMargin + lifeWidth;
        }
        
	}
	
	void Start () {
        heartTexture = (Texture2D)Resources.Load("heart");
    }
}
