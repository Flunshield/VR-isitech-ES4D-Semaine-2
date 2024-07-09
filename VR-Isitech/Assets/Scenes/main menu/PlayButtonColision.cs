using UnityEngine;
using TMPro;

public class ActivateButtonOnCollision : MonoBehaviour
{
    public GameObject playButton;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
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
