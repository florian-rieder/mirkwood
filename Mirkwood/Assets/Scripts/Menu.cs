using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    void Start(){
        // Make sure the cursor is visible and unlocked so that the player
        // can interact with the menu UI
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnStartButtonPressed()
    {
        // Load the first game scene
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }
}