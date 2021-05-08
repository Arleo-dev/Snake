using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private Vector2 _menuSize = new Vector2(500, 300);
    private float buttonMinHeight = 60f;
    private Font _captionFont;
    private Font _buttonFont;
    private const string MainMenuText = "Main menu";
    private const string StartButtonText = "Start game";
    private const string ExitButtonText = "Exit";
    private const string LevelName = "Level";


    private void OnGUI()
    {
        Rect _rect = new Rect(
            Screen.width / 2f - _menuSize.x / 2, 
            Screen.height / 2f - _menuSize.y / 2, 
            _menuSize.x, _menuSize.y);
        GUILayout.BeginArea(_rect, GUI.skin.textArea);
        {
            GUIStyle captionStyle = new GUIStyle(GUI.skin.label);
            captionStyle.font = _captionFont;
            captionStyle.alignment = TextAnchor.MiddleCenter;
            captionStyle.fontSize = 70;
            GUILayout.Label(MainMenuText, captionStyle);
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.font = _buttonFont;
            buttonStyle.margin = new RectOffset(20, 20, 3, 3);
            buttonStyle.fontSize = 40;
            GUILayout.FlexibleSpace();
            if(GUILayout.Button(StartButtonText, buttonStyle, GUILayout.MinHeight(buttonMinHeight)))
            {
                Application.LoadLevel(LevelName);

            }
            if (GUILayout.Button(ExitButtonText, buttonStyle, GUILayout.MinHeight(buttonMinHeight)))
            {
                Application.Quit();

            }
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndArea();
    }
}
