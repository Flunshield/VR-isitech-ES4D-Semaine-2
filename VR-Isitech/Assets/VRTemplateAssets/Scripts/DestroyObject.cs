using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class DestroyOnContact : MonoBehaviour
{
    // Tag de l'arme (marteau) qui peut détruire cet objet
    public string weaponTag = "Weapon";
    public GameObject dropItem;

    // Méthode appelée lorsqu'un autre collider entre en contact avec celui de cet objet
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("an collison was make ");
        // Vérifie si l'objet en contact a le tag de l'arme
        if (collision.gameObject.CompareTag(weaponTag))
        {
            // Détruit cet objet
            Destroy(gameObject);
            dropItem.SetActive(true);
        }
    }
}
