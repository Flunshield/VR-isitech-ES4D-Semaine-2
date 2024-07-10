using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class helpButton : MonoBehaviour
{

    public GameObject displayCanvasHelp;
    public GameObject displayCanvasExplanation;
    public void getHelp() {
        displayCanvasHelp.SetActive(true);
        Debug.Log("the canvas help is display");
    }
    public void disableHelp(){
        displayCanvasHelp.SetActive(false);
        Debug.Log("the canvas help is no longer available");
    }

    public void disableAll(){
        displayCanvasExplanation.SetActive(false);
        displayCanvasHelp.SetActive(false);
    }

}
