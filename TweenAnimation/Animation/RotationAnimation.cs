using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class RotationAnimation : IAnimation
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
            _customOptions.To = _transform.localRotation.eulerAngles;
        }

        public Tweener Show(float durationDelta = 1f)
        {
            _transform.rotation = Quaternion.Euler(_customOptions.From);
            return _transform
                .DORotate(_customOptions.To, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }

        public Tweener Hide(float durationDelta = 1f)
        {
            _transform.rotation = Quaternion.Euler(_customOptions.To);
            return _transform
                .DORotate(_customOptions.From, _options.Duration * durationDelta)
                .SetEase(_options.HideEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }
    }
}