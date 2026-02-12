using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;
    
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _inputReader.Moved += Move;
    }

    private void OnDisable()
    {
        _inputReader.Moved -= Move;
    }

    private void Move(float h, float v)
    {
        Vector3 direction = transform.forward * v + transform.right * h;
        direction.Normalize();
        _characterController.Move(direction * _speed * Time.deltaTime);
    }
}
