using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class MoveArchorsAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private RectTransform _transform;
        private Vector3Options _options;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _transform = animationFactory.TweenAnimation.transform as RectTransform;
            _options = _factory.TweenAnimation.Vector3Options;
        }

        public Tweener Show()
        {
            _transform.anchoredPosition = _options.From;
            return _transform
                .DOAnchorPos(_options.To, _options.Duration)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay);
        }

        public Tweener Hide()
        {
            _transform.anchoredPosition = _options.To;
            return _transform
                .DOAnchorPos(_options.From, _options.Duration)
                .SetEase(_options.HideEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay);
        }
    }
}