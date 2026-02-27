using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int X = Animator.StringToHash(nameof(X));
    private readonly int Y = Animator.StringToHash(nameof(Y));
    private readonly int Fire = Animator.StringToHash(nameof(Fire));
    private readonly int Reload = Animator.StringToHash(nameof(Reload));
    
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _smoothCoefficiente;

    private void OnEnable()
    {
        _mover.Moved += UpdateMoveParametres;
        _shooter.Shot += PlayShootAnimation;
        _shooter.Reloaded += PlayReloadAnimation;
    }

    private void OnDisable()
    {
        _mover.Moved -= UpdateMoveParametres;
        _shooter.Shot -= PlayShootAnimation;
        _shooter.Reloaded -= PlayReloadAnimation;
    }

    private void UpdateMoveParametres(Vector2 direction)
    {
        var currentParams = new Vector2(_animator.GetFloat(X), _animator.GetFloat(Y));
        direction = Vector2.Lerp(currentParams, direction, _smoothCoefficiente);
        
        _animator.SetFloat(X, direction.x);
        _animator.SetFloat(Y, direction.y);
    }

    private void PlayShootAnimation()
    {
        _animator.SetTrigger(Fire);
    }

    private void PlayReloadAnimation()
    {
        _animator.SetTrigger(Reload);
    }

}
