using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    Camera cameraToLookAt;
    void Start()
    {
        cameraToLookAt = Camera.main;
    }

    // Looks at player
    void Update()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);

    }
}
