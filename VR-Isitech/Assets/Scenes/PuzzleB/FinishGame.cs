using UnityEngine;

public class FinishGame : MonoBehaviour
{

    public GameObject Sphere;
    public GameObject Portail;
    void OnTriggerEnter(Collider other)
    {
       Debug.Log("there it is ");
        if (other.gameObject.CompareTag("Sphere"))
        {
            if (Portail != null)
            {
                Portail.SetActive(true);
                Debug.Log("Portal object activated.");
            }
        }
    }
}
