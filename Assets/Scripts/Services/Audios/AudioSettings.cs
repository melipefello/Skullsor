using System;
using UnityEngine;

namespace Services.Audios
{
    [Serializable]
    public class AudioSettings
    {
        [field: SerializeField]
        public AudioClip[] HitClips { get; private set; }

        [field: SerializeField]
        public AudioClip DeathClip { get; private set; }
    }
}