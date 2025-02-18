using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.Particles
{
    public class ParticleService
    {
        readonly ParticleSettings _settings;
        readonly List<ParticleSystem> _hitParticles = new();
        readonly List<ParticleSystem> _deathParticles = new();

        public ParticleService(ParticleSettings settings)
        {
            _settings = settings;
        }

        public void PlayHit(Vector3 point)
        {
            var hitParticle = GetHitParticle();
            hitParticle.transform.position = point;
            hitParticle.Play();
        }

        public void PlayDeath(Vector3 point)
        {
            var deathParticle = GetDeathParticle();
            deathParticle.transform.position = point;
            deathParticle.Play();
        }

        ParticleSystem GetHitParticle()
        {
            var hitParticle = _hitParticles.FirstOrDefault(hitParticle => !hitParticle.isPlaying);
            if (hitParticle == null)
            {
                hitParticle = Object.Instantiate(_settings.HitParticlesPrefab, Vector3.zero, Quaternion.identity);
                _hitParticles.Add(hitParticle);
            }

            return hitParticle;
        }

        ParticleSystem GetDeathParticle()
        {
            var deathParticle = _deathParticles.FirstOrDefault(deathParticle => !deathParticle.isPlaying);
            if (deathParticle == null)
            {
                deathParticle = Object.Instantiate(_settings.DeathParticlesPrefab, Vector3.zero, Quaternion.identity);
                _deathParticles.Add(deathParticle);
            }

            return deathParticle;
        }
    }
}