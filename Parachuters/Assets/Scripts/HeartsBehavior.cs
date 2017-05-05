using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsBehavior : MonoBehaviour {
    public int lives = 3;
    private int lifeWidth = 30;
    private int lifeMargin = 10;
    private Texture2D myGUITexture;
    // Use this for initialization
    void OnGUI() {
        GUITools.DrawRect(new Rect(0, 0, 130, 30), Color.white);
        var startX = 10;
        for(var i = 0; i < lives; i++)
        {
            GUITools.DrawRect(new Rect(startX, 0, 30, 30), Color.red);
            startX += lifeMargin + lifeWidth;
        }
        
	}
	
	void Start () {
        myGUITexture = (Texture2D)Resources.Load("Assets/Resources/heart");
    }
}
