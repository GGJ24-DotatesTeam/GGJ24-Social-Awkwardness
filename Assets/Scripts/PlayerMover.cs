using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    public float speed;
    private Vector3 _moveDirection;

    private void Start()
    {
        _moveDirection = Vector3.zero;
    }

    void Update()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.z = Input.GetAxis("Vertical");
        _moveDirection = _moveDirection.normalized; //Normalize the move direction to prevent faster diagonal movement.
        
        transform.position += speed * Time.deltaTime * _moveDirection;
    }
}
