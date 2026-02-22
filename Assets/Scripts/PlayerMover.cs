using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    private const float GRAVITY = 9.81f;


    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private CharacterController _characterController;
    private Vector3 _velocity;
    private bool _isJumping = false;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _inputReader.Moved += Move;
        _inputReader.Jumped += Jump;
    }

    private void Update()
    {
        if (CheckGround() && !_isJumping && _velocity.y < 0)
        {
            _velocity.y = -1;
        }
        else
        {
            _velocity.y -= GRAVITY * Time.deltaTime;
        }

        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void OnDisable()
    {
        _inputReader.Moved -= Move;
        _inputReader.Jumped -= Jump;
    }

    private void Move(float h, float v)
    {
        Vector3 direction = transform.forward * v + transform.right * h;
        direction.Normalize();
        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    private bool CheckGround()
    {
        if (Physics.CheckSphere(transform.position, _characterController.radius, _groundLayer))
        {
            _isJumping = false;
            return true;
        }

        return false;
    }

    private void Jump()
    {
        _isJumping = true;
        _velocity.y = _jumpForce;
    }
}