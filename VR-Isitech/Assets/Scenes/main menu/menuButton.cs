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
}