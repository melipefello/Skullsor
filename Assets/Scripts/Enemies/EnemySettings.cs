using System;
using UnityEngine;

namespace Enemies
{
    [Serializable]
    public class EnemySettings
    {
        [field: SerializeField]
        public EnemyController Prefab { get; private set; }
    }
}