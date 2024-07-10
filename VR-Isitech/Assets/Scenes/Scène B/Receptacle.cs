using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Receptacle : MonoBehaviour
{
    public GameObject correctObject;
    public GameObject displayObject;
    public Material triggeredMaterial;
    private Material originalMaterial;
    private bool objectPlaced = false;

    private GlobalReceptacle globalReceptacle; // Référence au script GlobalReceptacle

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void SetGlobalReceptacle(GlobalReceptacle receptacle)
    {
        globalReceptacle = receptacle;
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
                displayObject.SetActive(true);
            }

            other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            other.gameObject.transform.position = transform.position;
            other.gameObject.transform.rotation = transform.rotation;
            GetComponent<Renderer>().material = triggeredMaterial;

            if (globalReceptacle != null)
            {
                globalReceptacle.CheckReceptacles();
            }
        }
    }

    public bool IsObjectPlaced()
    {
        return objectPlaced;
    }
}
