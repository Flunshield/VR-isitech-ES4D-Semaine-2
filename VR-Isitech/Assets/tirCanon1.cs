using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirCanon1 : MonoBehaviour
{

    public Animator currentAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

private void tirCanon () {
    Debug.Log("is trigger");
    currentAnimator.SetTrigger("trigger");
}
}
