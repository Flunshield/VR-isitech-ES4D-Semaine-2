using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorController : MonoBehaviour
{
    public Transform leftDoorTransform;   // Référence à la transform de la porte gauche
    public float openAngle = 90f;         // Angle d'ouverture de chaque porte
    public float openSpeed = 2f;          // Vitesse d'ouverture des portes
    public MeshCollider doorCollider; 

    public MeshCollider doorFrames;

    private bool isOpen = false;          // État actuel des portes (ouvertes/fermées)
    private Quaternion leftClosedRotation;  // Rotation initiale de la porte gauche
    private Quaternion leftOpenRotation;    // Rotation finale de la porte gauche

    void Start()
    {
        leftClosedRotation = leftDoorTransform.rotation;
        leftOpenRotation = leftClosedRotation * Quaternion.Euler(0, -openAngle, 0);  // Ouvre à gauche
    }

    void Update()
    {
        if (isOpen)
        {
            leftDoorTransform.rotation = Quaternion.Slerp(leftDoorTransform.rotation, leftOpenRotation, Time.deltaTime * openSpeed);
            doorCollider.enabled = false; // Désactiver le collider lorsque la porte est ouverte
            doorFrames.enabled = false;
        }
        else
        {
            leftDoorTransform.rotation = Quaternion.Slerp(leftDoorTransform.rotation, leftClosedRotation, Time.deltaTime * openSpeed);
            doorCollider.enabled = true;
            doorFrames.enabled = false; // Activer le collider lorsque la porte est fermée
        }
    }

    // Méthode pour ouvrir les portes
    public void OpenDoors()
    {
        isOpen = true;
    }

    // Méthode pour fermer les portes
    public void CloseDoors()
    {
        isOpen = false;
    }
}
