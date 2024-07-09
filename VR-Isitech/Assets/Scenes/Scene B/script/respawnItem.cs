using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnItem : MonoBehaviour
{
    public Vector3 mapBoundsMin;
    public Vector3 mapBoundsMax;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.x < mapBoundsMin.x || transform.position.x > mapBoundsMax.x ||
            transform.position.y < mapBoundsMin.y || transform.position.y > mapBoundsMax.y ||
            transform.position.z < mapBoundsMin.z || transform.position.z > mapBoundsMax.z)
        {
            transform.position = originalPosition;
        }
    }
}
