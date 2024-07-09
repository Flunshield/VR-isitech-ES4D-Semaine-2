using UnityEngine;

public class FinishGame : MonoBehaviour
{

    public GameObject Sphere;
    public GameObject Portail;
    public GameObject particule;
    void OnTriggerEnter(Collider other)
    {
       Debug.Log("there it is ");
        if (other.gameObject.CompareTag("Sphere"))
        {
            if (Portail != null)
            {
                Portail.SetActive(true);
                Sphere.SetActive(false);
                Debug.Log("Portal object activated.");
                particule.SetActive(true);
                StartCoroutine(DeactivateAfterDelay(1f));
            }
        }
    }
    System.Collections.IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        particule.SetActive(false);
    }
}
