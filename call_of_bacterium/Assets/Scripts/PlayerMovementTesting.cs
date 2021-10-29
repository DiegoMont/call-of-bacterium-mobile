using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovementTesting : MonoBehaviour
{
    public CharacterController controller;
    public Camera cam;

    public float speed = 12f;
    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            cam.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }
    }
}
