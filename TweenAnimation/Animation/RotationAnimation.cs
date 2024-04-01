using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class RotationAnimation : IAnimation
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

        public Tweener Show()
        {
            _transform.rotation = Quaternion.Euler(_options.From);
            return _transform
                .DORotate(_options.To, _options.Duration)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay);
        }

        public Tweener Hide()
        {
            _transform.rotation = Quaternion.Euler(_options.To);
            return _transform
                .DORotate(_options.From, _options.Duration)
                .SetEase(_options.HideEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay);
        }
    }
}