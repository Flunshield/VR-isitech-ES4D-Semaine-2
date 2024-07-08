using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirCanon1 : MonoBehaviour
{
    public Animator currentAnimator;  // Référence à l'Animator
    public GameObject correctObject;  // L'objet qui déclenchera l'animation

    // Start is called before the first frame update
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
            Debug.Log("Correct object triggered animation");
            currentAnimator.SetBool("trigger", true);  // Déclenche l'animation
        }
    }
}
