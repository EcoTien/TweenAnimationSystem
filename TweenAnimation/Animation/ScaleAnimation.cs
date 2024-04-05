using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class ScaleAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private Transform _transform;
        private Vector3Options _options;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _transform = animationFactory.TweenAnimation.transform;
            _options = _factory.TweenAnimation.Vector3Options;
        }

        public Tweener Show(float durationDelta = 1f)
        {
            //_transform.localScale = _options.From;
            return _transform
                .DOScale(_options.To, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }

        public Tweener Hide(float durationDelta = 1f)
        {
            //_transform.localScale = _options.To;
            return _transform
                .DOScale(_options.From, _options.Duration * durationDelta)
                .SetEase(_options.HideEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }
    }
}