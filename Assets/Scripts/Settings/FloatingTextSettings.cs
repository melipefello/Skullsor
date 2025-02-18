using System;
using Services.FloatingTexts;
using UnityEngine;

namespace Settings
{
    [Serializable]
    public class FloatingTextSettings
    {
        [field: SerializeField]
        public FloatingText FloatingTextPrefab { get; private set; }
    }
}