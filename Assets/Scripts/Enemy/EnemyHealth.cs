using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
    public class EnemyHealth : Health
    {
        [SerializeField] private float _destroyDelay = 5f;
        protected override void OnDeath()
        {
            base.OnDeath();

            var monoBehs = GetComponents<MonoBehaviour>().ToList();

            GetComponent<Collider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            
            foreach (var item in monoBehs)
            {
                item.enabled = false;
            }
            
            Destroy(gameObject, _destroyDelay);
        }
    }
}