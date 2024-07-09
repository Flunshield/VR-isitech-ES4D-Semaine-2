using UnityEngine;

public class FinishGame : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Collision with Finish detected!");
            GameObject respawnObject = GameObject.FindGameObjectWithTag("Respawn");
            if (respawnObject != null)
            {
                respawnObject.SetActive(true);
                Debug.Log("Portal object activated.");
            }
        }
    }
}
