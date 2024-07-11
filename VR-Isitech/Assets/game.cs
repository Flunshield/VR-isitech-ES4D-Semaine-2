using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject sphere;
    public GameObject particule;
    private Vector3 initialPosition;

    void Start()
    {
        // Stocker la position initiale de la sphère
        initialPosition = sphere.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée");
        if (other.gameObject == sphere)
        {
            // Déplacer la sphère à son point de départ
            ResetSpherePosition();
            
            // Activer les particules
            particule.SetActive(true);

            // Désactiver les particules après un délai
            StartCoroutine(DeactivateAfterDelay(2.0f));
        }
    }

    void ResetSpherePosition()
    {
        sphere.transform.position = initialPosition;

        // Si la sphère a un Rigidbody, réinitialiser sa vitesse
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    System.Collections.IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        particule.SetActive(false);
    }
}
