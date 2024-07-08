using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public GameObject correctObject;  // L'objet qui déclenchera l'animation
    public GameObject objectDisplay;  // L'objet à activer

    // Start is called before the first frame update
    void Start()
    {
        // Vérifie si les objets sont assignés
        if (correctObject == null)
        {
            Debug.LogError("Correct Object is not assigned in the inspector.");
        }

        if (objectDisplay == null)
        {
            Debug.LogError("Object Display is not assigned in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Pas de code nécessaire ici pour le moment
    }

    // Méthode appelée lorsque le collider entre en collision avec un autre collider
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider entered trigger");

        // Vérifie si l'objet entrant est celui attendu
        if (other.gameObject == correctObject)
        {
            Debug.Log("Correct object entered trigger");

            // Active l'objet display
            if (objectDisplay != null)
            {
                objectDisplay.SetActive(true);
                Debug.Log("Object display set to active.");
            }
            else
            {
                Debug.LogError("Object Display is not assigned.");
            }
        }
        else
        {
            Debug.Log("Entered object is not the correct object.");
        }
    }
}
