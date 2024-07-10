using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public List<addItem> slots;  // Liste des slots
    public LeftDoorController leftDoorController;  // Référence au contrôleur de la porte gauche
    public RightDoorController rightDoorController;  // Référence au contrôleur de la porte droite

    void Start()
    {
        // Initialiser les slots
        foreach (var slot in slots)
        {
            slot.SetInventory(this);
        }
    }

    void Update()
    {
        // Vérifier le nombre de slots remplis
        int filledSlots = GetFilledSlotsCount();

        // Ouvrir ou fermer les portes en fonction du nombre de slots remplis
        if (filledSlots >= 3)
        {
            Debug.Log("the door is Open");
            leftDoorController.OpenDoors();
            rightDoorController.OpenDoors();
        }
        else
        {
            Debug.Log("the door is Close");
            leftDoorController.CloseDoors();
            rightDoorController.CloseDoors();
        }
    }

    public int GetFilledSlotsCount()
    {
        int count = 0;
        foreach (var slot in slots)
        {
            if (slot.IsSlotFull())
            {
                count++;
            }
        }
        return count;
    }

    public int GetAvailableSlotsCount()
    {
        int count = 0;
        foreach (var slot in slots)
        {
            if (!slot.IsSlotFull())
            {
                count++;
            }
        }
        return count;
    }
}
