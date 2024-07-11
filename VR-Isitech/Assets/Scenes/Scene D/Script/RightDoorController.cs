using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorController : MonoBehaviour
{
    public Transform rightDoorTransform;  // Référence à la transform de la porte droite
    public float openAngle = 90f;         // Angle d'ouverture de chaque porte
    public float openSpeed = 2f;          // Vitesse d'ouverture des portes
    public MeshCollider doorCollider;     // Référence au MeshCollider de la porte
    public MeshCollider doorFrames;
    private bool isOpen = false;          // État actuel des portes (ouvertes/fermées)
    private Quaternion rightClosedRotation;  // Rotation initiale de la porte droite
    private Quaternion rightOpenRotation;    // Rotation finale de la porte droite
 
    void Start()
    {
        rightClosedRotation = rightDoorTransform.rotation;
        rightOpenRotation = rightClosedRotation * Quaternion.Euler(0, openAngle, 0); // Ouvre à droite
    }

    void Update()
    {
        if (isOpen)
        {
            
            rightDoorTransform.rotation = Quaternion.Slerp(rightDoorTransform.rotation, rightOpenRotation, Time.deltaTime * openSpeed);
            doorCollider.enabled = false; // Désactiver le collider lorsque la porte est ouverte
            doorFrames.enabled = false;
        }
        else
        {
           
            rightDoorTransform.rotation = Quaternion.Slerp(rightDoorTransform.rotation, rightClosedRotation, Time.deltaTime * openSpeed);
            doorCollider.enabled = true; // Activer le collider lorsque la porte est fermée
            doorFrames.enabled = true;
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
