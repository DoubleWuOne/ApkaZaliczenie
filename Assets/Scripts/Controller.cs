﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{

    public float moveSpeed = 6;
    Rigidbody rigidbody;
    Camera cameraView;
    Vector3 velocity;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cameraView = Camera.main;
    }

    void Update()
    {
        
        Vector3 mousePos = cameraView.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,cameraView.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized*moveSpeed;
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
