using Services;
using UnityEngine;

namespace Enemies
{
    public class EnemyHandler
    {
        readonly EnemySettings _settings;
        readonly ServiceLocator _serviceLocator;

        public EnemyHandler(EnemySettings settings, ServiceLocator serviceLocator)
        {
            _settings = settings;
            _serviceLocator = serviceLocator;
        }

        public void Create(Vector2 position)
        {
            var xzPosition = new Vector3(position.x, 0, position.y);
            var controller = Object.Instantiate(_settings.Prefab, xzPosition, Quaternion.identity);
            controller.Initialize(new EnemyModel(), _serviceLocator);
        }
    }
}