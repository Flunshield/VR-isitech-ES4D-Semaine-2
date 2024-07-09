using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetHammer : MonoBehaviour
{
    public GameObject hammer;  // Le marteau à réinitialiser
    public GameObject correctObject;  // L'objet qui déclenchera la réinitialisation
    private Vector3 initialPosition;  // Position initiale du marteau

    // Start is called avant la première frame update
    void Start()
    {
        // Vérifie si le marteau est assigné, sinon affiche une erreur
        if (hammer == null)
        {
            Debug.LogError("Hammer is not assigned in the inspector.");
        }
        else
        {
            // Stocke la position initiale du marteau
            initialPosition = hammer.transform.position;
        }

        // Vérifie si l'objet déclencheur est assigné, sinon affiche une erreur
        if (correctObject == null)
        {
            Debug.LogError("Correct Object is not assigned in the inspector.");
        }
    }

    // Méthode appelée lorsque le collider entre en collision avec un autre collider
    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet entrant est celui attendu
        if (collision.gameObject.CompareTag("Hammer"))
        {
            // Réinitialise la position du marteau à sa position initiale
            hammer.transform.position = initialPosition;
        }
    }
}
