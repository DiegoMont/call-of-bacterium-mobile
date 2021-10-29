using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCrosshair : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private float maxDistance = 10;

    [Header("Crosshair")]
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Sprite crosshair1Sprite;
    [SerializeField] private Sprite crosshair2Sprite;
    
    [Header("Shoot options")]
    [SerializeField] private Transform pillSpawn;
    [SerializeField] private Transform pill;
    [SerializeField] private float shootRate = 2f;
    private float nextShootTime = 0f;

    private GameObject gazedAtObject = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Image crosshairImg = crosshair.GetComponent<Image>();

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // Enemy detected in front of the camera
            if (gazedAtObject != hit.transform.gameObject && hit.transform.tag == "Enemy")
            {
                
                // Change crosshair color and sprite
                crosshairImg.sprite = crosshair2Sprite;
                crosshairImg.color = Color.red;
                
                // Shoot
                if (Time.time >= nextShootTime)
                {   
                    ShootPill(pillSpawn.position, hit.point);
                    nextShootTime = Time.time + 1f / shootRate;
                }
            }
        }
        else
        {
            // No enemy detected in front of the camera
            crosshairImg.sprite = crosshair1Sprite;
            crosshairImg.color = Color.black;
            gazedAtObject = null;
        }
    }

    private void ShootPill(Vector3 spawnPos, Vector3 endPos)
    {
        Transform pillTransform = Instantiate(pill, spawnPos, Quaternion.identity);
        Vector3 shootDir = (endPos - spawnPos);
        pillTransform.GetComponent<Pill>().Setup(shootDir);
    }
}
