using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerAudioHandler : MonoBehaviour
    {
        [SerializeField] private float _minPitch;
        [SerializeField] private float _maxPitch;
        [SerializeField] private PlayerMover _mover;
        [SerializeField] private AudioSource _source;
        [SerializeField] private List<AudioClip> _stepSounds;
        

        private void OnEnable()
        {
            _mover.Moved += PlayStepSound;
        }

        private void OnDisable()
        {
            _mover.Moved -= PlayStepSound;
        }

        private void PlayStepSound(Vector2 direction)
        {
            if (direction != Vector2.zero && _source.isPlaying == false)
            {
                _source.clip = _stepSounds[Random.Range(0, _stepSounds.Count)];
                _source.pitch = Random.Range(_minPitch, _maxPitch);
                _source.Play();
            }
        }
    }
}