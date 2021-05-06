using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private Vector2 _menuSize = new Vector2(500, 300);
    private float buttonMinHeight = 60f;
    private Font captionFont;
    private Font buttonFont;
    private string mainMenuText = "Main menu";
    private string startButtonText = "Start game";
    private string exitButtonText = "Exit";

    private void OnGUI()
    {
        Rect _rect = new Rect(
            Screen.width / 2f - _menuSize.x / 2, 
            Screen.height / 2f - _menuSize.y / 2, 
            _menuSize.x, _menuSize.y);
        GUILayout.BeginArea(_rect, GUI.skin.textArea);
        {
            GUIStyle captionStyle = new GUIStyle(GUI.skin.label);
            captionStyle.font = captionFont;
            captionStyle.alignment = TextAnchor.MiddleCenter;
            captionStyle.fontSize = 70;
            GUILayout.Label(mainMenuText, captionStyle);
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.font = buttonFont;
            buttonStyle.margin = new RectOffset(20, 20, 3, 3);
            buttonStyle.fontSize = 40;
            GUILayout.FlexibleSpace();
            if(GUILayout.Button(startButtonText, buttonStyle, GUILayout.MinHeight(buttonMinHeight)))
            {
                Application.LoadLevel("Level");

            }
            if (GUILayout.Button(exitButtonText, buttonStyle, GUILayout.MinHeight(buttonMinHeight)))
            {
                Application.Quit();

            }
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndArea();
    }
}
