using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNextStep : MonoBehaviour
{
    public GameObject star1;  // L'objet qui déclenchera l'animation
    public GameObject star2;  // L'objet qui déclenchera l'animation
    public GameObject star3;  // L'objet qui déclenchera l'animation

    public GameObject nextStep;  // L'objet à afficher
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(star1.activeSelf);
        if(star1.activeSelf && star2.activeSelf && star3.activeSelf)
        {
            nextStep.SetActive(true);
        } else {
            nextStep.SetActive(false);
        }
    }
}
