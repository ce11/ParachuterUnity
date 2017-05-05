using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GUITools
{

    private static readonly Texture2D backgroundTexture = Texture2D.whiteTexture;
    private static readonly GUIStyle textureStyle = new GUIStyle
    {
        normal = new GUIStyleState
        {
            background = backgroundTexture,
            textColor = Color.black
        }
    };

    public static void DrawText(Rect postion, string text)
    {
        GUI.Label(new Rect(0, 50, 130, 30), text, textureStyle);
    }

    public static void DrawRect(Rect position, Color color, GUIContent content = null)
    {
        var backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = color;
        GUI.Box(position, content ?? GUIContent.none, textureStyle);
        GUI.backgroundColor = backgroundColor;
    }

    public static void DrawImage(Rect position, Texture texture)
    {
        GUI.DrawTexture(position, texture, ScaleMode.ScaleToFit, true, 10.0F);
    }

    public static void LayoutBox(Color color, GUIContent content = null)
    {
        var backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = color;
        GUILayout.Box(content ?? GUIContent.none, textureStyle);
        GUI.backgroundColor = backgroundColor;
    }
}