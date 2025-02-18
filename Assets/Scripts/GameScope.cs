using Enemies;
using Services;
using Services.Audios;
using Services.FloatingTexts;
using Services.Particles;
using UnityEngine;

public class GameScope : MonoBehaviour
{
    [SerializeField] GameSettings _settings;
    [SerializeField] RectTransform _uiContainer;
    readonly ServiceLocator _serviceLocator = new();
    EnemyHandler _enemyHandler;

    void Start()
    {
#if UNITY_EDITOR
        //Required to record cursor in editor
        Cursor.SetCursor(UnityEditor.PlayerSettings.defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
#endif
        _serviceLocator.Register(new AudioService(_settings.AudioSettings));
        _serviceLocator.Register(new FloatingTextService(_settings.FloatingTextSettings, _uiContainer));
        _serviceLocator.Register(new ParticleService(_settings.ParticleSettings));
        _enemyHandler = new EnemyHandler(_settings.EnemySettings, _serviceLocator);
        _enemyHandler.Create(Vector2.zero);
        _enemyHandler.Create(Rotate(Vector2.up) * 2);
        _enemyHandler.Create(Rotate(Vector2.right) * 2);
        _enemyHandler.Create(Rotate(Vector2.down) * 2);
        _enemyHandler.Create(Rotate(Vector2.left) * 2);
    }

    Vector2 Rotate(Vector2 direction, float angle = 45)
    {
        direction = direction.normalized;
        var radianAngle = angle * Mathf.Deg2Rad;
        var newX = direction.x * Mathf.Cos(radianAngle) - direction.y * Mathf.Sin(radianAngle);
        var newY = direction.x * Mathf.Sin(radianAngle) + direction.y * Mathf.Cos(radianAngle);
        return new Vector2(newX, newY).normalized;
    }
}