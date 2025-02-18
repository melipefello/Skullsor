using Enemies;
using Services.Particles;
using Settings;
using UnityEngine;
using AudioSettings = Services.Audios.AudioSettings;

[CreateAssetMenu]
public class GameSettings : ScriptableObject
{
    [field: SerializeField]
    public EnemySettings EnemySettings { get; private set; }

    [field: SerializeField]
    public AudioSettings AudioSettings { get; private set; }

    [field: SerializeField]
    public FloatingTextSettings FloatingTextSettings { get; private set; }

    [field: SerializeField]
    public ParticleSettings ParticleSettings { get; private set; }
}