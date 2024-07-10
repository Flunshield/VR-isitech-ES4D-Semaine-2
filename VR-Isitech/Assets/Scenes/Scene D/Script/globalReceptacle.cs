using System.Collections.Generic;
using UnityEngine;

public class GlobalReceptacle : MonoBehaviour
{
    public List<SlotReceptacle> receptacles;
    public LeftDoorController leftFirstDoorController;  
    public RightDoorController rightFirstDoorController;  
    public LeftDoorController leftSecondDoorController;  
    public RightDoorController rightSecondDoorController;

    public GameObject Portail;

    void Start()
    {
        foreach (var receptacle in receptacles)
        {
            receptacle.SetGlobalReceptacle(this);
        }
    }

    // Méthode pour vérifier l'état des réceptacles
    public void CheckReceptacles()
    {
        int placedCount = 0;
        foreach (var receptacle in receptacles)
        {
            if (receptacle.IsObjectPlaced())
            {
                placedCount++;
            }
        }

        if (placedCount >= 3)
        {
            leftFirstDoorController.OpenDoors();
            rightFirstDoorController.OpenDoors();
            leftSecondDoorController.OpenDoors();
            rightSecondDoorController.OpenDoors();
            Portail.SetActive(true);
        }
        else
        {
            Portail.SetActive(false);
        }
    }
}
