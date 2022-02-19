using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;
    
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }       

        if(popUpIndex == 0)
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                popUpIndex++;
            }


        }
        else if(popUpIndex == 1)
        {

        }

        
    }
}
