using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class addItem : MonoBehaviour
{
    public Color canAddColor = Color.green;
    public Color originalColor = new Color(1, 1, 1, 0);
    private Renderer slotRenderer;

    public GameObject[] slots;  // Liste de slots
    private Dictionary<GameObject, bool> slotStatus = new Dictionary<GameObject, bool>();  // Dictionnaire pour suivre l'état des slots

    public LeftDoorController leftDoorController;
    public RightDoorController rightDoorController;

    private void Start()
    {
        slotRenderer = GetComponent<Renderer>();
        slotRenderer.material.color = originalColor;

        // Initialiser l'état des slots
        foreach (var slot in slots)
        {
            slotStatus[slot] = false;
        }
    }

    private void Update()
    {
        int filledSlots = 0;
        foreach (var slot in slotStatus.Values)
        {
            if (slot)
            {
                filledSlots++;
            }
        }

        // Vérifiez si trois slots ou plus sont remplis
        if (filledSlots >= 3)
        {
            leftDoorController.OpenDoors();
            rightDoorController.OpenDoors();
        }
        else
        {
            leftDoorController.CloseDoors();
            rightDoorController.CloseDoors();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter()");

        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("collectible") && gameObject.GetComponent<XRGrabInteractable>())
        {
            foreach (var slot in slots)
            {
                if (!slotStatus[slot])
                {
                    AttachToSlot(gameObject, slot);
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("collectible") && gameObject.GetComponent<XRGrabInteractable>())
        {
            slotRenderer.material.color = originalColor;
        }
    }

    void AttachToSlot(GameObject item, GameObject slot)
    {
        // Définir le slot comme parent de l'item
        item.transform.SetParent(slot.transform);

        // Réinitialiser la position locale de l'item pour qu'il soit positionné correctement dans le slot
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        var rigidbody = item.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }

        // Remet le grab
        var grabInteractable = item.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(OnItemGrabbed);
        }

        // Marquer le slot comme rempli
        slotStatus[slot] = true;
        slotRenderer.material.color = originalColor;
    }

    void OnItemGrabbed(SelectExitEventArgs args)
    {
        GameObject item = args.interactableObject.transform.gameObject;
        GameObject slot = item.transform.parent.gameObject;

        // Rendre le rigidbody non-cinématique pour permettre les interactions physiques
        var rigidbody = item.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = false;
        }

        // Détacher l'objet du parent (slot) et l'attacher à la scène principale
        item.transform.SetParent(null);
        SceneManager.MoveGameObjectToScene(item, SceneManager.GetActiveScene());

        // Permettre à l'item d'être repris
        var grabInteractable = item.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(OnItemGrabbed); // Nettoyer l'événement pour éviter les appels multiples
        }

        // Réinitialiser l'échelle de l'item pour sa taille originale
        item.transform.localScale = Vector3.one;

        // Marquer le slot comme vide
        slotStatus[slot] = false;
        slotRenderer.material.color = originalColor;
    }
}
