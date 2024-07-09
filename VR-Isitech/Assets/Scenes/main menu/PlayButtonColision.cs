using UnityEngine;
using TMPro;

public class ActivateButtonOnCollision : MonoBehaviour
{
    public GameObject playButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            if (playButton != null)
            {
                playButton.SetActive(true);
            }
        }
    }
}
