using System;
using Services;
using Services.Audios;
using Services.FloatingTexts;
using Services.Particles;
using States;
using UnityEngine;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        public event Action Interacted;

        [SerializeField] Transform _particlesTarget;
        [SerializeField] EnemyView _view;
        ParticleService _particleService;
        AudioService _audioService;
        FloatingTextService _floatingTextService;

        public StateMachine<EnemyState> StateMachine { get; } = new();
        public EnemyState IdleState { get; private set; }
        public EnemyState CrawlingState { get; private set; }
        public EnemyState DeadState { get; private set; }

        void OnMouseEnter()
        {
            Interacted?.Invoke();
        }

        public void Initialize(EnemyModel model, ServiceLocator serviceLocator)
        {
            IdleState = new IdleState(model, this, _view);
            DeadState = new DeadState(model, this, _view);
            CrawlingState = new CrawlingState(model, this, _view);
            _floatingTextService = serviceLocator.Get<FloatingTextService>();
            _audioService = serviceLocator.Get<AudioService>();
            _particleService = serviceLocator.Get<ParticleService>();
            StateMachine.SetState(IdleState);
        }

        public void HandleDamageTaken(int amount)
        {
            _view.PlayAnimation("Hit");
            _particleService.PlayHit(_particlesTarget.position);
            _floatingTextService.PlayHit(amount, _particlesTarget.position);
            _audioService.PlayHit();
        }

        public void HandleDied()
        {
            _view.PlayAnimation("Die");
            _particleService.PlayDeath(_particlesTarget.position);
            _audioService.PlayDeath();
        }
    }
}