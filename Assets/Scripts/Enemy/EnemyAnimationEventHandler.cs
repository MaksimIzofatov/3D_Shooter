using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimationEventHandler : MonoBehaviour
    {
        public event Action HitAnimationEnded; 
        public event Action AttackedAnimationMiddle; 
        public event Action AttackedAnimationEnded; 
        
        private void Ended()
        {
            HitAnimationEnded?.Invoke();
        }

        private void Attacked()
        {
            AttackedAnimationMiddle?.Invoke();
        }

        private void AttackEnded()
        {
            AttackedAnimationEnded?.Invoke();
        }
    }
}