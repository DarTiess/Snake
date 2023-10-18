using System;
using Infrastructure.Input;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement: MonoBehaviour
{
    private IInputService _inputService;
    private Rigidbody _rigidbody;
    private Vector3 _temp;
    private float _moveSpeed;
    private float _rotationSpeed;
    private bool _canMove;

    public void Initialize(IInputService inputService, float moveSpeed, float rotateSpeed)
    {
        _inputService = inputService;
        _rigidbody = GetComponent<Rigidbody>();
        _moveSpeed = moveSpeed;
        _rotationSpeed = rotateSpeed;
        
    }

    private void Update()
    {
        if(!_canMove)
            return;
        Move();
    }

    public void StartMove()
    {
        _canMove = true;
    }

    private void Move()
    {
        float inputHorizontal = _inputService.GetHorizontal;
        float inputVertical = _inputService.GetVertical;
       
        _temp.x = inputHorizontal;
        _temp.z = inputVertical;
        //_nav.Move(_temp * _playerSpeed * Time.deltaTime);
              
       _rigidbody.transform.Translate(transform.forward * Time.deltaTime * _moveSpeed, Space.World);

        Rotation();
    }

    private void Rotation()
    {
        Vector3 tempDirect = transform.position + Vector3.Normalize(_temp);
        Vector3 lookDirection = tempDirect - transform.position;
        if (lookDirection != Vector3.zero)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation,
                                                       Quaternion.LookRotation(lookDirection), _rotationSpeed * Time.deltaTime);
        }
    }
}