using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Enemies
{
    public class EnemyView : MonoBehaviour
    {
        public event Action DiedAnimationFinished;
        public event Action HitAnimationFinished;
        public event Action CrawlingAnimationFinished;

        [SerializeField] Animator _animator;

        public void PlayAnimation(string stateName, float transitionDuration = 0f)
        {
            _animator.CrossFade(stateName, transitionDuration, 0, 0f);
        }

        [UsedImplicitly]
        void OnHitCompleted()
        {
            HitAnimationFinished?.Invoke();
        }

        [UsedImplicitly]
        void OnDiedCompleted()
        {
            DiedAnimationFinished?.Invoke();
        }

        [UsedImplicitly]
        void OnCrawlingCompleted()
        {
            CrawlingAnimationFinished?.Invoke();
        }
    }
}