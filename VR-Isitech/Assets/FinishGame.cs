using UnityEngine;

public class FinishGame : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Vérifiez si l'objet avec lequel nous sommes entrés en collision a le tag "Collectible"
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Collision with Finish detected!");
            // Ajoutez votre logique ici, par exemple détruire l'objet collecté
            Destroy(collision.gameObject);
        }
    }
}
