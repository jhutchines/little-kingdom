﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Player_Movement : MonoBehaviour
{
    public float fl_movementSpeed;
    private GameObject go_camera;
    private Vector3 v3_cameraLock;
    private float fl_changeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        go_camera = Camera.main.gameObject;
        v3_cameraLock = go_camera.transform.position;
        v3_cameraLock -= new Vector3(transform.position.x, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        MovePlayer();
        LockCamera();
    }

    void RotatePlayer()
    {
        // Rotates the player character to face the mouse position
        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
        {
            Vector3 v3_lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(v3_lookAt);

            // Sends the command to attack/ gather
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<JH_Player_Attack>().StartAttack();
            }

            // Sends the command to interact
            if (Input.GetMouseButtonDown(1))
            {

            }
        }

    }

    void MovePlayer()
    {
        // Toggles between walking and running
        if (Input.GetKey(KeyCode.LeftShift) && GetComponent<JH_Player_Attack>().bl_canAttack) fl_changeSpeed = fl_movementSpeed * 2;
        else fl_changeSpeed = fl_movementSpeed;

        // Moves the player character in the direction of the key pressed
        Vector3 v3_movement = new Vector3(Input.GetAxis("Horizontal") * fl_changeSpeed * Time.deltaTime, 
                                          0, 
                                          Input.GetAxis("Vertical") * fl_changeSpeed * Time.deltaTime);

        transform.Translate(v3_movement);
    }

    void LockCamera()
    {
        // Keeps camera locked on the player character
        go_camera.transform.position = new Vector3(transform.position.x, 0, transform.position.z) + v3_cameraLock;
    }
}
