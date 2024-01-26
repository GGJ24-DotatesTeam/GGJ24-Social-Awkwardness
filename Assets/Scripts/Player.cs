using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    void Update() {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = moveDirection.normalized; //Normalize the move direction to prevent faster diagonal movement.
        
        transform.position += speed * Time.deltaTime * moveDirection;
    }
}
