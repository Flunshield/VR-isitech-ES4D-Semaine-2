using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Tag de l'arme (marteau) qui peut détruire cet objet
    public string weaponTag = "Weapon";
    public GameObject displayItem;

    // Méthode appelée lorsqu'un autre collider entre en contact avec celui de cet objet
    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en contact a le tag de l'arme
        if (collision.gameObject.CompareTag(weaponTag))
        {
            // Détruit cet objet
            Destroy(gameObject);
            displayItem.SetActive(true);
        }
    }
}