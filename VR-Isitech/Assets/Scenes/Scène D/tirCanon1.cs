using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirCanon1 : MonoBehaviour
{

    public Animator currentAnimator;
    public GameObject correctObject;
    // Start is called before the first frame update
    void Start()
    {
        currentAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("out of if but trigger");
        if (other.gameObject == correctObject)
        {
            Debug.Log("is trigger");
            currentAnimator.SetBool("trigger", true);
        }
    }
}
