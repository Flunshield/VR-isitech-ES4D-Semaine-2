using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirCanon1 : MonoBehaviour
{
    public Animator bouletAnimator;  // Référence à l'Animator
    public Animator boutonAnimator;  // Référence à l'Animator
    public string input;
    public GameObject correctObject;  // L'objet qui déclenchera l'animation
    public GameObject objectToDisplay;  // L'objet à afficher

    public string trigger;  // Nom du déclencheur

    // Start is called avant la première frame update
    void Start()
    {
        // Vérifie si l'Animator est déjà assigné, sinon essaie de le récupérer
        if (bouletAnimator == null)
        {
            bouletAnimator = gameObject.GetComponent<Animator>();
            if (bouletAnimator == null)
            {
                Debug.LogError("Animator not found on " + gameObject.name);
            }
        }

        if(boutonAnimator == null)
        {
            Debug.LogError("Bouton Animator is not assigned in the inspector.");
        }

        // Vérifie si les objets sont assignés
        if (correctObject == null)
        {
            Debug.LogError("Correct Object is not assigned in the inspector.");
        }

        if (objectToDisplay == null)
        {
            Debug.LogError("Object to Display is not assigned in the inspector.");
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
        // Vérifie si l'objet entrant est celui attendu
        if (other.gameObject == correctObject)
        {
            boutonAnimator.SetBool(input, true);  // Déclenche l'animation du bouton
            bouletAnimator.SetBool(trigger, true);  // Déclenche l'animation
            StartCoroutine(DisplayObjectAfterDelay(2.0f));  // Démarre la coroutine pour afficher l'objet après 2 secondes
        }
    }

    private IEnumerator DisplayObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Attend le délai spécifié
        objectToDisplay.SetActive(true);  // Affiche l'objet
        Debug.Log("Animation terminée et objet affiché.");
    }
}
