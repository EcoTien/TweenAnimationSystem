using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class MoveLocalAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private Transform _transform;
        private Vector3Options _options;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _transform = animationFactory.TweenAnimation.transform;
            _options = _factory.TweenAnimation.Vector3Options;
            _options.To = _transform.localPosition;
        }

        public Tweener Show(float durationDelta = 1f)
        {
            _transform.localPosition = _options.From;
            return _transform
                .DOLocalMove(_options.To, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }

        public Tweener Hide(float durationDelta = 1f)
        {
            _transform.localPosition = _options.To;
            return _transform
                .DOLocalMove(_options.From, _options.Duration * durationDelta)
                .SetEase(_options.HideEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }
    }
}