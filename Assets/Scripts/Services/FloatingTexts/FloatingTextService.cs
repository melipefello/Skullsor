using System.Collections.Generic;
using System.Linq;
using Settings;
using UnityEngine;

namespace Services.FloatingTexts
{
    public class FloatingTextService
    {
        readonly FloatingTextSettings _settings;
        readonly RectTransform _container;
        readonly List<FloatingText> _floatingTexts = new();

        public FloatingTextService(FloatingTextSettings settings, RectTransform container)
        {
            _settings = settings;
            _container = container;
        }

        public void PlayHit(int amount, Vector3 point)
        {
            var floatingText = GetFloatingText();
            floatingText.transform.localPosition = point;
            floatingText.SetText(amount.ToString(), point);
        }

        FloatingText GetFloatingText()
        {
            var floatingText = _floatingTexts.FirstOrDefault(f => !f.gameObject.activeSelf);
            if (floatingText == null)
            {
                floatingText = Object.Instantiate(_settings.FloatingTextPrefab, _container);
                _floatingTexts.Add(floatingText);
            }

            floatingText.gameObject.SetActive(true);
            return floatingText;
        }
    }
}