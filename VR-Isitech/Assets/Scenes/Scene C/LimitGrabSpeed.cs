using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LimitGrabSpeed : MonoBehaviour
{
    public float maxSpeed = 2.0f; // Vitesse maximale linéaire
    public float maxAngularSpeed = 10.0f; // Vitesse maximale angulaire

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Limiter la vitesse linéaire
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Limiter la vitesse angulaire
        if (rb.angularVelocity.magnitude > maxAngularSpeed)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * maxAngularSpeed;
        }
    }
}
