using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetStars : MonoBehaviour
{
    public Animator currentAnimator;  // Référence à l'Animator
    public GameObject correctObject;  // L'objet qui déclenchera l'animation
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;

    public string trigger;  // Nom du déclencheur

    // Start is called avant la première frame update
    void Start()
    {
        // Vérifie si l'Animator est déjà assigné, sinon essaie de le récupérer
        if (currentAnimator == null)
        {
            currentAnimator = gameObject.GetComponent<Animator>();
            if (currentAnimator == null)
            {
                Debug.LogError("Animator not found on " + gameObject.name);
            }
        }

        // Vérifie si les objets sont assignés
        if (correctObject == null)
        {
            Debug.LogError("Correct Object is not assigned in the inspector.");
        }

        if (star1 == null)
        {
            Debug.LogError("Star1 is not assigned in the inspector.");
        }

        if (star2 == null)
        {
            Debug.LogError("Star2 is not assigned in the inspector.");
        }

        if (star3 == null)
        {
            Debug.LogError("Star3 is not assigned in the inspector.");
        }

        // Vérifie si les animators sont assignés
        if (animator1 == null)
        {
            Debug.LogError("Animator1 is not assigned in the inspector.");
        }

        if (animator2 == null)
        {
            Debug.LogError("Animator2 is not assigned in the inspector.");
        }

        if (animator3 == null)
        {
            Debug.LogError("Animator3 is not assigned in the inspector.");
        }

        if (animator4 == null)
        {
            Debug.LogError("Animator4 is not assigned in the inspector.");
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
            currentAnimator.SetBool(trigger, true);  // Déclenche l'animation
            StartCoroutine(DisplayObjectAfterDelay(2.0f));  // Démarre la coroutine pour afficher l'objet après 2 secondes
        }
    }

    private IEnumerator DisplayObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Attend le délai spécifié
        star1.SetActive(false);  // Désactive l'objet
        star2.SetActive(false);  // Désactive l'objet
        star3.SetActive(false);  // Désactive l'objet
        animator1.SetBool(trigger, false);
        animator2.SetBool(trigger, false);
        animator3.SetBool(trigger, false);
        animator4.SetBool(trigger, false);
        animator1.Rebind();
        animator1.Update(0f);
        animator2.Rebind();
        animator2.Update(0f);
        animator3.Rebind();
        animator3.Update(0f);
        animator4.Rebind();
        animator4.Update(0f);
        Debug.Log("Animation terminée et objets désactivés.");
    }
}
