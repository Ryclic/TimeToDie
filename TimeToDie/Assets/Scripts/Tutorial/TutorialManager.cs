using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;
    public GameObject player;

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
            // Walk to the yellow area
            if(player.transform.position.z >= 16)
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 1)
        {
            // Jump over box
            if(player.transform.position.z >= 28)
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2)
        {
            // Check if player in sprint
            if(player.GetComponent<PlayerMovement>().speed >= 15){
                popUpIndex++;
            }
        }
        else if(popUpIndex == 3)
        {

        }

        
    }
    
}
