using System;
using UnityEngine;

namespace Services.Particles
{
    [Serializable]
    public class ParticleSettings
    {
        [field: SerializeField]
        public ParticleSystem HitParticlesPrefab { get; private set; }

        [field: SerializeField]
        public ParticleSystem DeathParticlesPrefab { get; private set; }
    }
}