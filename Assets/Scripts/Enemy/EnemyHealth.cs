using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : Health
    {
        protected override void OnDeath()
        {
            base.OnDeath();
            Destroy(gameObject);
        }
    }
}