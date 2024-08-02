using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Button : MonoBehaviour
{
    public void OnQuitButtonClick()
    {
        Application.Quit(); //Close the app. This is to be used for when you build a Unity project.
    }
}

//UnityEditor.EditorApplication.isPlaying = false; //Exit out the player editor in Unity
//Application.Quit(); //Close the app. This is to be used for when you build a Unity project.