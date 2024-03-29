using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class MoveAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private Transform _transform;
        private Vector3Options _vector3Options;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _transform = animationFactory.TweenAnimation.transform;
            _vector3Options = _factory.TweenAnimation.Vector3Options;
        }

        public Tweener Show()
        {
            _transform.position = _vector3Options.From;
            return _transform
                .DOMove(_vector3Options.To, _vector3Options.Duration)
                .SetEase(_vector3Options.ShowEase)
                .SetUpdate(_vector3Options.IgnoreTimeScale)
                .SetDelay(_vector3Options.StartDelay);
        }

        public Tweener Hide()
        {
            _transform.position = _vector3Options.To;
            return _transform
                .DOMove(_vector3Options.From, _vector3Options.Duration)
                .SetEase(_vector3Options.HideEase)
                .SetUpdate(_vector3Options.IgnoreTimeScale)
                .SetDelay(_vector3Options.StartDelay);
        }
    }
}