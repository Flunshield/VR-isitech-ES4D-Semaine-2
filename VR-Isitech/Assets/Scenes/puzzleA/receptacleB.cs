using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReceptacleB : MonoBehaviour
{
    public GameObject correctObject;
    public Material triggeredMaterial;
    public GameObject portal;
    private Material originalMaterial;
    private bool objectPlaced = false;
    public GameObject particule;

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
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
        }
        correctObject.SetActive(false);
        particule.SetActive(true);
        StartCoroutine(DeactivateAfterDelay(5f));
    }

    System.Collections.IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        particule.SetActive(false);
        if (portal != null)
        {
            portal.SetActive(true);
        }
    }
}
