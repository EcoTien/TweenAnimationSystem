using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class MoveArchorsAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private RectTransform _transform;
        private Vector3Options _vector3Options;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _transform = animationFactory.TweenAnimation.transform as RectTransform;
            _vector3Options = _factory.TweenAnimation.Vector3Options;
        }

        public Tweener Show()
        {
            _transform.anchoredPosition = _vector3Options.From;
            return _transform
                .DOAnchorPos(_vector3Options.To, _vector3Options.Duration)
                .SetEase(_vector3Options.ShowEase)
                .SetUpdate(_vector3Options.IgnoreTimeScale)
                .SetDelay(_vector3Options.StartDelay);
        }

        public Tweener Hide()
        {
            _transform.anchoredPosition = _vector3Options.To;
            return _transform
                .DOAnchorPos(_vector3Options.From, _vector3Options.Duration)
                .SetEase(_vector3Options.HideEase)
                .SetUpdate(_vector3Options.IgnoreTimeScale)
                .SetDelay(_vector3Options.StartDelay);
        }
    }
}