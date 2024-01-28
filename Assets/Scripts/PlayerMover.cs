using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    public float speed;
    private Vector3 _moveDirection;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _moveDirection = Vector3.zero;
    }

    void Update()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.z = Input.GetAxis("Vertical");
        _moveDirection = _moveDirection.normalized; //Normalize the move direction to prevent faster diagonal movement.
        
        if(_moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_moveDirection);
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
        
        transform.position += speed * Time.deltaTime * _moveDirection;
    }
}
