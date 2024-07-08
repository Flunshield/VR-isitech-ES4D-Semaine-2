using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FreezeXAxisOnGrab : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        // Geler l'axe X
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        // Libérer l'axe X (ou ajuster selon les besoins)
        rb.constraints = RigidbodyConstraints.None;
    }
}
