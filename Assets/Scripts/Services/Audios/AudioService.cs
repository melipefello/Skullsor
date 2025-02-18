using System.Collections.Generic;
using UnityEngine;

namespace Services.Audios
{
    public class AudioService
    {
        readonly AudioSettings _settings;
        readonly Queue<AudioSource> _soundEffectSources = new();

        public AudioService(AudioSettings settings)
        {
            _settings = settings;
            var unityAudioSettings = UnityEngine.AudioSettings.GetConfiguration();
            for (var i = 0; i < unityAudioSettings.numRealVoices; i++)
            {
                _soundEffectSources.Enqueue(new GameObject("SoundEffectSource").AddComponent<AudioSource>());
            }
        }

        public void PlayHit()
        {
            var audioSource = GetSource();
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(_settings.HitClips[Random.Range(0, _settings.HitClips.Length)]);
        }

        public void PlayDeath()
        {
            var audioSource = GetSource();
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(_settings.DeathClip);
        }

        AudioSource GetSource()
        {
            var source = _soundEffectSources.Dequeue();
            source.Stop();
            _soundEffectSources.Enqueue(source);
            return source;
        }
    }
}