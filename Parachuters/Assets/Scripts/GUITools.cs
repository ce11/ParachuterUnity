using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GUITools
{

    private static readonly Texture2D backgroundTexture = Texture2D.whiteTexture;
    private static readonly GUIStyle backgroundTextureStyle = new GUIStyle
    {
        normal = new GUIStyleState
        {
            background = backgroundTexture,
        }
    };
    private static readonly GUIStyle textTextureStyle = new GUIStyle
    {
        normal = new GUIStyleState
        {
            textColor = Color.black
        },
        fontSize = 20
    };
    private static readonly GUIStyle largeTextTextureStyle = new GUIStyle
    {
        normal = new GUIStyleState
        {
            textColor = Color.red
        },
        fontSize = 40
    };

    public static void CreateButton(Rect position, string title, System.Action pressedEvent)
    {

    }

    public static void DrawRegularText(Rect position, string text)
    {
        GUI.Label(position, text, textTextureStyle);
    }

    public static void DrawLargeText(Rect position, string text)
    {
        GUI.Label(position, text, largeTextTextureStyle);
    }

    public static void DrawRect(Rect position, Color color, GUIContent content = null)
    {
        var backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = color;
        GUI.Box(position, content ?? GUIContent.none, backgroundTextureStyle);
        GUI.backgroundColor = backgroundColor;
    }

    public static void DrawImage(Rect position, Texture texture)
    {
        GUI.DrawTexture(position, texture, ScaleMode.StretchToFill, true, 10.0F);
    }

    public static void LayoutBox(Color color, GUIContent content = null)
    {
        var backgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = color;
        GUILayout.Box(content ?? GUIContent.none, textTextureStyle);
        GUI.backgroundColor = backgroundColor;
    }
}