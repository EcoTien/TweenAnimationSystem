using DG.Tweening;
using UnityEngine;

namespace Eco.TweenAnimation
{
    public class SpriteColorAnimation : IAnimation
    {
        private AnimationFactory _factory;
        private SpriteRenderer _spriteRenderer;
        private BaseOptions _options;
        private ColorOptions _customOptions;
        
        public void Initialized(AnimationFactory animationFactory)
        {
            _factory = animationFactory;
            _spriteRenderer = animationFactory.TweenAnimation.SpriteRenderer;
            _options = animationFactory.TweenAnimation.BaseOptions;
            _customOptions = animationFactory.TweenAnimation.ColorOptions;
        }

        public void SetAnimationFrom()
        {
            _spriteRenderer.color = _customOptions.From;
        }

        public Tweener Show(float durationDelta = 1f)
        {
            _spriteRenderer.color = _customOptions.From;
            return _spriteRenderer
                .DOColor(_customOptions.EndTo, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }

        public Tweener Hide(float durationDelta = 1f)
        {
            _spriteRenderer.color = _customOptions.EndTo;
            return _spriteRenderer
                .DOColor(_customOptions.From, _options.Duration * durationDelta)
                .SetEase(_options.ShowEase)
                .SetUpdate(_options.IgnoreTimeScale)
                .SetDelay(_options.StartDelay * durationDelta);
        }
    }
}