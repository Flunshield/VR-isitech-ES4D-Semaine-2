using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method will be called when the Play button is pressed
    public void PlayGame()
    {
        // Assuming the next scene in the build index is the game scene
        //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //SceneManager.LoadScene(nextSceneIndex);
        Debug.Log("Play game...");
    }

    // This method will be called when the Quit button is pressed
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        // If running in the editor, stop playing the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running as a standalone build, quit the application
        Application.Quit();
#endif
    }
}