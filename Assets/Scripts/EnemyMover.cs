using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            PickNewPatrolPoint();
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _agent.destination) < _agent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }

        private void PickNewPatrolPoint()
        {
            _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);

        }
    }
}