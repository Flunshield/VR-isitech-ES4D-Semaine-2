using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class menuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text  textComponent;
    public Image imageComponent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        textComponent.color = Color.black;
        imageComponent.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textComponent.color = Color.white;
        imageComponent.enabled = false;
    }

    public void PlayGame()
    {
        // Assuming the next scene in the build index is the game scene
        //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //SceneManager.LoadScene(nextSceneIndex);
        Debug.Log("Play Game");
    }

    // This method will be called when the Quit button is pressed
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}