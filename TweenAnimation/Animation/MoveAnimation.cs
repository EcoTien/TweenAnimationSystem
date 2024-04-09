using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class MoveAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private Transform _transform;
        private BaseOptions _options;
        private Vector3Options _customOptions;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _transform = animationFactory.TweenAnimation.transform;
            _options = _factory.TweenAnimation.BaseOptions;
            _customOptions = _factory.TweenAnimation.Vector3Options;
            _customOptions.To = _transform.position;
        }

        public Tweener Show(float durationDelta = 1f)
        {
            _transform.position = _customOptions.From;
            return _transform
                .DOMove(_customOptions.To, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }

        public Tweener Hide(float durationDelta = 1f)
        {
            _transform.position = _customOptions.To;
            return _transform
                .DOMove(_customOptions.From, _options.Duration * durationDelta)
                .SetEase(_options.HideEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }
    }
}