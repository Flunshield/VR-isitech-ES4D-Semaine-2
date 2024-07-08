using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class recepatclea : MonoBehaviour
{
    public GameObject correctObject;
    public Material triggeredMaterial;
    public string animationTriggerName = "TriggerAnimation"; // Nom du paramètre de déclenchement dans l'Animator
    private Material originalMaterial;
    private bool objectPlaced = false;
    private Animator animator;

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
        animator = GetComponent<Animator>(); // Assurez-vous que l'Animator est sur le même GameObject que ce script
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!objectPlaced && other.gameObject == correctObject)
        {
            objectPlaced = true;
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Set isKinematic to true
            }

            other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            other.gameObject.transform.position = transform.position;
            other.gameObject.transform.rotation = transform.rotation;
            GetComponent<Renderer>().material = triggeredMaterial;

            if (animator != null)
            {
                animator.SetTrigger(animationTriggerName); // Déclencher l'animation
            }
        }
    }
}
