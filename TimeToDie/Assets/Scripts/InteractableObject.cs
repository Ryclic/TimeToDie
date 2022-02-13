using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public InteractableObject me;
    public Camera fpsCam;
    float range = 100f; // Determines how accurate player has to be to show text (higher = more accurate)
    GameObject myText;

    void Start()
    {
        // Set correct variables for text
        myText = me.transform.GetChild(0).gameObject;
        myText.SetActive(false);
    }
    void Update()
    {
        // Casts raycast from player, if it hits this object, then show text otherwise hide text
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform == me.transform && hit.distance <= 10f)
            {
                showText();
            } 
            else
            {
                hideText();
            }
        }
    }

    void showText()
    {
        myText.SetActive(true);
    }

    void hideText(){
        myText.SetActive(false);
    }
}
