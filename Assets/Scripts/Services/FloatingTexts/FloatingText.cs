using PrimeTween;
using TMPro;
using UnityEngine;

namespace Services.FloatingTexts
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] TMP_Text _text;
        Sequence _sequence;

        public void SetText(string text, Vector3 worldPoint)
        {
            var upPoint = worldPoint + Vector3.up * 3 + Vector3.right * Random.Range(-.5f, .5f);
            var finalPoint = worldPoint + Vector3.down * 2;
            _text.text = text;
            _sequence.Complete();
            _sequence = Sequence.Create()
                .Chain(Tween.Scale(_text.rectTransform, Vector3.zero, Vector3.one, .2f, Ease.OutBounce))
                .Group(Tween.Position(_text.rectTransform, worldPoint, upPoint, .2f, Ease.OutQuad))
                .Chain(Tween.PunchScale(_text.rectTransform, Vector3.up, .2f))
                .ChainDelay(0.2f)
                .Chain(Tween.Scale(_text.rectTransform, Vector3.zero, .5f, Ease.InSine))
                .Group(Tween.Position(_text.rectTransform, finalPoint, .5f, Ease.InSine))
                .OnComplete(() => gameObject.SetActive(false));
        }
    }
}