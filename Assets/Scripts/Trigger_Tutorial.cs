using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger_Tutorial : MonoBehaviour
{
    public GameObject pie;
    Tutorial tutorialScript;

    // Update is called once per frame
    void Update()
    {
        tutorialScript = pie.GetComponent<Tutorial>();
    }

    void OnTriggerEnter(Collider Contact) 
    {
        if (Contact.tag == gameObject.tag) 
        {
            print("Dom krockade!!!!");
            tutorialScript.Colliding();
        }
    }
}
