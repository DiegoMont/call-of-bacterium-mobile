using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCrosshair : MonoBehaviour
{
    public const float maxDistance = 10;
    private GameObject gazedAtObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // GameObject detected in front of the camera.
            if (gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                
            }
        }
    }
}
