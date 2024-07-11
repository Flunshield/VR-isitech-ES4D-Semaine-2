using UnityEngine;

public class respawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;  // Le point de spawn où le joueur sera téléporté

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet en collision a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // Téléporte le joueur au point de spawn
            TeleportToSpawn(other.gameObject);
        }
    }

    void TeleportToSpawn(GameObject player)
    {
        // Téléporte le joueur à la position du point de spawn
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;

        // Si le joueur a un Rigidbody, réinitialise sa vitesse
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
